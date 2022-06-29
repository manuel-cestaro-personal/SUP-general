using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SerenUP.WebApp.Pages.Shop
{
    public class Shop_OrologiModel : PageModel
    {
        public string path { get; set; }
        public void OnGet()
        {
            path = @"Gold/Nero";
        }
    }
}
