using AuctionPlatform.Data;
using AuctionPlatform.Dtos.Auction;
using AuctionPlatform.Dtos.Bid;

namespace AuctionPlatform.Services.Interfaces
{
    public interface IBidService
    {
        Task<ApiResponse<IReadOnlyCollection<GetBidDto>>> GetBidsById(int auctionId, CancellationToken cancellationToken);
    }
}
