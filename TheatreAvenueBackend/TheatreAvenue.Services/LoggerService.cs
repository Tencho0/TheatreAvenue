using NLog;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Services
{
    // A service to log messages using NLog
    public class LoggerService : ILoggerService
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public LoggerService()
        { }

        // Constructor with dependency injection
        public LoggerService(ILogger logger)
        {
            _logger = logger;
        }

        // Log a debug message
        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        // Log an error message
        public void LogError(string message)
        {
            _logger.Error(message);
        }

        // Log an info message
        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        // Log a warning message
        public void LogWarn(string message)
        {
            _logger.Warn(message);
        }
    }
}


