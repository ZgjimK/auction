using AuctionPlatform.Enums;

namespace AuctionPlatform.Dtos.Bid
{
    public class GetBidDto
    {

        #region Properties

        public decimal Amount { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        #endregion Properties

    }
}
