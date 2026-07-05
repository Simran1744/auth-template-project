using AuthDemoApplication.Models;

namespace AuthDemoApplication.Repositories.Interfaces;

public interface IAssetRepository
{
    Task<Asset> CreateAsync(Asset asset);
    Task<List<Asset>> GetAllAssetsAsync();
}