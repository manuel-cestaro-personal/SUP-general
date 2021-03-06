using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;

namespace SerenUP.ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartAccessoryController : Controller
    {
        private readonly ICartAccessoryService _cartAccessoryService;
        private readonly ICartService _cartService;
        private readonly ILogger<WatchDetailController> _logger;

        public CartAccessoryController(
            ICartAccessoryService cartAccessoryService,
            ILogger<WatchDetailController> logger,
            ICartService cartService)
        {
            _cartAccessoryService = cartAccessoryService;
            _logger = logger;
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Accessory>))]
        public async Task<IActionResult> GetAccessoryByUser(Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("API CartAccessory GetAccessoryByUser - " + ModelState + " - " + DateTime.Now);
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    Guid cartId = await _cartService.FindCartId(userId);
                    if (cartId != new Guid())
                    {
                        IEnumerable<Accessory> res = await _cartAccessoryService.GetByCartId(cartId);
                        string message;
                        if (res != null)
                        {
                            message = $"Returned Accessory list of the user: {userId} from the cart: {cartId}";
                        }
                        else
                        {
                            message = $"Returned Accessory list EMPTY of the user: {userId} from the cart: {cartId}";
                        }
                        _logger.LogInformation("API CartAccessory GetAccessoryByUser - " + message + " - " + DateTime.Now);
                        return Ok(res); // 200
                    }
                    else
                    {
                        _logger.LogInformation(cartId.ToString());
                        string message = $"Invalid UserId inserted";
                        _logger.LogInformation("API CartAccessory GetAccessoryByUser - " + message + " - " + DateTime.Now);
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
                _logger.LogInformation("API CartAccessory GetAccessoryByUser - " + ex.Message + " - " + DateTime.Now);
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
        }

        [HttpPut("UpdateQuantity/{id}/{quantity}")]
        public async Task<IActionResult> UpdateQuantityCartAccessory(Guid id, int quantity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("API CartAccessory - " + ModelState + " - " + DateTime.Now);
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    await _cartAccessoryService.UpdateCartAccessory(id, quantity);
                }
                return Ok(new
                {
                    Result = true
                }); // 200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessory(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("API CartAccessory - " + ModelState + " - " + DateTime.Now);
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    await _cartAccessoryService.DeleteAccessory(id);
                    return Ok();  //200
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("API CartAccessory - " + ex.Message + " - " + DateTime.Now);
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
        }
    }
}
