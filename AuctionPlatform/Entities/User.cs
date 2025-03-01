using AuctionPlatform.Enums;
using Microsoft.AspNetCore.Identity;

namespace AuctionPlatform.Entities
{
    public class User : IdentityUser<int>
    {
        #region Properties

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ChangedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string ChangedBy { get; set; } = string.Empty;

        #endregion Properties

        #region Entity-Models

        public ICollection<Auction> Auctions { get; set; } = new List<Auction>();
        public ICollection<WatchlistItem> WatchlistItems { get; set; } = new List<WatchlistItem>();
        public ICollection<Bid> Bids { get; set; } = new List<Bid>();

        #endregion Entity-Models
    }
}