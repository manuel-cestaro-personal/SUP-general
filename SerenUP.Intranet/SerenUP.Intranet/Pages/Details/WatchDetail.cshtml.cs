using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SerenUP.ApplicationCore.Entities;

namespace SerenUP.Intranet.Pages
{
    public class WatchDetailModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WatchDetailModel> _logger;
        private readonly string WatchDetail;
        private readonly string ShopAPI;

        public WatchDetailModel(IConfiguration configuration, ILogger<WatchDetailModel> logger)
        {
            _client = new HttpClient();
            _configuration = configuration;
            ShopAPI = _configuration.GetSection("HttpUrls")["ShopAPI"];
            WatchDetail = _configuration.GetSection("HttpUrls")["WatchDetail"];
            _client.BaseAddress = new Uri(ShopAPI + WatchDetail);
            _logger = logger;
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
    }
}
