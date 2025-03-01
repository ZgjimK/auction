using AuctionPlatform.Enums;

namespace AuctionPlatform.Entities
{
    public class Auction : BaseEntity
    {
        public int UserSellerId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AuctionStatus Status { get; set; } = AuctionStatus.Pending;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ChangedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ChangedBy { get; set; }
    }
}
