using AuthDemoApplication.DTOs;
using AuthDemoApplication.DTOs.Assets;
using AuthDemoApplication.Models;

namespace AuthDemoApplication.Services.Interfaces;

public interface IAssetService
{
    Task<List<AssetDto>> GetAllAssetsAsync();
    Task<List<AssetDto>> GetFeaturedAssetsAsync();
    Task<List<AssetDto>> GetMostDownloadedAssetsAsync();
    Task<PagedResult<AssetDto>> GetPagedAssetsAsync(int pageNumber, int pageSize);

}   