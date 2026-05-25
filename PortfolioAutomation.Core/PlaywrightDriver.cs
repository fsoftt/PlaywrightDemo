using Microsoft.Playwright;

namespace PortfolioAutomation.Core;

public static class PlaywrightDriver
{
    private static IPlaywright? playwright;
    private static IBrowser? browser;
    private static readonly object sync = new();

    public static IBrowser GetBrowser()
    {
        if (browser == null) throw new InvalidOperationException("Playwright browser not initialized. Call EnsureStartedAsync first.");
        return browser;
    }

    public static async Task EnsureStartedAsync(bool headless = false)
    {
        if (browser != null) return;

        lock (sync)
        {
            if (browser != null) return;
            // initialize outside lock
        }

        // create playwright and browser
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
    }

    public static async Task ShutdownAsync()
    {
        try
        {
            if (browser != null)
            {
                await browser.CloseAsync();
            }
        }
        catch
        {
        }

        try
        {
            playwright?.Dispose();
        }
        catch
        {
        }

        browser = null;
        playwright = null;
    }
}
