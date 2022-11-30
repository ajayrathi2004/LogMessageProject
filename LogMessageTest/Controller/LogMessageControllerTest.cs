using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogMessageApp.Data;
using LogMessageApp.Repositories;
using Microsoft.Extensions.Configuration;
using Xunit;
using Moq;
using AutoFixture;
using FluentAssertions;
using LogMessageApp.Controllers;
using LogMessageApp.Models;

namespace LogMessageTest.Controller
{
    public class LogMessageControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<ILogMessageRepository> _logRepository;
        private readonly Mock<ApiContext> _context;
        private readonly IConfiguration _configuration;
        private readonly LogMessageController _logMessageController;

        public LogMessageControllerTest()
        {
            //_logRepository = A.Fake<ILogMessageRepository>();
            //_context = A.Fake<ApiContext>();
            //_configuration = A.Fake<IConfiguration>();

            _fixture=new Fixture();
            _context = _fixture.Freeze<Mock<ApiContext>>();
            _logRepository = _fixture.Freeze<Mock<ILogMessageRepository>>();
            //_configuration = _fixture.Freeze<Mock<IConfiguration>>();
            _logMessageController = new LogMessageController(_logRepository.Object, _configuration);

        }
        [Fact]
        public void LogMessagesControllerTest_GetLogMessage_ResponseOK()
        {
            //Arrange
            var logReturnMock = _fixture.Create<List<LogMessage>>();
            var logId = 1;
            _logRepository.Setup(x=>x.GetLogMessages(logId)).Returns(logReturnMock);

            //Act
            var results = _logMessageController.GetLog(logId);

            // Assert the result  
            results.Should().NotBeNull();
         

            // Below is the use of FakeItEasy

            ////Arrange
            //int logId = 1;

            //var caller = new LogMessageRepository(_context, _configuration);
            //// Act on Test  
            //var response = caller.GetLogMessages(logId);

            //// Assert the result  
            //Assert.NotNull(response);
        }
        [Fact]
        public void LogMessagesControllerTest_AddLogMessage_ResponseOK()
        {
            ////Arrange
            //int logId = 1;
            //string name = "Suplier";
            //string message = "hello, How are you?";

            //var caller = new LogMessageRepository(_context, _configuration);
            //// Act on Test  
            //var response = caller.AddMessage(name, logId, message);

            //// Assert the result  
            //Assert.NotNull(response);
        }
    }
}