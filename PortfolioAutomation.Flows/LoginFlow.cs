using Microsoft.Playwright;
using PortfolioAutomation.Pages.Pages;

namespace PortfolioAutomation.Flows;

public class LoginFlow : FlowBase
{
    private readonly LoginPage loginPage;

    public LoginFlow(IPage page)
    {
        loginPage = new LoginPage(page);
    }

    public async Task<InventoryPage> LoginAsAsync(string username, string password)
    {
        await loginPage.LoginAsync(username, password);
        logger.Information($"Logged in as {username}");

        return new InventoryPage(loginPage.Page);
    }

    public async Task<LoginPage> LogoutAsync()
    {
        await loginPage.LogoutAsync();
        logger.Information($"Logged out");

        return loginPage;
    }
}
