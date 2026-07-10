using AuthDemoApplication.Models;

namespace AuthDemoApplication.Repositories.Interfaces;

public interface IAssetRepository
{
    Task<Asset> CreateAsync(Asset asset);
    Task<List<Asset>> GetAllAssetsAsync();
    Task<List<Asset>> GetMostDownloadedAssetsAsync(int count);
    Task<List<Asset>> GetFeaturedAssetsAsync(int count);
    Task<(List<Asset> Items, int TotalCount)> GetPagedAssetsAsync(int pageNumber, int pageSize);
   
}