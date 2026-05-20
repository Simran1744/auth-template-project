using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthDemoApplication.Models;

namespace AuthDemoApplication.Data;

public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
   /* public DbSet<ApplicationUser> Users { get; set; } */
   //AUTH
   public DbSet<SellerProfile> SellerProfiles { get; set; }
   
   //GAME
   public DbSet<Game> Games { get; set; }
   public DbSet<Category> Categories { get; set; }
   public DbSet<GameCategory> GameCategories { get; set; }
   
   //ASSET
   public DbSet<Asset> Assets { get; set; }
   public DbSet<AssetFile> AssetFiles { get; set; }
   public DbSet<AssetPreview> AssetPreviews { get; set; }
   public DbSet<AssetTag> AssetTags { get; set; }
   public DbSet<AssetCompatibility> AssetCompatibilities { get; set; }
   
   //COMMERCIAL
   public DbSet<LicenseType> LicenseTypes { get; set; }
   public DbSet<AssetLicense> AssetLicenses { get; set; }
   public DbSet<Purchase> Purchases { get; set; }
   public DbSet<Download> Downloads { get; set; }
   
   //COMMUNITY
   public DbSet<Review> Reviews { get; set; }
   public DbSet<ReviewVote> ReviewVotes { get; set; }
   public DbSet<AssetReport> AssetReports { get; set; }
   public DbSet<Wishlist> Wishlists { get; set; }
   public DbSet<Follow> Follows { get; set; }
   public DbSet<Notification> Notifications { get; set; }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
       base.OnModelCreating(builder);

       // Composite primary key for the join table
       /*builder.Entity<GameCategory>()
           .HasKey(gc => new { gc.GameId, gc.CategoryId });*/

       // Self-referencing category relationship
       builder.Entity<Category>()
           .HasOne(c => c.ParentCategory)
           .WithMany(c => c.SubCategories)
           .HasForeignKey(c => c.ParentCategoryId)
           .OnDelete(DeleteBehavior.Restrict);
       
       // Prevent cascade delete conflicts 
       builder.Entity<Asset>()
           .HasOne(a => a.SellerProfile)
           .WithMany()
           .HasForeignKey(a => a.SellerProfileId)
           .OnDelete(DeleteBehavior.Restrict);
       
       builder.Entity<Purchase>()
           .HasOne(p => p.Buyer)
           .WithMany()
           .HasForeignKey(p => p.BuyerId)
           .OnDelete(DeleteBehavior.Restrict);

       builder.Entity<Purchase>()
           .HasOne(p => p.Asset)
           .WithMany()
           .HasForeignKey(p => p.AssetId)
           .OnDelete(DeleteBehavior.Restrict);

       builder.Entity<Purchase>()
           .HasOne(p => p.AssetLicense)
           .WithMany(al => al.Purchases)
           .HasForeignKey(p => p.AssetLicenseId)
           .OnDelete(DeleteBehavior.Restrict);
       
       // Review cascade rules
       builder.Entity<Review>()
           .HasOne(r => r.Reviewer)
           .WithMany()
           .HasForeignKey(r => r.ReviewerId)
           .OnDelete(DeleteBehavior.Restrict);

       builder.Entity<Review>()
           .HasOne(r => r.Asset)
           .WithMany()
           .HasForeignKey(r => r.AssetId)
           .OnDelete(DeleteBehavior.Restrict);

       builder.Entity<Review>()
           .HasOne(r => r.Purchase)
           .WithMany()
           .HasForeignKey(r => r.PurchaseId)
           .OnDelete(DeleteBehavior.Restrict);
       
       // ReviewVote cascade rules
       builder.Entity<ReviewVote>()
           .HasOne(rv => rv.User)
           .WithMany()
           .HasForeignKey(rv => rv.UserId)
           .OnDelete(DeleteBehavior.Restrict);

       // AssetReport cascade rules
       builder.Entity<AssetReport>()
           .HasOne(ar => ar.Reporter)
           .WithMany()
           .HasForeignKey(ar => ar.ReporterId)
           .OnDelete(DeleteBehavior.Restrict);

       // Follow cascade rules
       builder.Entity<Follow>()
           .HasOne(f => f.Follower)
           .WithMany()
           .HasForeignKey(f => f.FollowerId)
           .OnDelete(DeleteBehavior.Restrict);
   }
}
