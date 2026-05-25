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

        public static void Information(string message) => Log.Information(message);
        public static void Warning(string message) => Log.Warning(message);
        public static void Error(string message, Exception? ex = null) => Log.Error(ex, message);
        public static void Debug(string message) => Log.Debug(message);
        public static void Fatal(string message, Exception? ex = null) => Log.Fatal(ex, message);
        public static void CloseAndFlush() => Log.CloseAndFlush();
    }
}
