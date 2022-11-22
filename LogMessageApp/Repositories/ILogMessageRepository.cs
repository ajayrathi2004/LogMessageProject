using LogMessageApp.Models;

namespace LogMessageApp.Repositories
{
    public interface ILogMessageRepository
    {
        public List<LogMessage> GetLogMessages(int logId);
        public LogMessage AddMessage(String name, int logId, String message);
        public List<LogMessage> GetAllLogMessages();
    }
}

