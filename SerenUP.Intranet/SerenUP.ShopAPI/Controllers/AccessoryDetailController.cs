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

        [HttpGet("GetAllAccessory")]
        [ProducesResponseType(200, Type = typeof(Accessory))]
        public async Task<IActionResult> GetAllAccessory()
        {

            try
            {
                IEnumerable<Accessory> AccessoryList = await _accessoryService.GetAllAccessory();

                if (AccessoryList.Count() == 0)
                {
                    string message = "Prodotti non disponibile.";
                    _logger.LogInformation("API GetAllAccessory - " + message + " - " + DateTime.Now);
                    return StatusCode(400, new
                    {
                        Result = false,
                        ErrorMessage = message
                    });
                }
                else
                {
                    //string message = $"Returned GetAllAccessory with name: {res.Name} and color: {res.Color}";
                    //_logger.LogInformation("API GetAllAccessory - " + message + " - " + DateTime.Now);

                    return Ok(await _accessoryService.GetAllAccessory()); // 200
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("API GetAllAccessory- " + ex.Message + " - " + DateTime.Now);
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
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

        [HttpPost("InsertAccessory")]

        public async Task<IActionResult> InsertAccessory(Accessory model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    Accessory accessory = new Accessory()
                    {
                        AccessoryId = model.AccessoryId,
                        Name = model.Name,
                        Price = model.Price,
                        Description = model.Description,
                        Color = model.Color,
                        Quantity = model.Quantity
                    };
                    await _accessoryService.InsertAccessory(model);

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

        [HttpPut("UpdateAccessoryQuantity")]
        public async Task<IActionResult> UpdateAccessory(Accessory model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    await _accessoryService.UpdateAccessory(model);

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
