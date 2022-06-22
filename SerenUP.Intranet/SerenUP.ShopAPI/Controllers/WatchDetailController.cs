using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entities;
using SerenUP.ApplicationCore.Entitiess;
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
    }
}