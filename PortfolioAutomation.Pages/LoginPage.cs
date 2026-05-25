using Microsoft.Playwright;

namespace PortfolioAutomation.Pages;

public class LoginPage : PageBase
{
    public LoginPage(IPage page) : base(page) { }

    public ILocator UsernameInput => Page.Locator("#user-name");
    private ILocator PasswordInput => Page.Locator("#password");
    private ILocator LoginButton => Page.Locator("#login-button");
    public ILocator ErrorMessage => Page.Locator("[data-test='error']");
    
    // This should be in the MenuComponent
    public ILocator LogoutButton => Page.Locator("#logout_sidebar_link");
    public ILocator BurgerMenuButton => Page.Locator("#react-burger-menu-btn");

    public async Task LoginAsync(string username, string password)
    {
        logger.Information($"Logging in as {username}");

        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(password);

        await LoginButton.ClickAsync();
    }

    public async Task LogoutAsync()
    {
        logger.Information($"Opening burger menu");
        await BurgerMenuButton.ClickAsync();
        logger.Information($"Clicking logout button");
        await LogoutButton.ClickAsync();
    }
}
