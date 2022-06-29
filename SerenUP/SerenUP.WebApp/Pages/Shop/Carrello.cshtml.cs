using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SerenUP.WebApp.Data;
using SerenUP.WebApp.Models;

namespace SerenUP.WebApp.Pages.Shop
{
    [Authorize]
    public class CarrelloModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CarrelloModel> _logger;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly string CartAccessory;
        private readonly string CartWatch;
        private readonly string ShopAPI;

        public CarrelloModel(UserManager<ApplicationUser> userManager, ILogger<CarrelloModel> logger, IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            _client = new HttpClient();
            _configuration = configuration;
            ShopAPI = _configuration.GetSection("HttpUrls")["ShopAPI"];
            CartAccessory = _configuration.GetSection("HttpUrls")["CartAccessory"];
            CartWatch = _configuration.GetSection("HttpUrls")["CartWatch"];
        }
        public IEnumerable<AccessoryDetail> AccessoryList { get; set; }
        public IEnumerable<Watch> WatchList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var currentUser = await _userManager.FindByEmailAsync(User.Identity.Name); // --> ricevo i dati completi dell'utente corrente
                Guid userId = currentUser.Id; // --> ne ricavo l'id

                Uri path1 = new Uri(ShopAPI + CartWatch + userId.ToString());
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
                    _logger.LogInformation($"WebApp: Carrello page - {response1.StatusCode} \n{response1.RequestMessage.Method} \n{response1.RequestMessage.RequestUri} \n- {DateTime.Now} - {userId}");
                }
                else
                {
                    _logger.LogInformation($"WebApp: Carrello page - {response1.StatusCode} \n{response1.RequestMessage.Method} \n{response1.RequestMessage.RequestUri} \n- {DateTime.Now} - {userId}");
                    return RedirectToPage("/Index");
                }

                Uri path2 = new Uri(ShopAPI + CartAccessory + userId.ToString());
                HttpRequestMessage requestMessage2 = new HttpRequestMessage(HttpMethod.Get, path2);
                HttpResponseMessage response2 = await _client.SendAsync(requestMessage2);
                if (response2.IsSuccessStatusCode)
                {
                    string content = await response2.Content.ReadAsStringAsync();
                    AccessoryList = JsonConvert.DeserializeObject<IEnumerable<AccessoryDetail>>(content);
                    if (AccessoryList != null)
                    {
                        foreach (var accessory in AccessoryList)
                        {
                            accessory.Link = "/Pictures/Accessori/" + accessory.Name + "/" + accessory.Color + ".png";
                        }
                    }
                    _logger.LogInformation($"WebApp: Carrello page - {response2.StatusCode} \n{response2.RequestMessage.Method} \n{response2.RequestMessage.RequestUri} \n- {DateTime.Now} - {userId}");
                }
                else
                {
                    _logger.LogInformation($"WebApp: Carrello page - {response2.StatusCode} \n{response2.RequestMessage.Method} \n{response2.RequestMessage.RequestUri} \n- {DateTime.Now} - {userId}");
                    return RedirectToPage("/Index");
                }

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"WebApp: Carrello page - {ex.Message} - {DateTime.Now} - {User.Identity.Name}");
                return RedirectToPage("/Index");
            }
        }
    }
}
