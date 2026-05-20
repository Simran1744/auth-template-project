namespace AuthDemoApplication.DTOs.Users;

public class UserProfileDto {
    
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    
}