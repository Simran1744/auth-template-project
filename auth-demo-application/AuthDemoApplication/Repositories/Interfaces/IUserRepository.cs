using AuthDemoApplication.Models;

namespace AuthDemoApplication.Repositories.Interfaces;

public interface IUserRepository
{
    Task<bool> EmailExistsAsync(string email);

    Task<bool> UserNameExistsAsync(string userName);

    Task<ApplicationUser?> FindByEmailAsync(string email);
}
