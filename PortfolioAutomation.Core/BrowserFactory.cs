using Microsoft.Playwright;

namespace PortfolioAutomation.Core;

public class BrowserFactory
{
    private IPlaywright playwright = null!;
    public IBrowser Browser { get; private set; } = null!;
    public IBrowserContext Context { get; private set; } = null!;
    public IPage Page { get; private set; } = null!;

    public async Task StartAsync(bool headless = false)
    {
        playwright = await Playwright.CreateAsync();

        // TODO: browser type should be configurable (chromium, firefox, webkit)
        Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
        Context = await Browser.NewContextAsync();
        Page = await Context.NewPageAsync();
        Page.SetDefaultTimeout(Configuration.GetInt("Timeout"));
    }

    public async Task StopAsync()
    {
        await Context.CloseAsync();
        await Browser.CloseAsync();
        playwright?.Dispose();
    }
}
