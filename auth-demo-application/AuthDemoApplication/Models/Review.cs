namespace AuthDemoApplication.Models;

public sealed class Review
{
    public Guid Id { get; set; }
    public int Rating { get; set; } // 1-5
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public bool IsVerifiedPurchase { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public string ReviewerId { get; set; } = string.Empty;
    public Guid AssetId { get; set; }
    public Guid PurchaseId { get; set; }

    // Navigation
    public ApplicationUser Reviewer { get; set; } = null!;
    public Asset Asset { get; set; } = null!;
    public Purchase Purchase { get; set; } = null!;
    public ICollection<ReviewVote> Votes { get; set; } = [];
}