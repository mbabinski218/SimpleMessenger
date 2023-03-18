using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleMessenger.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? UserName { get; set; }

        [BindProperty]
        public string? Chat { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Chat))
                return Page();

            return RedirectToPage("./Chat", new{UserName, Chat});
        }
    }
}