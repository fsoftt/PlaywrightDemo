using Microsoft.Playwright;

namespace PortfolioAutomation.Core
{
    public static class ScreenshotHelper
    {
        public static async Task<string> TakeScreenshotAsync(IPage page, string testName, string step = "Step")
        {
            string screenshotsPath = Configuration.Get("ScreenshotsPath");
            string screenshotsDir = Path.Combine(Directory.GetCurrentDirectory(), screenshotsPath);
            if (!Directory.Exists(screenshotsDir))
            {
                Directory.CreateDirectory(screenshotsDir);
            }

            string filePath = GetFilePath(testName, step, screenshotsDir);

            byte[] bytes = await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = filePath,
                FullPage = true
            });

            await File.WriteAllBytesAsync(filePath, bytes);

            return filePath;
        }

        private static string GetFilePath(string testName, string step, string screenshotsDir)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{testName}_{step}_{timestamp}.png"
                .Replace("(", "_")
                .Replace(")", "_")
                .Replace("\",\"", "_")
                .Replace(":", "_")
                .Replace("\"", "_")
                .Replace(" ", "_"); ;
            string filePath = Path.Combine(screenshotsDir, fileName);

            return filePath;
        }
    }
}
