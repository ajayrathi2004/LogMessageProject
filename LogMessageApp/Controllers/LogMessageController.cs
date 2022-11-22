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
        
        public LogMessageController(ILogMessageRepository logRepository)
        {
            _logRepository = logRepository;
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
    }
}
