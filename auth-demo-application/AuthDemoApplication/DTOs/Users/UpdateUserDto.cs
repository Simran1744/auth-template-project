namespace AuthDemoApplication.DTOs.Users;

public sealed class UpdateUserDto
{
    public string? Username { get; set; }
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
}