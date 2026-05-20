namespace AuthDemoApplication.Models;

public sealed class LicenseType
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool AllowsRedistribution { get; set; } = false;
    public bool AllowsCommercialUse { get; set; } = false;
    public bool AllowsModification { get; set; } = false;
    public bool AllowsResale { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public ICollection<AssetLicense> AssetLicenses { get; set; } = [];
}