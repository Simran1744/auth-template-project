namespace AuthDemoApplication.Models;

public sealed class AssetFile
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FileUrl { get; set; } = string.Empty;
    public long FileSizeBytes { get; set; }
    public string FileFormat { get; set; } = string.Empty;
    public string? VersionLabel { get; set; }
    public bool IsPrimary { get; set; } = false;
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    // Foreign key
    public Guid AssetId { get; set; }
    public Asset Asset { get; set; } = null!;
}