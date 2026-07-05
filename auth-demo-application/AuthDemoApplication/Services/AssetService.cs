using AuthDemoApplication.DTOs.Assets;
using AuthDemoApplication.Models;
using AuthDemoApplication.Repositories.Interfaces;
using AuthDemoApplication.Services.Interfaces;

namespace AuthDemoApplication.Services;

public class AssetService : IAssetService
{
    private readonly IAssetRepository _assetRepository;

    public AssetService(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<List<AssetDto>> GetAllAssetsAsync()
    {
        // Warning: This call only retrieves the first 100 assets by creation date descending
        List<Asset> assets = await _assetRepository.GetAllAssetsAsync();
        List<AssetDto> dtoAssets = new List<AssetDto>();
        
        foreach (Asset asset in assets)
        {
            AssetDto mappedAsset = MapToDto(asset);
            dtoAssets.Add(mappedAsset);
        }
        
        Console.WriteLine("Asset count: " + assets.Count);
        Console.WriteLine("Mapped assed count: " + dtoAssets.Count);

        return dtoAssets;
    }
    
    //add Method to Map Model to DTO
    
    private static AssetDto MapToDto(Asset a) => new()
    {
        Id = a.Id,
        Title = a.Title,
        ShortDescription = a.ShortDescription,
        LongDescription = a.LongDescription,
        Price = a.Price,
        Currency = a.Currency,
        Status = a.Status,
        Version = a.Version,
        IsFeatured =  a.IsFeatured,
        TotalDownloads =  a.TotalDownloads,
        AverageRating =  a.AverageRating,
        ReviewCount =  a.ReviewCount,
        CreatedAt = a.CreatedAt,
        UpdatedAt = a.UpdatedAt,
        PublishedAt = a.PublishedAt
    };
    
    
}