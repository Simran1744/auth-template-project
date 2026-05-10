using AuthDemoApplication.Models;

namespace AuthDemoApplication.Services.Interfaces;

public interface IJwtTokenService
{
    Task<(string Token, DateTime ExpiresAtUtc)> CreateTokenAsync(ApplicationUser user);
}