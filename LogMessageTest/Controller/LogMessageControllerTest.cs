using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using LogMessageApp.Repositories;
using Xunit;

namespace LogMessageTest.Controller
{
    public class LogMessageControllerTest
    {
        private readonly ILogMessageRepository _logRepository;

        public LogMessageControllerTest()
        {
            _logRepository = A.Fake<ILogMessageRepository>();
        }
        [Fact]
        public void LogMessagesControllerTest_GetLogMessage_ResponseOK()
        {
            //Arrange
            int logId = 1;

            // Act on Test  
            var response = _logRepository.GetLogMessages(logId);

            // Assert the result  
            Assert.NotNull(response);
        }
        [Fact]
        public void LogMessagesControllerTest_AddLogMessage_ResponseOK()
        {
            //Arrange
            int logId = 1;
            string name = "Suplier";
            string message = "hello, How are you?";

            // Act on Test  
            var response = _logRepository.AddMessage(name, logId, message);

            // Assert the result  
            Assert.NotNull(response);
        }
    }
}