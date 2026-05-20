using AuthDemoApplication.DTOs.Users;

namespace AuthDemoApplication.Services.Interfaces;

public interface IUserService
{
    Task<UserProfileDto?> GetProfileAsync(string userId);
    Task<UserProfileDto> UpdateProfileAsync(string userId, UpdateUserDto dto);
}
