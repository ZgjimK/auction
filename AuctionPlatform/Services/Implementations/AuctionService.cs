using AuctionPlatform.Data;
using AuctionPlatform.Dtos.Auction;
using AuctionPlatform.Dtos.Watchlist;
using AuctionPlatform.Entities;
using AuctionPlatform.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AuctionPlatform.Services.Implementations
{
    public class AuctionService : IAuctionService
    {

        #region Properties

        private readonly AuctionPlatformDbContext _context;

        #endregion Properties

        #region Constructor

        public AuctionService(AuctionPlatformDbContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Get-AllAuctionAsync

        public async Task<ApiResponse<IReadOnlyCollection<GetAuctionDto>>> GetAllAuctionAsync(CancellationToken cancellationToken)
        {
            try
            {
                var auctions = await _context.Auctions
                                             .OrderBy(x => x.CreatedOn)
                                             .Include(a => a.Category)
                                             .Select(a => new GetAuctionDto
                                             {
                                                 CategoryName = a.Category.Name,
                                                 Name = a.Name,
                                                 Description = a.Description,
                                                 Price = a.Price,
                                                 Status = a.Status,
                                                 StartTime = a.StartTime,
                                                 EndTime = a.EndTime
                                             })
                                             .ToListAsync(cancellationToken);

                return new ApiResponse<IReadOnlyCollection<GetAuctionDto>>(
                                                                            data: auctions.AsReadOnly(),
                                                                            statusCode: HttpStatusCode.OK
                                                                          );
            }
            catch (Exception e)
            {
                return new ApiResponse<IReadOnlyCollection<GetAuctionDto>>(
                                                                            errorMessage: "An error occurred while retrieving auctions.",
                                                                            statusCode: HttpStatusCode.InternalServerError
                                                                          );
            }
        }

        #endregion Get-AllAuctionAsync

        #region Create-AuctionWatchlistItem

        public async Task<ApiResponse<bool>> CreateAuctionWatchlistItemAsync(CreateWatchlistDto watchlistDto, CancellationToken cancellationToken)
        {
            try
            {
                var auctions = await _context.WatchlistItems
                                             .AddAsync(new WatchlistItem
                                             {
                                                 UserId = watchlistDto.UserId,
                                                 AuctionId = watchlistDto.AuctionId
                                             }, cancellationToken);

                if (await _context.SaveChangesAsync(cancellationToken) > 0)
                {


                    return new ApiResponse<bool>(
                                                  data: true,
                                                  statusCode: HttpStatusCode.OK
                                                );

                }
                else
                {
                    return new ApiResponse<bool>(
                                                  errorMessage: "An error occurred while creating watchlist.",
                                                  statusCode: HttpStatusCode.ExpectationFailed
                                                );
                }
            }
            catch (Exception e)
            {
                return new ApiResponse<bool>(
                                              errorMessage: "An error occurred while retrieving auctions.",
                                              statusCode: HttpStatusCode.InternalServerError
                                            );
            }
        }

        #endregion Create-AuctionWatchlistItem

        #region Delete-AuctionWatchlistItem

        public async Task<ApiResponse<bool>> DeleteAuctionWatchlistItemAsync(int id, CancellationToken cancellationToken)
        {
            try
            {

                var watchlistItem = await _context.WatchlistItems
                                                  .FindAsync(id, cancellationToken);

                var auctions = _context.WatchlistItems
                                       .Remove(watchlistItem);

                if (await _context.SaveChangesAsync(cancellationToken) > 0)
                {
                    return new ApiResponse<bool>(
                                                  data: true,
                                                  statusCode: HttpStatusCode.OK
                                                );

                }
                else
                {
                    return new ApiResponse<bool>(
                                                  errorMessage: "An error occurred while creating watchlist.",
                                                  statusCode: HttpStatusCode.ExpectationFailed
                                                );
                }
            }
            catch (Exception e)
            {
                return new ApiResponse<bool>(
                                              errorMessage: "An error occurred while retrieving auctions.",
                                              statusCode: HttpStatusCode.InternalServerError
                                            );
            }
        }

        #endregion Delete-AuctionWatchlistItem

    }
}
