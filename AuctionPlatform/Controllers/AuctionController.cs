using AuctionPlatform.Data;
using AuctionPlatform.Dtos.Bid;
using AuctionPlatform.Dtos.Watchlist;
using AuctionPlatform.Services.Implementations;
using AuctionPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuctionPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {

        #region Properties

        private readonly IAuctionService _auctionService;

        #endregion Properties

        #region Constructor

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        #endregion Constructor

        #region Endpoints

        /// <summary>
        /// Gets all auctions.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of auctions or an error response.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAuctionsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _auctionService.GetAllAuctionAsync(cancellationToken);

                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error occurred while processing the request.");
            }
        }

        [HttpPost("CreateWatchlistItem")]
        public async Task<IActionResult> CreateWatchlistItem([FromBody] CreateWatchlistDto watchlist, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _auctionService.CreateAuctionWatchlistItemAsync(watchlist, cancellationToken);

                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error occurred while processing the request.");
            }
        }

        [HttpDelete("DeleteWatchlistItem/{id:int}")]
        public async Task<IActionResult> DeleteWatchlistItem([FromQuery] int id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _auctionService.DeleteAuctionWatchlistItemAsync(id, cancellationToken);

                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error occurred while processing the request.");
            }
        }

        #endregion Endpoints
    }

}
