using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SerenUP.ApplicationCore.Entities;
using SerenUP.Intranet.Data;

namespace SerenUP.Intranet.Pages
{
    //[Authorize]
    public class ProductListModel : PageModel
    {
        private readonly ILogger<ProductListModel> _logger;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly string ShopAPI;
        private readonly string GetAccessory;
        private readonly string GetWatch;

        public ProductListModel(UserManager<ApplicationUser> userManager, ILogger<ProductListModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _client = new HttpClient();
            _configuration = configuration;
            ShopAPI = _configuration.GetSection("HttpUrls")["ShopAPI"];
            GetAccessory = _configuration.GetSection("HttpUrls")["GetAllAccessory"];
            GetWatch = _configuration.GetSection("HttpUrls")["GetAllWatch"];
        }
        public IEnumerable<Accessory> AccessoryList { get; set; }
        public IEnumerable<Watch> WatchList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Uri path1 = new Uri(ShopAPI + GetWatch);
                HttpRequestMessage requestMessage1 = new HttpRequestMessage(HttpMethod.Get, path1);
                HttpResponseMessage response1 = await _client.SendAsync(requestMessage1);
                if (response1.IsSuccessStatusCode)
                {
                    string content = await response1.Content.ReadAsStringAsync();
                    WatchList = JsonConvert.DeserializeObject<IEnumerable<Watch>>(content);
                    if (WatchList != null)
                    {
                        foreach (var watch in WatchList)
                        {
                            watch.Link = "/Pictures/Orologi/" + watch.Model + "/" + watch.Color + ".png";
                        }
                    }
                    _logger.LogInformation($"WebApp: Magazzino - {response1.StatusCode} \n{response1.RequestMessage.Method} \n{response1.RequestMessage.RequestUri} \n- {DateTime.Now}  - {User.Identity.Name}");
                }
                else
                {
                    _logger.LogInformation($"WebApp: Magazzino - {response1.StatusCode} \n{response1.RequestMessage.Method} \n{response1.RequestMessage.RequestUri} \n- {DateTime.Now}  - {User.Identity.Name}");
                    return RedirectToPage("/Index");
                }

                Uri path2 = new Uri(ShopAPI + GetAccessory);
                HttpRequestMessage requestMessage2 = new HttpRequestMessage(HttpMethod.Get, path2);
                HttpResponseMessage response2 = await _client.SendAsync(requestMessage2);
                if (response2.IsSuccessStatusCode)
                {
                    string content = await response2.Content.ReadAsStringAsync();
                    AccessoryList = JsonConvert.DeserializeObject<IEnumerable<Accessory>>(content);
                    if (AccessoryList != null)
                    {
                        foreach (var accessory in AccessoryList)
                        {
                            accessory.Link = "/Pictures/Accessori/" + accessory.Name + "/" + accessory.Color + ".png";
                        }
                    }
                    _logger.LogInformation($"WebApp: Magazzino - {response2.StatusCode} \n{response2.RequestMessage.Method} \n{response2.RequestMessage.RequestUri} \n- {DateTime.Now}  - {User.Identity.Name}");
                }
                else
                {
                    _logger.LogInformation($"WebApp: Magazzino - {response2.StatusCode} \n{response2.RequestMessage.Method} \n{response2.RequestMessage.RequestUri} \n- {DateTime.Now}  - {User.Identity.Name}");
                    return RedirectToPage("/Index");
                }

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"WebApp: Magazzino - {ex.Message} - {DateTime.Now}  - {User.Identity.Name}");
                return RedirectToPage("/Index");
            }
        }
    }
}
