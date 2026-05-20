using AuthDemoApplication.DTOs.Seller;
using AuthDemoApplication.Models;
using AuthDemoApplication.Repositories.Interfaces;
using AuthDemoApplication.Services.Interfaces;

namespace AuthDemoApplication.Services;

public class SellerService : ISellerService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<SellerProfileDto> ApplyAsSellerAsync(
        string userId,
        CreateSellerProfileDto dto)
    {
        // Check they don't already have a seller profile
        var alreadyExists = await _sellerRepository.ExistsForUserAsync(userId);
        if (alreadyExists)
        {
            throw new InvalidOperationException(
                "A seller profile already exists for this user."
            );
        }

        // Map DTO → Model
        var sellerProfile = new SellerProfile
        {
            Id = Guid.NewGuid(),
            ApplicationUserId = userId,
            DisplayName = dto.DisplayName,
            Bio = dto.Bio,
            AvatarUrl = dto.AvatarUrl,
            NexusModsProfileUrl = dto.NexusModsProfileUrl,
            GitHubProfileUrl = dto.GitHubProfileUrl,
            WebsiteUrl = dto.WebsiteUrl,
            IsApproved = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var created = await _sellerRepository.CreateAsync(sellerProfile);

        // Map Model → DTO
        return MapToDto(created);
    }

    public async Task<SellerProfileDto?> GetSellerProfileAsync(string userId)
    {
        var sellerProfile = await _sellerRepository.GetByUserIdAsync(userId);
        if (sellerProfile is null) return null;
        return MapToDto(sellerProfile);
    }

    // Private mapping method — keeps mapping in one place
    private static SellerProfileDto MapToDto(SellerProfile s) => new()
    {
        Id = s.Id,
        DisplayName = s.DisplayName,
        Bio = s.Bio,
        AvatarUrl = s.AvatarUrl,
        NexusModsProfileUrl = s.NexusModsProfileUrl,
        GitHubProfileUrl = s.GitHubProfileUrl,
        WebsiteUrl = s.WebsiteUrl,
        IsApproved = s.IsApproved,
        IsFeatured = s.IsFeatured,
        TotalSales = s.TotalSales,
        CreatedAt = s.CreatedAt
    };
}