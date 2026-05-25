using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
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

        protected IBrowserContext context;
        protected IPage page;

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

        //[OneTimeSetUp]
        //public async Task Setup()
        //{
        //    logger = Logger.Get();
        //    browser = new BrowserFactory();
        //    logger.Information($"BrowserFactory InstanceId: {browser.InstanceId}");
        //    await browser.StartAsync();

        //    logger.Information("Browser started successfully.");
        //}

        //[TearDown]
        //public async Task Teardown()
        //{
        //    if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        //    {
        //        string testName = TestContext.CurrentContext.Test.Name;
        //        string screenshotPath = await ScreenshotHelper.TakeScreenshotAsync(browser.Page, testName, "Error");
        //        AttachScreenshot(screenshotPath);

        //        logger.Error($"Test {testName} falló. Screenshot tomado.");
        //    }
        //}

        //[OneTimeTearDown]
        //public async Task OneTimeTeardown()
        //{
        //    await browser.StopAsync();

        //    logger.Information("Browser stopped successfully.");
        //}

        //[AllureAttachment("Screenshot", ContentType = "image/png")]
        //public byte[] AttachScreenshot(string path)
        //{
        //    return File.ReadAllBytes(path);
        //}
    }
}
