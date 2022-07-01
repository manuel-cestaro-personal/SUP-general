using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;

namespace SerenUP.ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartWatchController : ControllerBase
    {
        private readonly ICartWatchService _cartWatchService;
        private readonly ILogger<WatchDetailController> _logger;

        public CartWatchController(ICartWatchService cartWatchService, ILogger<WatchDetailController> logger)
        {
            _cartWatchService = cartWatchService;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatch(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("API CartWatch - " + ModelState + " - " + DateTime.Now);
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    await _cartWatchService.DeleteWatch(id);
                    return Ok();  //200
                }

            }
            catch(Exception ex)
            {
                _logger.LogInformation("API CartWatch - " + ex.Message + " - " + DateTime.Now);
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
        }
    }
}
