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
    
    [HttpGet("getPagedAssets")]
    public async Task<IActionResult> GetAllPagedAssets([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 12)
    {
        //Console.WriteLine("pageNumber: " + pageNumber);
        //Console.WriteLine("pageSize: " + pageSize);
        var result = await _assetService.GetPagedAssetsAsync(pageNumber, pageSize);
        return Ok(result);
    }

    [HttpGet("getMostDownloadedAssets")]
    public async Task<IActionResult> GetMostDownloadedAssets()
    {
        var result = await _assetService.GetMostDownloadedAssetsAsync();
        return Ok(result);
    }

    [HttpGet("getFeaturedAssets")]
    public async Task<IActionResult> GetFeaturedAssets()
    {
        var result = await _assetService.GetFeaturedAssetsAsync();
        return Ok(result);
    }
    
    
    
}