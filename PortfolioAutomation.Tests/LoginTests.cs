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

    [TestCase(Auth.WorkingUser, Auth.Password)]
    [TestCase(Auth.VisualUser, Auth.Password)]
    public async Task Login_StandardUser_Success(string username, string password)
    {
        await page.GoToHomePage();

        var loginFlow = new LoginFlow(page);
        InventoryPage inventoryPage = await loginFlow.LoginAsAsync(username, password);

        Assert.That(await inventoryPage.InventoryContainer.First.IsVisibleAsync(), Is.True, "El usuario no fue redirigido al inventario.");
    }

    [TestCase("", "", "Epic sadface: Username is required")]
    [TestCase(Auth.WorkingUser, "", "Epic sadface: Password is required")]
    [TestCase(Auth.LockedUser, Auth.Password, "Epic sadface: Sorry, this user has been locked out.")]
    [TestCase(Auth.FakeUser, Auth.Password, "Epic sadface: Username and password do not match any user in this service")]
    public async Task Login_Failure(string username, string password, string errorMessage)
    {
        await page.GoToHomePage();

        var loginFlow = new LoginFlow(page);
        await loginFlow.LoginAsAsync(username, password);


        Assert.Multiple(async () =>
        {
            var loginPage = new LoginPage(page);
            Assert.That(await loginPage.ErrorMessage.IsVisibleAsync(), Is.True, "Error message is not visible.");
            Assert.That(await loginPage.ErrorMessage.TextContentAsync(), Is.EqualTo(errorMessage), "Error message is not correct.");
        });
    }
}