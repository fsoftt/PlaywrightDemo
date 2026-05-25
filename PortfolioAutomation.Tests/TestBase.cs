using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using PortfolioAutomation.Core;

namespace PortfolioAutomation.Tests
{
    public class TestBase
    {
        protected static Logger logger;

        protected static IPlaywright playwright;
        protected static IBrowser browser;

        protected IBrowserContext context = null!;
        protected IPage page = null!;

        [OneTimeSetUp]
        public static async Task GlobalSetup()
        {
            logger = Logger.Get();

            playwright = await Playwright.CreateAsync();

            browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = true
            });
        }

        [OneTimeTearDown]
        public static async Task GlobalTearDown()
        {
            await browser.CloseAsync();
            playwright.Dispose();
        }

        protected async Task ScreenshotIfFailed()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                await ScreenshotHelper.TakeScreenshotAsync(page, testName, "Error");

                logger.Error($"Test {testName} falló. Screenshot tomado.");
            }
        }
    }
}
