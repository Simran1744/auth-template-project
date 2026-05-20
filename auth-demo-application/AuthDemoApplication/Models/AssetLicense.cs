namespace AuthDemoApplication.Models;

public sealed class AssetLicense
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public bool IsDefault { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public Guid AssetId { get; set; }
    public Guid LicenseTypeId { get; set; }

    // Navigation
    public Asset Asset { get; set; } = null!;
    public LicenseType LicenseType { get; set; } = null!;
    public ICollection<Purchase> Purchases { get; set; } = [];
}