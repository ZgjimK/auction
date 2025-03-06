using AuctionPlatform.Dtos.Bid;
using AuctionPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuctionPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        #region Properties

        private readonly IBidService _bidService;

        #endregion Properties

        #region Constructor

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        #endregion Constructor

        #region Endpoints

        /// <summary>
        /// Creates a new bid for an auction.
        /// </summary>
        /// <param name="bid">The bid details provided in the request body.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>
        /// An HTTP 200 OK response with the created bid details if successful. 
        /// An HTTP 400 Bad Request response if the bid creation fails due to invalid input.
        /// An HTTP 500 Internal Server Error response if an unexpected error occurs during processing.
        /// </returns>
        [HttpGet("GetBidsById/{id}")]
        public async Task<IActionResult> GetBidsById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _bidService.GetBidsById(id, cancellationToken);

                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error occurred while processing the request.");
            }
        }

        /// <summary>
        /// Creates a new bid for an auction.
        /// </summary>
        /// <param name="bid">The bid details provided in the request body.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>
        /// An HTTP 200 OK response with the created bid details if successful. 
        /// An HTTP 400 Bad Request response if the bid creation fails due to invalid input.
        /// An HTTP 500 Internal Server Error response if an unexpected error occurs during processing.
        /// </returns>
        [HttpGet("GetCurrentUserByAuctionId/{id}")]
        public async Task<IActionResult> GetCurrentUserByAuctionId(int id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _bidService.GetCurrentUserByAuctionId(id, cancellationToken);

                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error occurred while processing the request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBid([FromBody] CreateBidDto bid, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _bidService.CreateBid(bid, cancellationToken);

                if (response.Success)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error occurred while processing the request.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int bidId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _bidService.DeleteAsync(bidId, cancellationToken);

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
