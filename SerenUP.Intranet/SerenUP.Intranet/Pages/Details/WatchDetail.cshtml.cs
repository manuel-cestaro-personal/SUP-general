using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Services.Interfaces;
using System.Text;

namespace SerenUP.Intranet.Pages
{
    public class WatchDetailModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly HttpClient _clientUpdate;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WatchDetailModel> _logger;
        private readonly string WatchDetail;
        private readonly string UpdateWatch;
        private readonly string ShopAPI;
        private readonly IWatchService _watchService;
        private string _connectionString;
        [BindProperty]
        public string Model { get; set; }
        [BindProperty]
        public string Color { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        private string model_current;
        private string color_current;

        public WatchDetailModel(IConfiguration configuration, ILogger<WatchDetailModel> logger, IWatchService watchService)
        {
            _client = new HttpClient();
            _clientUpdate = new HttpClient();
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("SerenUPIntranetContextConnection");
            ShopAPI = _configuration.GetSection("HttpUrls")["ShopAPI"];
            WatchDetail = _configuration.GetSection("HttpUrls")["WatchDetail"];
            UpdateWatch = _configuration.GetSection("HttpUrls")["UpdateWatch"];
            _client.BaseAddress = new Uri(ShopAPI + WatchDetail);
            _clientUpdate.BaseAddress = new Uri(ShopAPI + UpdateWatch);
            _logger = logger;
            _watchService = watchService;
        }

        public WatchDetail Watch { get; set; }
        public string Link { get; set; }

        public async Task<IActionResult> OnGetAsync(string model, string color)
        {
        
            try
            {
                string path = model + "/" + color;
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, path);
                HttpResponseMessage response = await _client.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                    Watch = JsonConvert.DeserializeObject<WatchDetail>(content);
                    Link = "/Pictures/Orologi/" + Watch.Model + "/" + Watch.Color + ".png";
                    return Page();
                }
                    
                else
                {
                    _logger.LogInformation($"WebApp: WatchDetail page - {response.StatusCode} \n{response.RequestMessage.Method} \n{response.RequestMessage.RequestUri} \n- {DateTime.Now} - {User.Identity.Name}");
                    return RedirectToPage("./Prodotto_non_trovato");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"WebApp: WatchDetail page - {ex.Message} - {DateTime.Now} - {User.Identity.Name}");
                return RedirectToPage("/Index");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string url = HttpContext.Request.Path;
            model_current = url.Split('/')[3];
            color_current = url.Split('/')[4];
            try
            {
                var watch_current = await _watchService.GetWatch(model_current,color_current);
                Watch modello = new Watch();
                modello.Color = Color;
                modello.Model = Model;
                modello.Price = Price;
                modello.WatchStatus = watch_current.First().WatchStatus;
                modello.WatchId = watch_current.First().WatchId;
                modello.OrderId = watch_current.First().OrderId;
                modello.Link = watch_current.First().Link;
                modello.ActivationKey = watch_current.First().ActivationKey;
                modello.MacAddress = watch_current.First().MacAddress;
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, "");
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(modello);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _clientUpdate.PutAsync("", data);
                if (response.IsSuccessStatusCode)
                {

                    string content = await response.Content.ReadAsStringAsync();
                    Watch = JsonConvert.DeserializeObject<WatchDetail>(content);
                    Link = "/Pictures/Orologi/" + Watch.Model + "/" + Watch.Color + ".png";
                    return Page();
                }

                else
                {
                    _logger.LogInformation($"WebApp: WatchDetail page - {response.StatusCode} \n{response.RequestMessage.Method} \n{response.RequestMessage.RequestUri} \n- {DateTime.Now} - {User.Identity.Name}");
                    return RedirectToPage("./Prodotto_non_trovato");
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"WebApp: WatchDetail page - {ex.Message} - {DateTime.Now} - {User.Identity.Name}");
                return RedirectToPage("/Index");
            }
        }
    }
}
