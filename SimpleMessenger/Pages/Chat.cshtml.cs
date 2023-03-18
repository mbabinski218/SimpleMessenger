using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleMessenger.Models;

namespace SimpleMessenger.Pages
{
    public class ChatModel : PageModel
    {
        public string AuthorName { get; set; }
        public string Chat { get; set; }
        public string Message { get; set; }

        private readonly ILogger<ChatModel> _logger;

        public ChatModel(ILogger<ChatModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string userName, string chat)
        {
            AuthorName = userName;
            Chat = chat;
        }
    }
}
