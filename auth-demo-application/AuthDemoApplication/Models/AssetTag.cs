namespace AuthDemoApplication.Models;

public sealed class AssetTag
{
    public Guid Id { get; set; }
    public string Tag { get; set; } = string.Empty;

    // Foreign key
    public Guid AssetId { get; set; }
    public Asset Asset { get; set; } = null!;
}