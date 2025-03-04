using AuctionPlatform.Enums;

namespace AuctionPlatform.Dtos.Bid
{
    public class CreateBidDto
    {
        public decimal Amount { get; set; }
        public BidStatus Status { get; set; }
        public int UserId { get; set; }
        public int AuctionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ChangedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ChangedBy { get; set; }
    }
}
