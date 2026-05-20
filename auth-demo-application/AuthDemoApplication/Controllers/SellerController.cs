using System.Security.Claims;
using AuthDemoApplication.DTOs.Seller;
using AuthDemoApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemoApplication.Controllers;


[ApiController]
[Route("api/seller")]
[Authorize] // entire controller requires auth
public sealed class SellerController : ControllerBase
{
    private readonly ISellerService _sellerService;

    public SellerController(ISellerService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpPost("apply")]
    public async Task<IActionResult> Apply(
        [FromBody] CreateSellerProfileDto dto)
    {
        // Extract the user ID from the JWT token
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return Unauthorized();

        try
        {
            var result = await _sellerService.ApplyAsSellerAsync(userId, dto);
            return CreatedAtAction(nameof(GetMyProfile), result);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMyProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return Unauthorized();

        var profile = await _sellerService.GetSellerProfileAsync(userId);
        if (profile is null) return NotFound(new { message = "No seller profile found." });

        return Ok(profile);
    }
}