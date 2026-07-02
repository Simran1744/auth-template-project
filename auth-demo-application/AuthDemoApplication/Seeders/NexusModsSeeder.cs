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
    private readonly HttpClient _httpClient;
    private readonly NexusOptions _options;

    public NexusModsSeeder(HttpClient httpClient, IOptions<NexusOptions> options, IAssetRepository assetRepository)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _assetRepository = assetRepository;
    }
    
    public async Task<bool> GetTrendingModsAsync()
    {
        var game = string.Empty;
        
        // 1. Create the request message
         var request = new HttpRequestMessage(HttpMethod.Get, $"games/{game}/mods/trending.json");

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
                    Slug = mod.name ?? string.Empty,
                    ShortDescription = mod.description ?? string.Empty,
                    LongDescription = mod.description ?? string.Empty,
                    Price = 10,
                    Currency = "EUR",
                    Status  = AssetStatus.Draft,
                    Version = mod.version ?? string.Empty ,
                    IsFeatured = false,
                    TotalDownloads = mod.mod_downloads ?? 0,
                    AverageRating = 0,
                    ReviewCount = 0,
                    CreatedAt = mod.created_time ?? DateTime.UtcNow,
                    UpdatedAt = mod.updated_time ?? DateTime.UtcNow,
                    PublishedAt = mod.created_time ?? DateTime.UtcNow,

                    // Foreign keys
                    SellerProfileId = "1CE5881F-B43A-4227-A53B-BDADB05EFB58", 
                    GameId = , //Choose the right GameID
                    CategoryId = ,
                };
        
                var created = await _assetRepository.CreateAsync(Asset);
                
                Console.WriteLine($"Created: {created}");
            }
        }
        
        //return await response.Content.ReadFromJsonAsync<List<NexusModsJsonResponse>>();
    }
    



}