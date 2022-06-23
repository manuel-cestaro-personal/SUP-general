using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;

namespace SerenUP.ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryDetailController : ControllerBase
    {
        private readonly IAccessoryService _accessoryService;
        private readonly ILogger<AccessoryDetailController> _logger;

        public AccessoryDetailController(IAccessoryService accessoryService, ILogger<AccessoryDetailController> logger)
        {
            _accessoryService = accessoryService;
            _logger = logger;
        }

        [HttpGet("{name}/{color}")]
        [ProducesResponseType(200, Type = typeof(Accessory))]

        public async Task<IActionResult> GetAccessoryDetail(string name, string color)
        {
            try
            {
                Accessory accessory = await _accessoryService.GetAccessory(name, color);

                if (accessory == null)
                {
                    string message = "Prodotto non disponibile.";
                    _logger.LogInformation("API GetAccessoryDetail - " + message + " - " + DateTime.Now);
                    return StatusCode(400, new
                    {
                        Result = false,
                        ErrorMessage = message
                    });
                }
                else
                {
                    string message = $"Returned AccessoryDetail with model: {accessory.Name} and color: {accessory.Color}";
                    _logger.LogInformation("API GetAccessoryDetail - " + message + " - " + DateTime.Now);

                    return Ok(accessory); // 200
                }

            }
            catch (Exception ex)
            {
                _logger.LogInformation("API GetAccessoryDetail - " + ex.Message + " - " + DateTime.Now);
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
        }
    }
}
