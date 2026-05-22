using Microsoft.Playwright;
using PortfolioAutomation.Pages;

namespace PortfolioAutomation.Tests;

public class LoginTests
{
    private IBrowser browser;
    private IBrowserContext context;
    private IPage page;

    [SetUp]
    public async Task Setup()
    {
        var playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        context = await browser.NewContextAsync();
        page = await context.NewPageAsync();
    }

    [TearDown]
    public async Task Teardown()
    {
        await context.CloseAsync();
        await browser.CloseAsync();
    }

    [Test]
    public async Task Login_StandardUser_Success()
    {
        await page.GotoAsync("https://www.saucedemo.com/");
        var loginPage = new LoginPage(page);
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        var inventoryPage = new InventoryPage(page);
        Assert.That(await inventoryPage.InventoryContainer.IsVisibleAsync(), Is.True, "El usuario no fue redirigido al inventario.");
    }
}