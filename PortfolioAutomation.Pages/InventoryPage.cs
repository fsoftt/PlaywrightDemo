using Microsoft.Playwright;

namespace PortfolioAutomation.Pages
{
    public class InventoryPage : PageBase
    {
        public InventoryPage(IPage page) : base(page) { }

        public ILocator InventoryContainer => Page.Locator("#inventory_container");
    }
}
