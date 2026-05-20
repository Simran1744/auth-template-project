namespace AuthDemoApplication.Models;

public sealed class ReviewVote
{
    public Guid Id { get; set; }
    public bool IsHelpful { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public Guid ReviewId { get; set; }
    public string UserId { get; set; } = string.Empty;

    // Navigation
    public Review Review { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;
}