using Microsoft.EntityFrameworkCore;
namespace AuthDemoApplication.Models;

[PrimaryKey(nameof(FollowerId), nameof(SellerProfileId))]
public sealed class Follow
{
    public DateTime FollowedAt { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public string FollowerId { get; set; } = string.Empty;
    public Guid SellerProfileId { get; set; }

    // Navigation
    public ApplicationUser Follower { get; set; } = null!;
    public SellerProfile SellerProfile { get; set; } = null!;
}