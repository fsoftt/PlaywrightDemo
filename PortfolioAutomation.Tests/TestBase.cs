using NUnit.Framework.Interfaces;
using PortfolioAutomation.Core;

namespace PortfolioAutomation.Tests
{
    public class TestBase
    {
        protected Logger logger;
        protected BrowserFactory browser;

        [SetUp]
        public async Task Setup()
        {
            logger = Logger.Get();
            browser = new BrowserFactory();
            await browser.StartAsync();

            logger.Information("Browser started successfully.");
        }

        [TearDown]
        public async Task Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string testName = TestContext.CurrentContext.Test.Name;
                await ScreenshotHelper.TakeScreenshotAsync(browser.Page, testName, "Error");

                logger.Error($"Test {testName} falló. Screenshot tomado.");
            }

            await browser.StopAsync();

            logger.Information("Browser stopped successfully.");
        }
    }
}
