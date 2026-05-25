using Serilog;

namespace PortfolioAutomation.Core
{
    public class Logger
    {
        private static Logger? logger;
        private static readonly Lock lockObject = new();

        public static Logger Get()
        {
            if (logger != null)
            {
                return logger!;
            }

            string logsPath = Configuration.Get("LogsPath");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logsPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            lock (lockObject)
            {
                logger = new Logger();
            }

            return logger;
        }

#pragma warning disable CA1822 // Mark members as static
        public void Information(string message) => Log.Information(message);
        public void Warning(string message) => Log.Warning(message);
        public void Error(string message, Exception? ex = null) => Log.Error(ex, message);
        public void Debug(string message) => Log.Debug(message);
        public void Fatal(string message, Exception? ex = null) => Log.Fatal(ex, message);
        public void CloseAndFlush() => Log.CloseAndFlush();
#pragma warning restore CA1822 // Mark members as static
    }
}
