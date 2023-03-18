using SimpleMessenger.Models;

namespace SimpleMessenger.Database;

public interface IDatabaseManager
{
    public void Add(Message message);
    public IEnumerable<Message> GetChatHistory(string chatName);
}