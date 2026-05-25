using Microsoft.Playwright;

namespace PortfolioAutomation.Tests
{
    [SetUpFixture]
    public class GlobalPlaywrightSetup
    {
        public static IBrowser Browser { get; private set; } = null!;
        public static IPlaywright PlaywrightInstance { get; private set; } = null!;

        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            PlaywrightInstance = await Playwright.CreateAsync();
            Browser = await PlaywrightInstance.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        }

        [OneTimeTearDown]
        public async Task RunAfterAllTests()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }

            PlaywrightInstance?.Dispose();
        }
    }
}
