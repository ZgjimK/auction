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
        /// Gets all auctions.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of auctions or an error response.</returns>
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

        #endregion Endpoints
    }
}
