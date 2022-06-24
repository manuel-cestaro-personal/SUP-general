using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;

namespace SerenUP.ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchDetailController : ControllerBase
    {
        private readonly IWatchService _watchService;
        private readonly ILogger<WatchDetailController> _logger;

        public WatchDetailController(IWatchService watchService, ILogger<WatchDetailController> logger)
        {
            _watchService = watchService;
            _logger = logger;
        }


        [HttpGet("GetAllWatch")]
        [ProducesResponseType(200, Type = typeof(Accessory))]
        public async Task<IActionResult> GetAllWatch()
        {

            try
            {
                IEnumerable<Watch> WatchList = await _watchService.GetAllWatch();

                if (WatchList.Count() == 0)
                {
                    string message = "Prodotti non disponibile.";
                    _logger.LogInformation("API GetWatch - " + message + " - " + DateTime.Now);
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

                    return Ok(await _watchService.GetAllWatch()); // 200
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

        [HttpGet("{model}/{color}")]
        [ProducesResponseType(200, Type = typeof(WatchDetail))]
        public async Task<IActionResult> GetWatchDetail(string model, string color)
        {
            try
            {
                IEnumerable<Watch> watchList = await _watchService.GetWatch(model, color);

                if (watchList.Count() == 0)
                {
                    string message = "Prodotto non disponibile.";
                    _logger.LogInformation("API GetWatchDetail - " + message + " - " + DateTime.Now);
                    return StatusCode(400, new
                    {
                        Result = false,
                        ErrorMessage = message
                    });
                }
                else
                {
                    WatchDetail res = new WatchDetail()
                    {
                        Quantity = watchList.Count(),
                        Price = watchList.First().Price,
                        Model = watchList.First().Model,
                        Color = watchList.First().Color
                    };
                    string message = $"Returned Watchdetail with model: {res.Model} and color: {res.Color}";
                    _logger.LogInformation("API GetWatchDetail - " + message + " - " + DateTime.Now);

                    return Ok(res); // 200
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


        [HttpPost("InsertWatch")]
        public async Task<IActionResult> InsertWatch(Watch model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    Watch watch = new Watch()
                    {
                        Id = model.Id,
                        Model = model.Model,
                        Price = model.Price,
                        MacAddress = model.MacAddress,
                        ActivationKey = model.ActivationKey,
                        Color = model.Color
                    };
                    await _watchService.InsertWatch(model);

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