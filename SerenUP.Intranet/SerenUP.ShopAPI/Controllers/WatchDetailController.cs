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
        [ProducesResponseType(200, Type = typeof(Watch))]
        public async Task<IActionResult> GetAllWatch()
        {

            try
            {
                IEnumerable<Watch> WatchList = await _watchService.GetAllWatch();

                if (WatchList.Count() == 0)
                {
                    string message = "Orologio non disponibile.";
                    _logger.LogInformation("API GetAllWatch - " + message + " - " + DateTime.Now);
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
                _logger.LogInformation("API GetAllWatch - " + ex.Message + " - " + DateTime.Now);

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
                        WatchId = model.WatchId,
                        Model = model.Model,
                        Price = model.Price,
                        MacAddress = model.MacAddress,
                        ActivationKey = model.ActivationKey,
                        Color = model.Color,
                        WatchStatus = model.WatchStatus
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
        [HttpPut("UpdateWatchStatus")]

        public async Task<IActionResult> UpdateWatch(Guid id, bool status) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    await _watchService.UpdateWatch(id, status);
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

        [HttpPut("UpdateWatchDetail")]

        public async Task<IActionResult> UpdateWatchDetail(Watch model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // 400
                }
                else
                {
                    await _watchService.UpdateWatchDetail(model);
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


        [HttpGet("WatchActivate {id}/{activationKey}")]
        public async Task<IActionResult> WatchActivate(Guid id, Guid activationKey)
        {

            try
            {
                IEnumerable<Watch> idList = await _watchService.WatchActivate(id,activationKey);

                if (idList.Count() == 0)
                {
                    string message = "Activation Key non trovata";
                    _logger.LogInformation("API ActivationWatch - " + message + " - " + DateTime.Now);
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
                    Watch watch = new Watch();
                    watch.WatchId = id;
                    watch.WatchStatus = true;
                    await _watchService.UpdateWatch(watch.WatchId, watch.WatchStatus);
                    return Ok(await _watchService.WatchActivate(id, activationKey)); // 200
                    
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("API ActivationWatch - " + ex.Message + " - " + DateTime.Now);

                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = "SERVER ERROR! Contact the system administrator."
                });
            }
        }
    }
}