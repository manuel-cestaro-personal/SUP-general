using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;

namespace SerenUP.ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> InsertCart([FromBody] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    Cart model = new Cart();

                    Guid cartId = Guid.NewGuid();
                    model.Id = cartId;
                    model.UserId = userId;

                    await _cartService.InsertCart(model);
                    return Ok(new
                    {
                        Result = true
                    }); // 200
                }

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
    }
}
