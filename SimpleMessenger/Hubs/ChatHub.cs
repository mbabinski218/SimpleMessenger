using Microsoft.AspNetCore.SignalR;
using SimpleMessenger.Database;
using SimpleMessenger.Models;

namespace SimpleMessenger.Hubs;

public class ChatHub : Hub
{
    private readonly IDatabaseManager _database;

    public ChatHub(IDatabaseManager database)
    {
        _database = database;
    }

    public async Task JoinGroup(string chatName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatName);

        var messages = _database.GetChatHistory(chatName);

        if (!messages.Any())
            return;
        
        foreach (var message in messages)
        {
            var date = message.Date.ToShortTimeString();
            await Clients.Caller.SendAsync("ReceiveMessage", message.AuthorName, message.Content, date);
        }
    }

    public async Task SendMessage(string authorName, string content, string chat)
    {
        var message = new Message
        {
            AuthorName = authorName,
            Content = content,
            Chat = chat,
            Date = DateTime.Now
        };

        _database.Add(message);

        var date = message.Date.ToShortTimeString();
        await Clients.Group(message.Chat).SendAsync("ReceiveMessage", message.AuthorName, message.Content, date);
    }
}