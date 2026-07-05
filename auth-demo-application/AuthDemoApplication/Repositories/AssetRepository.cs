using AuthDemoApplication.Data;
using AuthDemoApplication.Models;
using AuthDemoApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthDemoApplication.Repositories;

public sealed class AssetRepository : IAssetRepository
{
    private readonly ApplicationDbContext _context;

    public AssetRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Asset> CreateAsync(Asset asset)
    {
        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();
        return asset;
    }

    public async Task<List<Asset>> GetAllAssetsAsync()
    {
        return await _context.Assets
            .AsNoTracking()
            .OrderByDescending(a => a.CreatedAt)
            .Take(100)
            .ToListAsync();
    }
}