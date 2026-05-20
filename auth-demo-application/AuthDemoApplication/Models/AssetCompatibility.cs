namespace AuthDemoApplication.Models;

public sealed class AssetCompatibility
{
    public Guid Id { get; set; }
    public string RequiresTool { get; set; } = string.Empty;
    public string? CompatibleGameVersion { get; set; }
    public string? Notes { get; set; }

    // Foreign key
    public Guid AssetId { get; set; }
    public Asset Asset { get; set; } = null!;
}