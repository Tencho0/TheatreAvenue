using Moq;
using NLog;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Services;
using Xunit;

namespace TheatreAvenue.Tests
{
    public class LoggerServiceTests
    {
        private readonly Mock<ILogger> _loggerMock;
        private readonly LoggerService _service;

        public LoggerServiceTests()
        {
            _loggerMock = new Mock<ILogger>();
            _service = new LoggerService(_loggerMock.Object);
        }

        [Fact]
        public void LogDebug_CallsNLog()
        {
            // Arrange
            var message = "Test debug message";

            // Act
            _service.LogDebug(message);

            // Assert
            _loggerMock.Verify(logger => logger.Debug(message), Times.Once);
        }

        [Fact]
        public void LogError_CallsNLog()
        {
            // Arrange
            var message = "Test error message";

            // Act
            _service.LogError(message);

            // Assert
            _loggerMock.Verify(logger => logger.Error(message), Times.Once);
        }

        [Fact]
        public void LogInfo_CallsNLog()
        {
            // Arrange
            var message = "Test info message";

            // Act
            _service.LogInfo(message);

            // Assert
            _loggerMock.Verify(logger => logger.Info(message), Times.Once);
        }

        [Fact]
        public void LogWarn_CallsNLog()
        {
            // Arrange
            var message = "Test warning message";

            // Act
            _service.LogWarn(message);

            // Assert
            _loggerMock.Verify(logger => logger.Warn(message), Times.Once);
        }
    }
}
