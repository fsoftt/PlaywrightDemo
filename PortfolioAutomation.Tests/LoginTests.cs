using Microsoft.Playwright;
using PortfolioAutomation.Core;
using PortfolioAutomation.Pages;

namespace PortfolioAutomation.Tests;

public class LoginTests
{
    private Logger logger;
    private BrowserFactory browser;

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
        await browser.StopAsync();
        logger.Information("Browser stopped successfully.");
    }

    [Test]
    public async Task Login_StandardUser_Success()
    {
        // TODO: get url from config
        // TODO: move go to page to browser factory
        await browser.Page.GotoAsync("https://www.saucedemo.com/");
        var loginPage = new LoginPage(browser.Page);

        // TODO: get credentials from config
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        var inventoryPage = new InventoryPage(browser.Page);
        Assert.That(await inventoryPage.InventoryContainer.IsVisibleAsync(), Is.True, "El usuario no fue redirigido al inventario.");
    }
}