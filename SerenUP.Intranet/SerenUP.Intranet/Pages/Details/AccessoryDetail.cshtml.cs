using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SerenUP.ApplicationCore.Entities;

namespace SerenUP.Intranet.Pages
{
    public class AccessoryDetailModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccessoryDetailModel> _logger;
        private readonly string accessoryDetail;
        private readonly string shopAPI;
        public AccessoryDetailModel(IConfiguration configuration, ILogger<AccessoryDetailModel> logger)
        {
            _client = new HttpClient();
            _configuration = configuration;
            shopAPI = _configuration.GetSection("HttpUrls")["ShopAPI"];
            accessoryDetail = _configuration.GetSection("HttpUrls")["AccessoryDetail"];
            _client.BaseAddress = new Uri(shopAPI + accessoryDetail);
            _logger = logger;
        }

        public AccessoryDetail Accessory { get; set; }
        public async Task<IActionResult> OnGetAsync(string name, string color)
        {
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
                    _logger.LogInformation($"WebApp: AccessoryDetail page - {response.StatusCode} \n{response.RequestMessage.Method} \n{response.RequestMessage.RequestUri} \n- {DateTime.Now} - {User.Identity.Name}");
                    return RedirectToPage("./Prodotto_non_trovato");
                    //page popup prodotto non disponibile 
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"WebApp: AccessoryDetail page - {ex.Message} - {DateTime.Now} - {User.Identity.Name}");
                return RedirectToPage("/Index");
            }
        }
    }
}
