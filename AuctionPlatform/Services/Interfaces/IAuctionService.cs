﻿using AuctionPlatform.Data;
using AuctionPlatform.Dtos.Auction;

namespace AuctionPlatform.Services.Interfaces
{
    public interface IAuctionService
    {
        Task<ApiResponse<IReadOnlyCollection<GetAuctionDto>>> GetAllAuctionAsync(CancellationToken cancellationToken);
    }
}
