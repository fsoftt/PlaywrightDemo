using Microsoft.Playwright;

namespace PortfolioAutomation.Core
{
    public static class ScreenshotHelper
    {
        public static async Task<string> TakeScreenshotAsync(IPage page, string testName, string step = null)
        {
            string screenshotsDir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
            if (!Directory.Exists(screenshotsDir))
            {
                Directory.CreateDirectory(screenshotsDir);
            }

            string filePath = GetFilePath(testName, step, screenshotsDir);

            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = filePath,
                FullPage = true
            });

            return filePath;
        }

        private static string GetFilePath(string testName, string step, string screenshotsDir)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{testName}_{step ?? "Step"}_{timestamp}.png";
            string filePath = Path.Combine(screenshotsDir, fileName);
            return filePath;
        }
    }
}
