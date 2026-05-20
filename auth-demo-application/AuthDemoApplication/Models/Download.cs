namespace AuthDemoApplication.Models;

public sealed class Download
{
    public Guid Id { get; set; }
    public string? IpAddress { get; set; }
    public string? UserAgent { get; set; }
    public DateTime DownloadedAt { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public Guid PurchaseId { get; set; }
    public Guid AssetFileId { get; set; }

    // Navigation
    public Purchase Purchase { get; set; } = null!;
    public AssetFile AssetFile { get; set; } = null!;
}