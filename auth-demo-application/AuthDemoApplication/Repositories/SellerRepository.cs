using AuthDemoApplication.Data;
using AuthDemoApplication.Models;
using AuthDemoApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthDemoApplication.Repositories;

public sealed class SellerRepository : ISellerRepository
{
    private readonly ApplicationDbContext _context;

    public SellerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SellerProfile?> GetByUserIdAsync(string userId)
    {
        return await _context.SellerProfiles
            .FirstOrDefaultAsync(s => s.ApplicationUserId == userId);
    }

    public async Task<SellerProfile?> GetByIdAsync(Guid id)
    {
        return await _context.SellerProfiles
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<bool> ExistsForUserAsync(string userId)
    {
        return await _context.SellerProfiles
            .AnyAsync(s => s.ApplicationUserId == userId);
    }

    public async Task<SellerProfile> CreateAsync(SellerProfile sellerProfile)
    {
        _context.SellerProfiles.Add(sellerProfile);
        await _context.SaveChangesAsync();
        return sellerProfile;
    }
}