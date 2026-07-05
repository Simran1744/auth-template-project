using AuthDemoApplication.Models;

namespace AuthDemoApplication.Repositories.Interfaces;

public interface IGameRepository
{
    Task<Game?> GetGameByNameAsync(string name);
}