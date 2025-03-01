using AuctionPlatform.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionPlatform.Data
{
    public class AuctionPlatformDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<WatchlistItem> WatchlistItems { get; set; }

        public AuctionPlatformDbContext(DbContextOptions<AuctionPlatformDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Auction Entity
            modelBuilder.Entity<Auction>(entity =>
            {
                entity.HasKey(a => a.Id); // Primary Key

                // Relationships
                entity.HasOne(a => a.User) // One-to-Many relationship with User (Seller)
                      .WithMany(u => u.Auctions) // Navigation property in User class
                      .HasForeignKey(a => a.UserSellerId)
                      .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of User if Auctions exist

                entity.HasOne(a => a.Category) // One-to-Many relationship with Category
                      .WithMany(c => c.Auctions) // Navigation property in Category class
                      .HasForeignKey(a => a.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Prevent deletion of Category if Auctions exist
            });

            // Configure Bid Entity
            modelBuilder.Entity<Bid>(entity =>
            {
                entity.HasKey(b => b.Id); // Primary Key

                // Relationships
                entity.HasOne(b => b.User) // One-to-Many relationship with User
                      .WithMany(u => u.Bids) // Navigation property in User class
                      .HasForeignKey(b => b.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Delete Bid if User is deleted

                entity.HasOne(b => b.Auction) // One-to-Many relationship with Auction
                      .WithMany(a => a.Bids) // Navigation property in Auction class
                      .HasForeignKey(b => b.AuctionId)
                      .OnDelete(DeleteBehavior.Cascade); // Delete Bid if Auction is deleted
            });

            // Configure Category Entity
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id); // Primary Key

                // Relationships (Auctions are already configured above)
            });

            // Configure WatchlistItem Entity
            modelBuilder.Entity<WatchlistItem>(entity =>
            {
                entity.HasKey(w => w.Id); // Primary Key

                // Relationships
                entity.HasOne(w => w.User) // One-to-Many relationship with User
                      .WithMany(u => u.WatchlistItems) // Navigation property in User class
                      .HasForeignKey(w => w.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Delete WatchlistItem if User is deleted

                entity.HasOne(w => w.Auction) // One-to-Many relationship with Auction
                      .WithMany(a => a.WatchlistItems) // Navigation property in Auction class
                      .HasForeignKey(w => w.AuctionId)
                      .OnDelete(DeleteBehavior.Cascade); // Delete WatchlistItem if Auction is deleted
            });
        }
    }
}
