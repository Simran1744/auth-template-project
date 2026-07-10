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
            .Include(a => a.Game)
            .OrderByDescending(a => a.CreatedAt)
            .Take(100)
            .ToListAsync();
    }

    public async Task<List<Asset>> GetMostDownloadedAssetsAsync(int count)
    {
        return await _context.Assets
            .AsNoTracking()
            .Include(a => a.Game)
            .OrderByDescending(a => a.TotalDownloads)
            .Take(count)
            .ToListAsync();
    }

    public async Task<List<Asset>> GetFeaturedAssetsAsync(int count)
    {
        return await _context.Assets
            .AsNoTracking()
            .Include(a => a.Game)
            .Where(a => a.IsFeatured)
            .OrderByDescending(a => a.CreatedAt)
            .Take(count)
            .ToListAsync();
    }

    public async Task<(List<Asset> Items, int TotalCount)> GetPagedAssetsAsync(int pageNumber, int pageSize)
    {

        var query = _context.Assets
            .AsNoTracking();

        // 1. Get total count for the pagination calculations
        var totalCount = await query.CountAsync();
        
        //Console.WriteLine($"Total Count: {totalCount}");
        //Console.WriteLine($"Page Number: {pageNumber}");

        // 2. Fetch the specific slice
        var items = await query
            .Include(a => a.Game)
            .OrderByDescending(a => a.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        

        return (items, totalCount);
    }
    
    
    
    
}