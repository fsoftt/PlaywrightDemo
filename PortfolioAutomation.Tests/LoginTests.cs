using PortfolioAutomation.Core.Extensions;
using PortfolioAutomation.Flows;
using PortfolioAutomation.Pages;
using PortfolioAutomation.TestData;

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
        await ScreenshotIfFailed();
        await context.CloseAsync();
    }

    [Test]
    public async Task Login_StandardUser_Success()
    {
        await page.GoToHomePage();

        var loginFlow = new LoginFlow(page);
        InventoryPage inventoryPage = await loginFlow.LoginAsAsync(Auth.Username, Auth.Password);

        Assert.That(await inventoryPage.InventoryContainer.First.IsVisibleAsync(), Is.True, "El usuario no fue redirigido al inventario.");
    }

    [Test]
    public async Task Login_NoUserNoPassword_Failure()
    {
        await page.GoToHomePage();

        var loginFlow = new LoginFlow(page);
        await loginFlow.LoginAsAsync(string.Empty, string.Empty);


        Assert.Multiple(async () =>
        {
            var loginPage = new LoginPage(page);
            Assert.That(await loginPage.ErrorMessage.IsVisibleAsync(), Is.True, "Error message is not visible.");
            Assert.That(await loginPage.ErrorMessage.TextContentAsync(), Is.EqualTo("Epic sadface: Username is required"), "Error message is not correct.");
        });
    }

    [Test]
    public async Task Login_NoPassword_Failure()
    {
        await page.GoToHomePage();

        var loginFlow = new LoginFlow(page);
        await loginFlow.LoginAsAsync(Auth.Username, string.Empty);

        Assert.Multiple(async () =>
        {
            var loginPage = new LoginPage(page);
            Assert.That(await loginPage.ErrorMessage.IsVisibleAsync(), Is.True, "Error message is not visible.");
            Assert.That(await loginPage.ErrorMessage.TextContentAsync(), Is.EqualTo("Epic sadface: Password is required"), "Error message is not correct.");
        });
    }
}