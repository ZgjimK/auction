using AuctionPlatform.Data;
using AuctionPlatform.Dtos.Auction;
using AuctionPlatform.Dtos.Bid;

namespace AuctionPlatform.Services.Interfaces
{
    public interface IBidService
    {
        Task<ApiResponse<IReadOnlyCollection<GetBidDto>>> GetBidsById(int auctionId, CancellationToken cancellationToken);
        Task<ApiResponse<GetBidDto>> CreateBid(CreateBidDto bid, CancellationToken cancellationToken);
        Task<ApiResponse<bool>> DeleteAsync(int bidId, CancellationToken cancellationToken);
    }
}
