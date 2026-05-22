using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using PortfolioAutomation.Core;
using PortfolioAutomation.Pages;

namespace PortfolioAutomation.Tests;

public class LoginTests : TestBase
{
    [Test]
    [AllureTag("smoke")]
    [AllureOwner("fsilva")]
    [AllureSeverity(SeverityLevel.critical)]
    public async Task Login_StandardUser_Success()
    {
        // TODO: get url from config
        // TODO: move go to page to browser factory
        await browser.Page.GotoAsync("https://www.saucedemo.com/");
        var loginPage = new LoginPage(browser.Page);

        // TODO: get credentials from config
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        var inventoryPage = new InventoryPage(browser.Page);
        Assert.That(await inventoryPage.InventoryContainer.First.IsVisibleAsync(), Is.True, "El usuario no fue redirigido al inventario.");
    }
}