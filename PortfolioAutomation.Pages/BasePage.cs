using Microsoft.Playwright;

namespace PortfolioAutomation.Pages
{
    public abstract class BasePage
    {
        public readonly IPage Page;

        protected BasePage(IPage page)
        {
            Page = page;
        }

        public virtual async Task WaitForPageLoadAsync()
        {
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        public async Task<string> GetTitleAsync()
        {
            return await Page.TitleAsync();
        }

        public async Task WaitForSelectorAsync(string selector)
        {
            await Page.WaitForSelectorAsync(selector, new PageWaitForSelectorOptions { State = WaitForSelectorState.Visible });
        }

        public async Task ScrollToAsync(string selector)
        {
            await Page.Locator(selector).ScrollIntoViewIfNeededAsync();
        }

        public async Task TakeScreenshotAsync(string filePath)
        {
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = filePath, FullPage = true });
        }
    }
}
