namespace AuthDemoApplication.Models;

public sealed class AssetReport
{
    public Guid Id { get; set; }
    public ReportReason Reason { get; set; }
    public string Description { get; set; } = string.Empty;
    public ReportStatus Status { get; set; } = ReportStatus.Open;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ResolvedAt { get; set; }

    // Foreign keys
    public Guid AssetId { get; set; }
    public string ReporterId { get; set; } = string.Empty;

    // Navigation
    public Asset Asset { get; set; } = null!;
    public ApplicationUser Reporter { get; set; } = null!;
}

public enum ReportReason
{
    Copyright,
    Malware,
    Misleading,
    Spam,
    Other
}

public enum ReportStatus
{
    Open,
    UnderReview,
    Resolved,
    Dismissed
}