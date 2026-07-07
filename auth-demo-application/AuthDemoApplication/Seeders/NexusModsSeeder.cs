using AuthDemoApplication.DTOs.Mods;
using AuthDemoApplication.Models;
using AuthDemoApplication.Options;
using System.Net.Http.Json;
using AuthDemoApplication.Repositories.Interfaces; // 👈 Make sure you have this using statement
using Microsoft.Extensions.Options;

namespace AuthDemoApplication.Seeders;

public class NexusModsSeeder
{
    // Here we will call nexus mods API and retrieve the top 10 trending mods for every game we have
    // saved in our database. -> The data will of course have to be mapped and i also have to provide my API Key in the 
    //request
    
    private readonly IAssetRepository _assetRepository;
    private readonly IGameRepository _gameRepository;
    private readonly HttpClient _httpClient;
    private readonly NexusOptions _options;

    public NexusModsSeeder(HttpClient httpClient, IOptions<NexusOptions> options, IAssetRepository assetRepository,
        IGameRepository gameRepository)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _assetRepository = assetRepository;
        _gameRepository = gameRepository;
    }
    
    public async Task<bool> GetTrendingModsAsync()
    {
        var gameName = string.Empty; // read the games from a fixed array
        Game? dbGame;
        string[] gameArray = ["Fallout 4", "Baldur's Gate 3", "Elden Ring", "Fallout: New Vegas",
        "Minecraft", "The Elder Scrolls V: Skyrim Special Edition", "Stardew Valley", "Cyberpunk 2077",
        "The Witcher 3: Wild Hunt", "Dark Souls III"];
        
        //from this game array we will need to fetch the game details like the gameId from the database.
        //typically the calls would be inside the repository directory
        //I could create a new class and interface there -> get by name async
        
        foreach (string game in gameArray)
        {

            gameName = game;
        
            // Retrieve game from database over the name
            dbGame = await _gameRepository.GetGameByNameAsync(gameName);
            
            //return false if the game doesn't exist
            if (dbGame == null)
            {
                return false;
            }
            
            // 1. Create the request message
             var request = new HttpRequestMessage(HttpMethod.Get, $"games/{dbGame.Slug}/mods/trending.json");

            // 2. Add required headers
            // Nexus Mods API requires an 'apikey' header and a 'User-Agent'
            request.Headers.Add("apikey", _options.ApiKey);
            request.Headers.Add("User-Agent", "MyNexusApp/1.0 (Contact: me@example.com)");

            // 3. Send the request
            using var response = await _httpClient.SendAsync(request);
            
            // 4. Ensure we got a 2xx success code
            response.EnsureSuccessStatusCode();
            
            // 5. Read and return the content
            // This has to be mapped to a JSON String or strucutre and then be mapped to the database object
            
            
            // Instead of returning the data we should call a method that maps the response structure to the asset strucutre
            List<NexusModsJsonResponse>? mods = await response.Content.ReadFromJsonAsync<List<NexusModsJsonResponse>>();
            
            if (mods != null && mods.Count != 0)
            {
                foreach (var mod in mods)
                {
                    // Just for testing
                    Console.WriteLine($"- {mod.name} (Version: {mod.version})"); 
                    Console.WriteLine($"  Uploaded by: {mod.user?.name ?? "Unknown"}");
                    Console.WriteLine($"  Downloads: {mod.mod_downloads:N0}");
                    Console.WriteLine($"  Picture Url: {mod.picture_url ?? "Unknown"}");
                    Console.WriteLine(new string('-', 40));

                    var Asset = new Asset
                    {
                        //Map here
                        Title = mod.name ?? string.Empty,
                        Slug = CreateSlug(mod.name),
                        ShortDescription = mod.description ?? string.Empty,
                        LongDescription = mod.description ?? string.Empty,
                        Price = 10,
                        Currency = "EUR",
                        Status  = AssetStatus.Draft,
                        Version = mod.version ?? string.Empty,
                        IsFeatured = false,
                        TotalDownloads = mod.mod_downloads ?? 0,
                        AverageRating = 0,
                        ReviewCount = 0,
                        CreatedAt = mod.created_time ?? DateTime.UtcNow,
                        UpdatedAt = mod.updated_time ?? DateTime.UtcNow,
                        PublishedAt = mod.created_time ?? DateTime.UtcNow,

                        // Foreign keys
                        SellerProfileId = Guid.Parse("1CE5881F-B43A-4227-A53B-BDADB05EFB58"), 
                        GameId = dbGame.Id,
                        CategoryId = Guid.Parse("54EADC09-1482-463C-AC12-CE8FE965BB57"),
                        
                        //Additional fields such as Game
                        Game = dbGame
                    };
            
                    var created = await _assetRepository.CreateAsync(Asset);
                    
                    Console.WriteLine($"Created: {created}");
                }
            }
        }  
        
        return true;
        
    }
    
    private string CreateSlug(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return string.Empty;

        var lowerAndHyphened = title.ToLowerInvariant().Replace(" ", "-");

        // Wrap the filtered characters in string.Concat to turn them back into a string
        return string.Concat(lowerAndHyphened.Where(c => char.IsLetterOrDigit(c) || c == '-'));
    }


}