using AuctionPlatform.Data;
using AuctionPlatform.Dtos.Auction;
using AuctionPlatform.Dtos.Bid;
using AuctionPlatform.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AuctionPlatform.Services.Implementations
{
    public class BidService : IBidService
    {

        #region Properties

        private readonly AuctionPlatformDbContext _context;

        #endregion Properties

        #region Constructor

        public BidService(AuctionPlatformDbContext context)
        {
            _context = context;
        }

        #endregion Constructor


        #region Get-BidsById
        public async Task<ApiResponse<IReadOnlyCollection<GetBidDto>>> GetBidsById(int auctionId, CancellationToken cancellationToken)
        {


            try
            {
                var auctions = await _context.Bids
                                             .Include(x => x.User)
                                             .OrderBy(x => x.CreatedOn)
                                             .Where(x => x.AuctionId == auctionId)
                                             .Select(a => new GetBidDto
                                             {
                                                 Amount = a.Amount,
                                                 FullName = a.User.UserName,
                                                 CreatedOn = a.CreatedOn
                                             })
                                             .ToListAsync(cancellationToken);

                return new ApiResponse<IReadOnlyCollection<GetBidDto>>(
                                                                        data: auctions.AsReadOnly(),
                                                                        statusCode: HttpStatusCode.OK
                                                                      );
            }
            catch (Exception e)
            {
                return new ApiResponse<IReadOnlyCollection<GetBidDto>>(
                                                                        errorMessage: "An error occurred while retrieving auctions.",
                                                                        statusCode: HttpStatusCode.InternalServerError
                                                                      );
            }


            #endregion Get-BidsById
        }
    }
}
