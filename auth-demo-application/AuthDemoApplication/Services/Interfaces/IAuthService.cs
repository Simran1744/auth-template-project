using AuthDemoApplication.DTOs.Auth;
using AuthDemoApplication.Services.Results;

namespace AuthDemoApplication.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterRequest request);

    Task<AuthResult> LoginAsync(LoginRequest request);
}