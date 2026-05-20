using AuthDemoApplication.Models;

namespace AuthDemoApplication.Repositories.Interfaces;

public interface ISellerRepository
{
    Task<SellerProfile?> GetByUserIdAsync(string userId);
    Task<SellerProfile?> GetByIdAsync(Guid id);
    Task<bool> ExistsForUserAsync(string userId);
    Task<SellerProfile> CreateAsync(SellerProfile sellerProfile);
}
