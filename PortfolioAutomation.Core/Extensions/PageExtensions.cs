using Microsoft.Playwright;

namespace PortfolioAutomation.Core.Extensions
{
    public static class PageExtensions
    {
        public static Task<IResponse?> GoToHomePage(this IPage page)
        {
            var homePageUri = Configuration.Get("BaseUrl");

            return page.GotoAsync(homePageUri);
        }
    }
}
