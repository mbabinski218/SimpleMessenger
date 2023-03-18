using System.ComponentModel.DataAnnotations;

namespace SimpleMessenger.Models;

public class Message
{
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public string Chat { get; set; }
    public string AuthorName { get; set; }
}