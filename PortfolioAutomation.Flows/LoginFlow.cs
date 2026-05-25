using Microsoft.Playwright;
using PortfolioAutomation.Pages;

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

        return new InventoryPage(loginPage.Page);
    }
}
