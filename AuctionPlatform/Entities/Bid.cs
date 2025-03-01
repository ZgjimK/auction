using AuctionPlatform.Enums;

namespace AuctionPlatform.Entities
{
    public class Bid : BaseEntity
    {
        #region Properties
        public decimal Amount { get; set; }
        public decimal Timestamp { get; set; }
        public BidStatus Status { get; set; }
        public int UserId { get; set; }
        public int AuctionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ChangedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ChangedBy { get; set; }

        #endregion Properties

        #region Entity-Models
        public User User { get; set; }
        public Auction Auction { get; set; }
        #endregion Entity-Models
    }
}
