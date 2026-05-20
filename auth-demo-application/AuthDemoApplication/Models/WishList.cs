namespace AuthDemoApplication.Models;

public sealed class Wishlist
{
    public Guid Id { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public string UserId { get; set; } = string.Empty;
    public Guid AssetId { get; set; }

    // Navigation
    public ApplicationUser User { get; set; } = null!;
    public Asset Asset { get; set; } = null!;
}