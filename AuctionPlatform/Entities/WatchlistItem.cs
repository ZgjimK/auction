namespace AuctionPlatform.Entities
{
    public class WatchlistItem : BaseEntity
    {
        #region Properties
        public int UserId { get; set; }
        public int AuctionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ChangedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ChangedBy { get; set; }
        #endregion

        #region Models
        public User User { get; set; }
        public Auction Auction { get; set; }
        #endregion
    }
}
