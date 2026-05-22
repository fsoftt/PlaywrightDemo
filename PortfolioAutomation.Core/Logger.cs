using Serilog;

namespace PortfolioAutomation.Core
{
    public class Logger
    {
        private static Logger? logger;
        private static bool initialized = false;

        public static Logger Get()
        {
            if (initialized)
            {
                return logger!;
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                // TODO: path should be configurable
                .WriteTo.File("Logs/automation_log_.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            initialized = true;

            logger = new Logger();

            return logger;
        }

        public void Information(string message) => Log.Information(message);
        public void Warning(string message) => Log.Warning(message);
        public void Error(string message, Exception? ex = null) => Log.Error(ex, message);
        public void Debug(string message) => Log.Debug(message);
        public void Fatal(string message, Exception? ex = null) => Log.Fatal(ex, message);

        public void CloseAndFlush() => Log.CloseAndFlush();
    }
}
