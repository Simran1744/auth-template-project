using Microsoft.AspNetCore.Identity;

namespace AuthDemoApplication.Models;

public sealed class ApplicationUser : IdentityUser
{
    public string? Bio { get; set; }
    public bool IsBanned { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }
    public string? AvatarUrl { get; set; }
}
