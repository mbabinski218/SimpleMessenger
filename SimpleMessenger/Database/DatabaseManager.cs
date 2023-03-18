using SimpleMessenger.Models;

namespace SimpleMessenger.Database;

public class DatabaseManager : IDatabaseManager
{
    private readonly HashSet<Message> _dbContext = new();
    public void Add(Message message)
    {
        _dbContext.Add(message);
    }

    public IEnumerable<Message> GetChatHistory(string chatName)
    {
        return _dbContext
            .Where(msg => msg.Chat == chatName)
            .OrderBy(msg => msg.Date);
    }
}