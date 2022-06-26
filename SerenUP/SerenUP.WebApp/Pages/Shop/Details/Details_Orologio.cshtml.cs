using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SerenUP.WebApp.Models;

namespace SerenUP.WebApp.Pages.Shop.Details
{
    public class Details_OrologioModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Details_OrologioModel> _logger;
        private readonly string WatchDetail;
        private readonly string ShopAPI;

        public Details_OrologioModel(IConfiguration configuration, ILogger<Details_OrologioModel> logger)
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
        public string ShipmentDate { get; set; }

        public async Task<IActionResult> OnGetAsync(string model, string color)
        {
            ShipmentDate = DateTime.Now.AddMonths(1).ToLongDateString();
            try
            {
                string path = model + "/" + color;
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, path);
                HttpResponseMessage response = await _client.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Watch = JsonConvert.DeserializeObject<WatchDetail>(content);
                    Link = "../Pictures/Orologi/"+Watch.Model+"/"+Watch.Color+".png";
                    return Page();
                }
                else
                {
                    _logger.LogInformation($"WebApp: Details_Orologio page - {response.StatusCode} \n{response.RequestMessage.Method} \n{response.RequestMessage.RequestUri} \n- {DateTime.Now} - {User.Identity.Name}");
                    return RedirectToPage("./Prodotto_non_trovato");
                    //page popup prodotto non disponibile 
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"WebApp: Details_Orologio page - {ex.Message} - {DateTime.Now} - {User.Identity.Name}");
                return RedirectToPage("/Index");
            }
        }
    }
}
