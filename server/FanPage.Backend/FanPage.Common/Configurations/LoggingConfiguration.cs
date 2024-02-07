using Microsoft.Extensions.Logging;

namespace FanPage.Common.Configurations
{
    public class LoggingConfiguration
    {
        public bool EnableDatabaseTracing { get; set; }
        public LogLevel DatabaseLogLevel { get; set; } = LogLevel.Information;
        public bool EnableApiLogging { get; set; }
        public LogLevel ApiLogLevel { get; set; } = LogLevel.Information;
    }
}