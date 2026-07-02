namespace AuthDemoApplication.Seeders;

// Seeders/GameSeeder.cs
using AuthDemoApplication.Data;
using AuthDemoApplication.Models;


public static class GameSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Games.Any()) 
        {
            Console.WriteLine("Games already seeded, skipping.");
            return;
        }

        // ─── Categories ───────────────────────────────────────────
        var categories = new List<Category>
        {
            new() { Id = Guid.NewGuid(), Name = "Textures & Graphics", Slug = "textures-graphics",       Description = "HD texture packs, ENBs, reshades and visual overhauls" },
            new() { Id = Guid.NewGuid(), Name = "Gameplay",             Slug = "gameplay",                Description = "Mechanics overhauls, new systems and balance changes" },
            new() { Id = Guid.NewGuid(), Name = "Characters & NPCs",    Slug = "characters-npcs",         Description = "Character presets, NPC overhauls and companions" },
            new() { Id = Guid.NewGuid(), Name = "Quests & Worlds",      Slug = "quests-worlds",           Description = "New quests, lands, dungeons and world spaces" },
            new() { Id = Guid.NewGuid(), Name = "UI & HUD",             Slug = "ui-hud",                  Description = "Interface overhauls, HUD tweaks and menus" },
            new() { Id = Guid.NewGuid(), Name = "Weapons & Armor",      Slug = "weapons-armor",           Description = "New weapons, armors and equipment" },
            new() { Id = Guid.NewGuid(), Name = "Audio & Music",        Slug = "audio-music",             Description = "Sound overhauls, music replacers and ambient audio" },
            new() { Id = Guid.NewGuid(), Name = "Bug Fixes & Patches",  Slug = "bug-fixes-patches",       Description = "Unofficial patches, crash fixes and stability improvements" },
            new() { Id = Guid.NewGuid(), Name = "Maps & Levels",        Slug = "maps-levels",             Description = "Custom maps, levels and environments" },
            new() { Id = Guid.NewGuid(), Name = "Scripts & Tools",      Slug = "scripts-tools",           Description = "Modding utilities, frameworks and developer tools" },
        };

        await context.Categories.AddRangeAsync(categories);

        // ─── Games ────────────────────────────────────────────────
        var games = new List<Game>
        {
            new()
            {
                Id = Guid.NewGuid(), Name = "The Elder Scrolls V: Skyrim Special Edition",
                Slug = "skyrimspecialedition", Developer = "Bethesda Game Studios",
                Publisher = "Bethesda Softworks", ReleaseYear = 2016,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/1704/tile_1704.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Fallout 4",
                Slug = "fallout4", Developer = "Bethesda Game Studios",
                Publisher = "Bethesda Softworks", ReleaseYear = 2015,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/1151/tile_1151.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Cyberpunk 2077",
                Slug = "cyberpunk2077", Developer = "CD Projekt Red",
                Publisher = "CD Projekt", ReleaseYear = 2020,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/3333/tile_3333.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Stardew Valley",
                Slug = "stardewvalley", Developer = "ConcernedApe",
                Publisher = "ConcernedApe", ReleaseYear = 2016,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/1303/tile_1303.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Baldur's Gate 3",
                Slug = "baldursgate3", Developer = "Larian Studios",
                Publisher = "Larian Studios", ReleaseYear = 2023,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/3474/tile_3474.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "The Witcher 3: Wild Hunt",
                Slug = "witcher3", Developer = "CD Projekt Red",
                Publisher = "CD Projekt", ReleaseYear = 2015,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/952/tile_952.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Minecraft",
                Slug = "minecraft", Developer = "Mojang Studios",
                Publisher = "Microsoft", ReleaseYear = 2011,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/2295/tile_2295.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Dark Souls III",
                Slug = "darksouls3", Developer = "FromSoftware",
                Publisher = "Bandai Namco", ReleaseYear = 2016,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/130/tile_130.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Elden Ring",
                Slug = "eldenring", Developer = "FromSoftware",
                Publisher = "Bandai Namco", ReleaseYear = 2022,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/4333/tile_4333.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Fallout: New Vegas",
                Slug = "newvegas", Developer = "Obsidian Entertainment",
                Publisher = "Bethesda Softworks", ReleaseYear = 2010,
                CoverImageUrl = "https://staticdelivery.nexusmods.com/images/130/tile_130.jpg",
                IsActive = true, CreatedAt = DateTime.UtcNow
            },
        };

        await context.Games.AddRangeAsync(games);

        // ─── GameCategories ───────────────────────────────────────
        // Map sensible categories to each game
        var gameCategories = new List<GameCategory>();

        // Helper to find by slug
        Category Cat(string slug) => categories.First(c => c.Slug == slug);
        Game GameBySlug(string slug) => games.First(g => g.Slug == slug);

        void LinkAll(string gameSlug, params string[] categorySlugs)
        {
            foreach (var catSlug in categorySlugs)
                gameCategories.Add(new GameCategory
                {
                    GameId = GameBySlug(gameSlug).Id,
                    CategoryId = Cat(catSlug).Id
                });
        }

        LinkAll("skyrimspecialedition",
            "textures-graphics", "gameplay", "characters-npcs",
            "quests-worlds", "ui-hud", "weapons-armor",
            "audio-music", "bug-fixes-patches", "scripts-tools");

        LinkAll("fallout4",
            "textures-graphics", "gameplay", "characters-npcs",
            "quests-worlds", "ui-hud", "weapons-armor",
            "audio-music", "bug-fixes-patches", "scripts-tools");

        LinkAll("cyberpunk2077",
            "textures-graphics", "gameplay", "characters-npcs",
            "quests-worlds", "ui-hud", "weapons-armor",
            "audio-music", "bug-fixes-patches");

        LinkAll("stardewvalley",
            "textures-graphics", "gameplay", "characters-npcs",
            "quests-worlds", "ui-hud", "audio-music",
            "bug-fixes-patches", "scripts-tools");

        LinkAll("baldursgate3",
            "textures-graphics", "gameplay", "characters-npcs",
            "quests-worlds", "ui-hud", "weapons-armor",
            "audio-music", "bug-fixes-patches", "scripts-tools");

        LinkAll("witcher3",
            "textures-graphics", "gameplay", "characters-npcs",
            "quests-worlds", "ui-hud", "weapons-armor",
            "audio-music", "bug-fixes-patches");

        LinkAll("minecraft",
            "textures-graphics", "gameplay",
            "maps-levels", "ui-hud", "audio-music",
            "scripts-tools", "bug-fixes-patches");

        LinkAll("darksouls3",
            "textures-graphics", "gameplay", "characters-npcs",
            "weapons-armor", "ui-hud", "bug-fixes-patches",
            "scripts-tools");

        LinkAll("eldenring",
            "textures-graphics", "gameplay", "characters-npcs",
            "weapons-armor", "ui-hud", "bug-fixes-patches",
            "scripts-tools");

        LinkAll("newvegas",
            "textures-graphics", "gameplay", "characters-npcs",
            "quests-worlds", "ui-hud", "weapons-armor",
            "audio-music", "bug-fixes-patches", "scripts-tools");

        await context.GameCategories.AddRangeAsync(gameCategories);
        await context.SaveChangesAsync();

        Console.WriteLine($"✅ Seeded {games.Count} games, {categories.Count} categories, {gameCategories.Count} game-category links.");
    }
}