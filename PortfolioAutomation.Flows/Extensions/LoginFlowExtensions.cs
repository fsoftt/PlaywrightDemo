using Microsoft.Playwright;
using PortfolioAutomation.Core.Extensions;
using PortfolioAutomation.Pages.Pages;
using PortfolioAutomation.TestData;

namespace PortfolioAutomation.Flows.Extensions
{
    public static class LoginFlowExtensions
    {
        public static async Task<InventoryPage> Login(this IPage page)
        {
            await page.GoToHomePage();

            var loginFlow = new LoginFlow(page);
            return await loginFlow.LoginAsAsync(Auth.WorkingUser, Auth.Password);
        }
    }
}
