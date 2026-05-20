namespace AuthDemoApplication.DTOs.Seller;

public class CreateSellerProfileDto
{
    public string DisplayName { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
    public string? NexusModsProfileUrl { get; set; }
    public string? GitHubProfileUrl { get; set; }
    public string? WebsiteUrl { get; set; }
}