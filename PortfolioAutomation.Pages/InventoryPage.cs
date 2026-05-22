using Microsoft.Playwright;

namespace PortfolioAutomation.Pages
{
    public class InventoryPage
    {
        private readonly IPage page;

        public InventoryPage(IPage page) => this.page = page;

        public ILocator InventoryContainer => page.Locator("#inventory_container");
    }
}
