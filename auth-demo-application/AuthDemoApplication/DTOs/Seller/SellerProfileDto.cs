using AuthDemoApplication.Models;

namespace AuthDemoApplication.DTOs.Seller;

public class SellerProfileDto
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
    public string? NexusModsProfileUrl { get; set; }
    public string? GitHubProfileUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public SellerStatus Status { get; set; }
    public bool IsFeatured { get; set; }
    public int TotalSales { get; set; }
    public DateTime CreatedAt { get; set; }
}