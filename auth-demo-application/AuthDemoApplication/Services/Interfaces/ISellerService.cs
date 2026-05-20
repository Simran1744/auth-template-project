using AuthDemoApplication.DTOs.Seller;

namespace AuthDemoApplication.Services.Interfaces;

public interface ISellerService
{
    Task<SellerProfileDto> ApplyAsSellerAsync(
        string userId, 
        CreateSellerProfileDto dto
    );
    Task<SellerProfileDto?> GetSellerProfileAsync(string userId);
}