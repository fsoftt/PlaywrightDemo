using Microsoft.Extensions.Configuration;

namespace PortfolioAutomation.Core
{
    public class Configuration
    {
        private readonly static object lockObject = new();
        private static IConfigurationRoot configuration;

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                // TODO: settings should be variable
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            lock (lockObject)
            {
                configuration ??= builder.Build();
            }
        }

        public static string Get(string key) => configuration[key] ?? string.Empty;
        public static bool GetBool(string key) => bool.Parse(configuration[key] ?? "false");
        public static int GetInt(string key) => int.Parse(configuration[key] ?? "0");
    }
}
