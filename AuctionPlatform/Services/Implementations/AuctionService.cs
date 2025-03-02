using AuctionPlatform.Data;
using AuctionPlatform.Dtos;
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

        public async Task<ApiResponse<IReadOnlyCollection<GetAuctionDto>>> GetAllAuctionAsync(CancellationToken cancellationToken)
        {
            try
            {
                var auctions = await _context.Auctions
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

        #endregion Constructor

    }
}
