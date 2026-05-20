using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthDemoApplication.DTOs.Auth;
using AuthDemoApplication.Services.Interfaces;

namespace AuthDemoApplication.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await _authService.RegisterAsync(request);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return ValidationProblem(ModelState);
        }

        /* HttpOnly Cookie-based JWT Authentication */
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = false,      // set to true in production -> becuase of HTTP on local host testing
            SameSite = SameSiteMode.Strict,
            Expires = result.Response.ExpiresAtUtc  
        };

        Response.Cookies.Append("token", result.Response.AccessToken, cookieOptions); //set token inside the HTTP Cookie

        return Ok(result.Response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginRequest request)
    {   

        var result = await _authService.LoginAsync(request);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return ValidationProblem(ModelState);
        }

        /* HttpOnly Cookie-based JWT Authentication */
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = false,      // set to true in production -> becuase of HTTP on local host testing
            SameSite = SameSiteMode.Strict,
            Expires = result.Response.ExpiresAtUtc  
        };

        Response.Cookies.Append("token", result.Response.AccessToken, cookieOptions); //set token inside the HTTP Cookie

        return Ok(result.Response.User); //Only return the user not the token itself
    }

    [HttpGet("me")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult Me()
    {
        return Ok(new
        {
            id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
            userName = User.Identity?.Name,
            email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value
        });
    }

}