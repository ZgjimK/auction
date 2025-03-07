using AuctionPlatform.Data;
using AuctionPlatform.Dtos.Auction;
using AuctionPlatform.Dtos.Watchlist;

namespace AuctionPlatform.Services.Interfaces
{
    public interface IAuctionService
    {
        Task<ApiResponse<IReadOnlyCollection<GetAuctionDto>>> GetAllAuctionAsync(CancellationToken cancellationToken);

        Task<ApiResponse<bool>> CreateAuctionWatchlistItemAsync(CreateWatchlistDto watchlistDto, CancellationToken cancellationToken);
    }
}
