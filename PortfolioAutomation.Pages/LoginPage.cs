using Microsoft.Playwright;

namespace PortfolioAutomation.Pages;

public class LoginPage : PageBase
{
    public LoginPage(IPage page) : base(page) { }

    private ILocator UsernameInput => Page.Locator("#user-name");
    private ILocator PasswordInput => Page.Locator("#password");
    private ILocator LoginButton => Page.Locator("#login-button");
    public ILocator ErrorMessage => Page.Locator("[data-test='error']");

    public async Task LoginAsync(string username, string password)
    {
        logger.Information($"Logging in as {username}");

        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(password);

        await LoginButton.ClickAsync();
    }
}
