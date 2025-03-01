namespace AuctionPlatform.Entities
{
    public class Category : BaseEntity
    {

        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ChangedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ChangedBy { get; set; }

        #endregion Properties

        #region Entity-Models

        public ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        #endregion Entity-Models

    }
}
