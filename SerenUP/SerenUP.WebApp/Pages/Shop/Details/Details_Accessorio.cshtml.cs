using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SerenUP.WebApp.Models;

namespace SerenUP.WebApp.Pages.Shop.Details
{
    public class Details_AccessorioModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<Details_AccessorioModel> _logger;
        private readonly string accessoryDetail;
        private readonly string shopAPI;

        public Details_AccessorioModel(IConfiguration configuration, ILogger<Details_AccessorioModel> logger)
        {
            _client = new HttpClient();
            _configuration = configuration;
            shopAPI = _configuration.GetSection("HttpUrls")["ShopAPI"];
            accessoryDetail = _configuration.GetSection("HttpUrls")["AccessoryDetail"];
            _client.BaseAddress = new Uri(shopAPI + accessoryDetail);
            _logger = logger;
        }

        public AccessoryDetail Accessory { get; set; }
        public string ShipmentDate { get; set; }

        public async Task<IActionResult> OnGetAsync(string name, string color)
        {
            ShipmentDate = DateTime.Now.AddMonths(1).ToLongDateString();
            try
            {
                string path = name + "/" + color;
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, path);
                HttpResponseMessage response = await _client.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Accessory = JsonConvert.DeserializeObject<AccessoryDetail>(content);
                    Accessory.Link = "/Pictures/Accessori/" + Accessory.Name + "/" + Accessory.Color + ".png";
                    return Page();
                }
                else
                {
                    _logger.LogInformation($"WebApp: Details_Accessorio page - {response.StatusCode} \n{response.RequestMessage.Method} \n{response.RequestMessage.RequestUri} \n- {DateTime.Now} - {User.Identity.Name}");
                    return RedirectToPage("./Prodotto_non_trovato");
                    //page popup prodotto non disponibile 
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"WebApp: Details_Accessorio page - {ex.Message} - {DateTime.Now} - {User.Identity.Name}");
                return RedirectToPage("/Index");
            }
        }
    }
}
