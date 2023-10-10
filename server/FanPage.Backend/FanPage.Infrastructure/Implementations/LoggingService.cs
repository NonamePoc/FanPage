// Ignore Spelling: Api

using FanPage.Common.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FanPage.Infrastructure.Implementations
{
    public class LoggingService
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<LoggingService> _logger;
        private readonly LoggingConfiguration _configuration;

        public LoggingService(ILoggerFactory loggerFactory, IOptions<LoggingConfiguration> configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration.Value;
            _logger = loggerFactory.CreateLogger<LoggingService>();
        }

        public void ConfigureDatabaseLogging(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration.EnableDatabaseTracing)
            {
                optionsBuilder.UseLoggerFactory(_loggerFactory);
                /*  optionsBuilder.EnableSensitiveDataLogging();*/ //  include database terys * only when very important
            }
        }

        public void LogApiRequest(HttpContext context)
        {
            if (_configuration.EnableApiLogging)
            {
                _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} {DateTime.Now}");
                // to do
            }
            else
            {
                _logger.LogInformation($"Request: {nameof(LogApiRequest)} {DateTime.Now}");
            }
        }

        public void LogApiResponse(HttpContext context)
        {
            if (_configuration.EnableApiLogging)
            {
                _logger.LogInformation($"Response: {context.Response.StatusCode} {DateTime.Now}");
                // to do
            }
            else
            {
                _logger.LogInformation($"Request: {nameof(LogApiResponse)} {DateTime.Now}");
            }
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message, DateTime.Now);
        }

        public void LogError(string message)
        {
            _logger.LogError(message, DateTime.Now);
        }
    }
}