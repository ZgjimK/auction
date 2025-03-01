using AuctionPlatform.Enums;

namespace AuctionPlatform.Entities
{
    public class Auction : BaseEntity
    {

        #region Properties

        public int UserSellerId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AuctionStatus Status { get; set; } = AuctionStatus.Pending;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ChangedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ChangedBy { get; set; }

        #endregion Properties

        #region Entity-Models

        public ICollection  <Bid> Bids { get; set; } = new List<Bid>();
        public ICollection<WatchlistItem> WatchlistItems { get; set; } = new List<WatchlistItem>();
        public Category Category { get; set; }
        public User User { get; set; }

        #endregion Entity-Models
    }
}
