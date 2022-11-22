using LogMessageApp.Data;
using LogMessageApp.Models;

namespace LogMessageApp.Repositories
{
    public class LogMessageRepository : ILogMessageRepository
    {
        private readonly ApiContext _apiContext;
        private readonly IConfiguration _configuration;
        public LogMessageRepository(ApiContext apiContext, IConfiguration configuration)
        {
            _apiContext = apiContext;
            _configuration = configuration;
        }
        public List<LogMessage> GetLogMessages(int logId)
        {
            var logMessages = _apiContext.logMessage.Where(l => l.LogId == logId).ToList();
            return logMessages;
        }
        public LogMessage AddMessage(String name, int logId, String message)
        {
            var maxAgeInSec = _configuration["maxAgeInSec"];
            LogMessage logMessage = new LogMessage()
            {
                LogId = logId,
                Name = name,
                Message = message,
                Created = DateTime.Now,
                ValidTill = DateTime.Now.AddSeconds(Convert.ToInt64(maxAgeInSec))
            };
            _apiContext.logMessage.Add(logMessage);
            _apiContext.SaveChanges();

            return logMessage;
        }
        public List<LogMessage> GetAllLogMessages()
        {
            var logMessages = _apiContext.logMessage.ToList();
            return logMessages;

        }
    }
}
