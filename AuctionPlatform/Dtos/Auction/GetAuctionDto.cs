using AuctionPlatform.Enums;

namespace AuctionPlatform.Dtos.Auction
{
    public class GetAuctionDto
    {

        #region Properties

        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AuctionStatus Status { get; set; } = AuctionStatus.Pending;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        #endregion Properties

    }
}
