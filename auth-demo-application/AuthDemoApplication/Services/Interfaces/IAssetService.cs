using AuthDemoApplication.DTOs.Assets;
using AuthDemoApplication.Models;

namespace AuthDemoApplication.Services.Interfaces;

public interface IAssetService
{
    Task<List<AssetDto>> GetAllAssetsAsync();
}