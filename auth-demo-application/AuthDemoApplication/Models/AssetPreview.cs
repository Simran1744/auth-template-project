namespace AuthDemoApplication.Models;

public sealed class AssetPreview
{
    public Guid Id { get; set; }
    public PreviewMediaType MediaType { get; set; }
    public string Url { get; set; } = string.Empty;
    public string? ThumbnailUrl { get; set; }
    public int SortOrder { get; set; } = 0;
    public string? Caption { get; set; }

    // Foreign key
    public Guid AssetId { get; set; }
    public Asset Asset { get; set; } = null!;
}

public enum PreviewMediaType
{
    Image,
    Video,
    Gif
}