using Microsoft.Playwright;

namespace PortfolioAutomation.Pages;

public class LoginPage
{
    private readonly IPage page;

    public LoginPage(IPage page) => this.page = page;

    private ILocator UsernameInput => page.Locator("#user-name");
    private ILocator PasswordInput => page.Locator("#password");
    private ILocator LoginButton => page.Locator("#login-button");

    public async Task LoginAsync(string username, string password)
    {
        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(password);

        await LoginButton.ClickAsync();
    }
}
