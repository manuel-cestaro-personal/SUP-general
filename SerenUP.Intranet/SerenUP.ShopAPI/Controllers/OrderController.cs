using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;

namespace SerenUP.ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService OrderService, ILogger<OrderController> logger)
        {
            _orderService = OrderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            try
            {
                IEnumerable<Order> order = await _orderService.GetAllOrder();

                if (order.Count() == 0)
                {
                    string message = "Non ci sono ordini in corso";
                    _logger.LogInformation("API GetAllOrder - " + message + " - " + DateTime.Now);
                    return StatusCode(400, new
                    {
                        Result = false,
                        ErrorMessage = message
                    });
                }
                else
                {
                    string message = $"Returned GetOrder";
                    _logger.LogInformation("API GetAllOrder - " + message + " - " + DateTime.Now);

                    return Ok(await _orderService.GetAllOrder()); // 200
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("API GetAllOrder - " + ex.Message + " - " + DateTime.Now);
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
        }


        [HttpPut("UpdateStatusOrder")]
        public async Task<IActionResult> UpdateStatusOrder(Guid id, string status)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    await _orderService.UpdateStatus(id, status);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("API UpdateStatus - " + ex.Message + " - " + DateTime.Now);
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
        }
    }
}
