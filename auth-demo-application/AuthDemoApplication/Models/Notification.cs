namespace AuthDemoApplication.Models;


public sealed class Notification
{
    public Guid Id { get; set; }
    public NotificationType Type { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
    public Guid? ReferenceId { get; set; }
    public string? ReferenceType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key
    public string UserId { get; set; } = string.Empty;

    // Navigation
    public ApplicationUser User { get; set; } = null!;
}

public enum NotificationType
{
    NewSale,
    NewReview,
    Payout,
    AssetApproved,
    AssetRejected,
    NewFollower
}
    