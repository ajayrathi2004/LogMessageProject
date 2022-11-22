using LogMessageApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogMessageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogMessageController : ControllerBase
    {
        private readonly ILogMessageRepository _logRepository;
        private readonly IConfiguration _configuration;

        public LogMessageController(ILogMessageRepository logRepository, IConfiguration configuration)
        {
            _logRepository = logRepository;
            _configuration = configuration;
        }

        [HttpGet("GetLog/{logId}")]
        public JsonResult GetLog(int logId)
        {
            var logMessages = _logRepository.GetLogMessages(logId);
            return logMessages == null ? new JsonResult(NotFound()) : new JsonResult(Ok(logMessages));
        }

        [HttpPost]
        public JsonResult AddMessage(String name, int logId, String message)
        {
            var logMessage = _logRepository.AddMessage(name, logId, message);
            return new JsonResult(Ok(logMessage));
        }

        [HttpGet("GetAll")]
        public JsonResult GetAllLogMessages()
        {
            var messages = _logRepository.GetAllLogMessages();
            return new JsonResult(Ok(messages));
        }

        //Get
        [HttpGet("Get")]
        public JsonResult Get()
        {
            var maxAgeInSec = _configuration["maxAgeInSec"];//Value of Expiry time of message in seconds
            var totalMessages = _logRepository.GetAllLogMessages().Count(); // total number of messages in all logs.
            //get messages per log
            var messagesPerLog = _logRepository.GetAllLogMessages().GroupBy(n => n.LogId) 
                        .Select(n => new
                        {
                            StoredLogs = n.Key,
                            MessagesperLog = n.Count(),
                            maxAgeInSec = maxAgeInSec
                        })
                        .OrderBy(n => n.StoredLogs);

            return new JsonResult(messagesPerLog);

        }
    }
}
