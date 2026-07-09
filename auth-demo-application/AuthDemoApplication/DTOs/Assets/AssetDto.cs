using AuthDemoApplication.Models;

namespace AuthDemoApplication.DTOs.Assets;

public class AssetDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string LongDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Currency { get; set; } = "EUR";
    public AssetStatus Status { get; set; } = AssetStatus.Draft;
    public string? Version { get; set; }
    public bool IsFeatured { get; set; } = false;
    public int TotalDownloads { get; set; } = 0;
    public double AverageRating { get; set; } = 0;
    public int ReviewCount { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PublishedAt { get; set; }

    public Guid GameId { get; set; }
    
    public string GameName { get; set; } = string.Empty;
}