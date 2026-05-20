using AuthDemoApplication.Data;
using AuthDemoApplication.Models;
using AuthDemoApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthDemoApplication.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    
    public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email) is not null;
    }

    public async Task<bool> UserNameExistsAsync(string userName)
    {
        return await _userManager.FindByNameAsync(userName) is not null;
    }

    public Task<ApplicationUser?> FindByEmailAsync(string email)
    {
        return _userManager.FindByEmailAsync(email);
    }
    
    public async Task<ApplicationUser?> GetByIdAsync(string userId)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
    {
        // Use UserManager for Identity-managed fields
        await _userManager.UpdateAsync(user);
    
        // Update your custom fields directly
        user.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    
        return user;
    }
    
    
}
