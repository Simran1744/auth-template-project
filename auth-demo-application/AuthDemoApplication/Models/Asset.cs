namespace AuthDemoApplication.Models;

public sealed class Asset
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
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

    // Foreign keys
    public Guid SellerProfileId { get; set; }
    public Guid GameId { get; set; }
    public Guid CategoryId { get; set; }

    // Navigation properties
    public SellerProfile SellerProfile { get; set; } = null!;
    public Game Game { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public ICollection<AssetFile> Files { get; set; } = [];
    public ICollection<AssetPreview> Previews { get; set; } = [];
    public ICollection<AssetTag> Tags { get; set; } = [];
    public ICollection<AssetCompatibility> Compatibilities { get; set; } = [];
}

public enum AssetStatus
{
    Draft,
    PendingReview,
    Active,
    Rejected,
    Archived
}