using System.Security.Claims;
using AuthDemoApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemoApplication.Controllers;

[ApiController]
[Route("api/assets")]
public class AssetController : ControllerBase
{
    
    private readonly IAssetService _assetService;
    
    public AssetController(IAssetService assetService)
    {
        _assetService = assetService;
    }
    
    [HttpGet("getAssets")]
    public async Task<IActionResult> GetAllAssets()
    {   
        // Does a user have to be authorized to view assets? -> no
        /*var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return Unauthorized();*/

        var result = await _assetService.GetAllAssetsAsync();
        if (result is null) return NotFound();

        return Ok(result);
    }
    
}