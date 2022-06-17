using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SerenUP.Intranet.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            /*if (User.Identity.IsAuthenticated)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }*/
            return Page();
        }
    }
}