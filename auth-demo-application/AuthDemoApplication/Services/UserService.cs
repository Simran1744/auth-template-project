using AuthDemoApplication.DTOs.Users;
using AuthDemoApplication.Models;
using AuthDemoApplication.Repositories.Interfaces;
using AuthDemoApplication.Services.Interfaces;

namespace AuthDemoApplication.Services;

public sealed class UserService  : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserProfileDto?> GetProfileAsync(string userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null) return null;
        return MapToDto(user);
    }

    public async Task<UserProfileDto> UpdateProfileAsync(
        string userId, 
        UpdateUserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user is null)
        {
            throw new InvalidOperationException("User not found.");
        }

        // Only update fields that were actually sent
        if (dto.Username is not null) user.UserName = dto.Username;
        if (dto.Bio is not null) user.Bio = dto.Bio;
        if (dto.AvatarUrl is not null) user.AvatarUrl = dto.AvatarUrl;

        var updated = await _userRepository.UpdateAsync(user);
        return MapToDto(updated);
    }

    private static UserProfileDto MapToDto(ApplicationUser u) => new()
    {
        Id = u.Id,
        Username = u.UserName ?? string.Empty,
        Email = u.Email ?? string.Empty,
        Bio = u.Bio,
        AvatarUrl = u.AvatarUrl,
        CreatedAt = u.CreatedAt
    };
}