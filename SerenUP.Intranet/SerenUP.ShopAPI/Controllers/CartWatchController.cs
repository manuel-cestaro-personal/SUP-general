using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;

namespace SerenUP.ShopAPI.Controllers { 

    [Route("api/[controller]")]
    [ApiController]
    public class CartWatchController : Controller
    {
        private readonly ICartWatchService _cartWatchService;
        private readonly ICartService _cartService;
        private readonly ILogger<CartWatchController> _logger;

        public CartWatchController(
            ICartWatchService cartWatchService,
            ILogger<CartWatchController> logger,
            ICartService cartService)
        {
            _cartWatchService = cartWatchService;
            _logger = logger;
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Watch>))]
        public async Task<IActionResult> GetWatchByUser(Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("API CartWatch GetWatchByUser - " + ModelState + " - " + DateTime.Now);
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    Guid cartId = await _cartService.FindCartId(userId);
                    if (cartId != new Guid())
                    {
                        IEnumerable<Watch> res = await _cartWatchService.GetByCartId(cartId);
                        string message;
                        if (res != null)
                        {
                            message = $"Returned Accessory list of the user: {userId} from the cart: {cartId}";
                        }
                        else
                        {
                            message = $"Returned Accessory list EMPTY of the user: {userId} from the cart: {cartId}";
                        }
                        _logger.LogInformation("API CartWatch GetWatchByUser - " + message + " - " + DateTime.Now);
                        return Ok(res); // 200
                    }
                    else
                    {
                        _logger.LogInformation(cartId.ToString());
                        string message = $"Invalid UserId inserted";
                        _logger.LogInformation("API CartWatch GetWatchByUser - " + message + " - " + DateTime.Now);
                        return StatusCode(400, new
                        {
                            Result = false,
                            ErrorMessage = message
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("API CartWatch GetWatchByUser - " + ex.Message + " - " + DateTime.Now);

                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
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

