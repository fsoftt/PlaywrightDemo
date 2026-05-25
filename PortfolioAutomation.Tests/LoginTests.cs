using PortfolioAutomation.Flows;
using PortfolioAutomation.Pages;

namespace PortfolioAutomation.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class LoginTests : TestBase
{
    [SetUp]
    public async Task Setup()
    {
        context = await browser.NewContextAsync();
        page = await context.NewPageAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await context.CloseAsync();
    }

    [Test]
    public async Task Login_StandardUser_Success()
    {
        // TODO: get url from config
        // TODO: move go to page to browser factory
        await page.GotoAsync("https://www.saucedemo.com/");
        var loginFlow = new LoginFlow(page);

        // TODO: get credentials from config
        InventoryPage inventoryPage = await loginFlow.LoginAsAsync("standard_user", "secret_sauce");

        Assert.That(await inventoryPage.InventoryContainer.First.IsVisibleAsync(), Is.True, "El usuario no fue redirigido al inventario.");
    }

    [Test]
    public async Task Login_NoUserNoPassword_Failure()
    {
        // TODO: get url from config
        // TODO: move go to page to browser factory
        await page.GotoAsync("https://www.saucedemo.com/");
        var loginFlow = new LoginFlow(page);

        // TODO: get credentials from config
        await loginFlow.LoginAsAsync(string.Empty, string.Empty);

        var loginPage = new LoginPage(page);

        Assert.Multiple(async () =>
        {
            Assert.That(await loginPage.ErrorMessage.IsVisibleAsync(), Is.True, "Error message is not visible.");
            Assert.That(await loginPage.ErrorMessage.TextContentAsync(), Is.EqualTo("Epic sadface: Username is required"), "Error message is not correct.");
        });
    }

    [Test]
    public async Task Login_NoPassword_Failure()
    {
        // TODO: get url from config
        // TODO: move go to page to browser factory
        await page.GotoAsync("https://www.saucedemo.com/");
        var loginFlow = new LoginFlow(page);

        // TODO: get credentials from config
        await loginFlow.LoginAsAsync("standard_user", string.Empty);

        var loginPage = new LoginPage(page);

        Assert.Multiple(async () =>
        {
            Assert.That(await loginPage.ErrorMessage.IsVisibleAsync(), Is.True, "Error message is not visible.");
            Assert.That(await loginPage.ErrorMessage.TextContentAsync(), Is.EqualTo("Epic sadface: Password is required"), "Error message is not correct.");
        });
    }
}