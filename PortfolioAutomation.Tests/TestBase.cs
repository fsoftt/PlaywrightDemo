using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using PortfolioAutomation.Core;

namespace PortfolioAutomation.Tests
{
    public class TestBase
    {
        protected static Logger logger;

        protected static IBrowser browser;
        protected static IPlaywright playwright;

        protected IPage page = null!;
        protected IBrowserContext context = null!;

        [SetUp]
        public virtual async Task Setup()
        {
            context = await GlobalPlaywrightSetup.Browser.NewContextAsync();
            page = await context.NewPageAsync();
        }

        [TearDown]
        public virtual async Task TearDown()
        {
            await ScreenshotIfFailed();

            if (context != null)
            {
                await context.CloseAsync();
            }
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
