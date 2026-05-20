namespace AuthDemoApplication.Models;

public sealed class SellerProfile
{
    public Guid Id { get; set; }
    
    // Link to the user
    public string ApplicationUserId { get; set; } = string.Empty;
    public ApplicationUser ApplicationUser { get; set; } = null!;
    
    // Public-facing seller info
    public string DisplayName { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
    
    // Modding-specific credibility
    public string? NexusModsProfileUrl { get; set; }
    public string? GitHubProfileUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    
    // Platform status
    public bool IsApproved { get; set; } = false;
    public bool IsFeatured { get; set; } = false;
    public DateTime? ApprovedAt { get; set; }
    
    // Payments
    public string? StripeAccountId { get; set; }
    public bool IsPayoutEnabled { get; set; } = false;
    
    // Stats (updated as sales happen)
    public int TotalSales { get; set; } = 0;
    public decimal TotalRevenue { get; set; } = 0;
    public decimal Balance { get; set; } = 0;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}