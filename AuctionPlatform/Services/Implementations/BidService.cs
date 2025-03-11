using AuctionPlatform.Data;
using AuctionPlatform.Dtos.Auction;
using AuctionPlatform.Dtos.Bid;
using AuctionPlatform.Entities;
using AuctionPlatform.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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
                                             .OrderByDescending(x => x.CreatedOn)
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


        }

        #endregion Get-BidsById

        #region Get-CurrentUserByAuctionId

        public async Task<ApiResponse<IReadOnlyCollection<GetBidDto>>> GetCurrentUserByAuctionId(int auctionId, CancellationToken cancellationToken)
        {
            try
            {

                int userId = 0;

                var userBids = await _context.Bids
                                         .OrderBy(x => x.CreatedOn)
                                         .Where(x => x.AuctionId == auctionId && x.UserId == userId)
                                         .Select(a => new GetBidDto
                                         {
                                             Amount = a.Amount,
                                             FullName = a.User.UserName,
                                             CreatedOn = a.CreatedOn
                                         })
                                         .ToListAsync(cancellationToken);

                return new ApiResponse<IReadOnlyCollection<GetBidDto>>(
                                                                        data: userBids.AsReadOnly(),
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


        }

        #endregion Get-CurrentUserByAuctionId

        #region Create-Bid

        public async Task<ApiResponse<GetBidDto>> CreateBid(CreateBidDto bid, CancellationToken cancellationToken)
        {
            try
            {

                var createBid = await _context.Bids.AddAsync(new Bid
                {
                    Amount = bid.Amount,
                    UserId = bid.UserId,
                    AuctionId = bid.AuctionId,
                    Status = bid.Status,
                    StartTime = bid.StartTime,
                    EndTime = bid.EndTime,
                    CreatedOn = bid.CreatedOn,
                    ChangedOn = bid.ChangedOn,
                    CreatedBy = bid.CreatedBy,
                    ChangedBy = bid.ChangedBy,
                }, cancellationToken
                                                            );

                if (await _context.SaveChangesAsync(cancellationToken) > 0)
                {
                    return new ApiResponse<GetBidDto>(
                                                       data: new GetBidDto()
                                                       {
                                                           Amount = createBid.Entity.Amount,
                                                           FullName = createBid.Entity.User.UserName,
                                                           CreatedOn = createBid.Entity.CreatedOn
                                                       },
                                                       statusCode: HttpStatusCode.OK
                                                     );
                }
                else
                {
                    return new ApiResponse<GetBidDto>(
                                                       errorMessage: "An error occurred while creating the bid.",
                                                       statusCode: HttpStatusCode.InternalServerError
                                                     );
                }

            }
            catch (Exception e)
            {
                return new ApiResponse<GetBidDto>(
                                                   errorMessage: "An error occurred while creating the bid.",
                                                   statusCode: HttpStatusCode.InternalServerError
                                                 );
            }
        }

        #endregion Create-Bid

        #region Delete-Bid

        public async Task<ApiResponse<bool>> DeleteAsync(int bidId, CancellationToken cancellationToken)
        {
            try
            {

                var getBidById = await _context.Bids.FindAsync(bidId, cancellationToken);

                if (getBidById is null)
                    return new ApiResponse<bool>(
                                                  errorMessage: "An error occurred while creating the bid.",
                                                  statusCode: HttpStatusCode.InternalServerError
                                                );

                _context.Remove(getBidById);

                if (await _context.SaveChangesAsync(cancellationToken) > 0)
                    return new ApiResponse<bool>(
                                                  data: true,
                                                  statusCode: HttpStatusCode.OK
                                                );
                else
                    return new ApiResponse<bool>(
                                                  errorMessage: "An error occurred while creating the bid.",
                                                  statusCode: HttpStatusCode.InternalServerError
                                                );

            }
            catch (Exception e)
            {
                return new ApiResponse<bool>(
                                              errorMessage: "An error occurred while creating the bid.",
                                              statusCode: HttpStatusCode.InternalServerError
                                            );
            }
        }

        #endregion Delete-Bid
    }
}
