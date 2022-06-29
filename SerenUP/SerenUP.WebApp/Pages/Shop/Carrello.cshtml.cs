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
        private readonly string ShopAPI;

        public CarrelloModel(UserManager<ApplicationUser> userManager, ILogger<CarrelloModel> logger, IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            _client = new HttpClient();
            _configuration = configuration;
            ShopAPI = _configuration.GetSection("HttpUrls")["ShopAPI"];
            CartAccessory = _configuration.GetSection("HttpUrls")["CartAccessory"];
        }
        public IEnumerable<AccessoryDetail> AccessoryList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                //_client.BaseAddress = new Uri(ShopAPI + CartAccessory);
                var currentUser = await _userManager.FindByEmailAsync(User.Identity.Name); // --> ricevo i dati completi dell'utente corrente
                Guid userId = currentUser.Id; // --> ne ricavo l'id
                Uri path = new Uri(ShopAPI + CartAccessory + userId.ToString());
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, path);
                HttpResponseMessage response = await _client.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    AccessoryList = JsonConvert.DeserializeObject<IEnumerable<AccessoryDetail>>(content);
                    if (AccessoryList != null)
                    {
                        foreach (var accessory in AccessoryList)
                        {
                            accessory.Link = "/Pictures/Accessori/" + accessory.Name + "/" + accessory.Color + ".png";
                        }
                    }
                    _logger.LogInformation($"WebApp: Carrello page - {response.StatusCode} \n{response.RequestMessage.Method} \n{response.RequestMessage.RequestUri} \n- {DateTime.Now} - {userId}");
                }
                else
                {
                    _logger.LogInformation($"WebApp: Carrello page - {response.StatusCode} \n{response.RequestMessage.Method} \n{response.RequestMessage.RequestUri} \n- {DateTime.Now} - {userId}");
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
