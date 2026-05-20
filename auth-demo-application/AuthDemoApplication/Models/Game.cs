namespace AuthDemoApplication.Models;

public sealed class Game
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? CoverImageUrl { get; set; }
    public string? Developer { get; set; }
    public string? Publisher { get; set; }
    public int? ReleaseYear { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public ICollection<GameCategory> GameCategories { get; set; } = [];
    public ICollection<Asset> Assets { get; set; } = [];  
}