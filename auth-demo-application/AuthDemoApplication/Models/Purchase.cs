namespace AuthDemoApplication.Models;

public sealed class Purchase
{
    public Guid Id { get; set; }
    public decimal AmountPaid { get; set; }
    public string Currency { get; set; } = "EUR";
    public decimal PlatformFee { get; set; }
    public decimal SellerPayout { get; set; }
    public string? StripePaymentIntentId { get; set; }
    public PurchaseStatus Status { get; set; } = PurchaseStatus.Pending;
    public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;

    // Foreign keys
    public string BuyerId { get; set; } = string.Empty;
    public Guid AssetId { get; set; }
    public Guid AssetLicenseId { get; set; }

    // Navigation
    public ApplicationUser Buyer { get; set; } = null!;
    public Asset Asset { get; set; } = null!;
    public AssetLicense AssetLicense { get; set; } = null!;
    public ICollection<Download> Downloads { get; set; } = [];
}

public enum PurchaseStatus
{
    Pending,
    Completed,
    Refunded,
    Disputed
}