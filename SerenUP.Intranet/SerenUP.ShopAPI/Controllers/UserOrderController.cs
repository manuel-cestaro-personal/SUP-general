using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;

namespace SerenUP.ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<UserOrderController> _logger;

        public UserOrderController(IOrderService orderService, ILogger<UserOrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        public async Task<IActionResult> GetUserOrder(Guid id)
        {
            try
            {
                IEnumerable<Order> orderList = await _orderService.GetByUserId(id);

                if (orderList.Count() == 0)
                {
                    string message = "Nessun ordine per l'utente.";
                    _logger.LogInformation("API GetWatchDetail - " + message + " - " + DateTime.Now);
                    return StatusCode(400, new
                    {
                        Result = false,
                        ErrorMessage = message
                    });
                }
                else
                {
                    // string message = $"Returned Watchdetail with model: {res.Model} and color: {res.Color}";
                    // _logger.LogInformation("API GetWatchDetail - " + message + " - " + DateTime.Now);
                    return Ok(await _orderService.GetByUserId(id));
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("API GetWatchDetail - " + ex.Message + " - " + DateTime.Now);
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
        }
    }
}
