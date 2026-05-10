using Microsoft.AspNetCore.Identity;
using AuthDemoApplication.DTOs.Auth;
using AuthDemoApplication.Models;
using AuthDemoApplication.Repositories.Interfaces;
using AuthDemoApplication.Services.Interfaces;
using AuthDemoApplication.Services.Results;

namespace AuthDemoApplication.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthResult> RegisterAsync(RegisterRequest request)
    {
        var normalizedEmail = request.Email.Trim();
        var normalizedUserName = request.UserName.Trim();

        if (await _userRepository.EmailExistsAsync(normalizedEmail))
        {
            return AuthResult.Failure("This email address is already in use.");
        }

        if (await _userRepository.UserNameExistsAsync(normalizedUserName))
        {
            return AuthResult.Failure("This username is already in use.");
        }

        var user = new ApplicationUser
        {
            UserName = normalizedUserName,
            Email = normalizedEmail,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return AuthResult.Failure(result.Errors.Select(error => error.Description));
        }

        var tokenResult = await _jwtTokenService.CreateTokenAsync(user);

        var response = new AuthResponse
        {
            AccessToken = tokenResult.Token,
            ExpiresAtUtc = tokenResult.ExpiresAtUtc,
            User = new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty
            }
        };

        return AuthResult.Success(response);
    }

    public async Task<AuthResult> LoginAsync(LoginRequest request)
    {
        var normalizedEmail = request.Email.Trim();

        var user = await _userRepository.FindByEmailAsync(normalizedEmail);

        if (user is null)
        {
            return AuthResult.Failure("Invalid login credentials.");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
        {
            await _userManager.AccessFailedAsync(user);

            if (await _userManager.IsLockedOutAsync(user))
            {
                return AuthResult.Failure("Your account has been temporarily locked. Please try again later.");
            }

            return AuthResult.Failure("Invalid login credentials.");
        }

        if (await _userManager.IsLockedOutAsync(user))
        {
            return AuthResult.Failure("Your account has been temporarily locked. Please try again later.");
        }

        await _userManager.ResetAccessFailedCountAsync(user);

        var tokenResult = await _jwtTokenService.CreateTokenAsync(user);

        var response = new AuthResponse
        {
            AccessToken = tokenResult.Token,
            ExpiresAtUtc = tokenResult.ExpiresAtUtc,
            User = new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty
            }
        };

        return AuthResult.Success(response);
    }
}