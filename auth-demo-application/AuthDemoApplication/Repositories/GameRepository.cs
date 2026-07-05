using AuthDemoApplication.Data;
using AuthDemoApplication.Models;
using AuthDemoApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthDemoApplication.Repositories;

public sealed class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext _context;
    public GameRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Game?> GetGameByNameAsync(string name)
    {
        return await _context.Games
            .FirstOrDefaultAsync(s => s.Name == name);
    }
}