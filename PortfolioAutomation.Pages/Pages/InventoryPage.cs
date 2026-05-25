using Microsoft.Playwright;
using PortfolioAutomation.Models.Mappers;
using PortfolioAutomation.Models.Models;

namespace PortfolioAutomation.Pages.Pages
{
    public class InventoryPage : PageBase
    {
        public ILocator InventoryContainer => Page.Locator("#inventory_container");
        public ILocator SortSelect => Page.Locator("[data-test='product-sort-container']");
        public ILocator InventoryItems => Page.Locator(".inventory_item");
        public ILocator ShoppingCartLink => Page.Locator("[data-test='shopping-cart-link']");
        public ILocator ShoppingCartItemsCount => Page.Locator("[data-test='shopping-cart-badge']");

        public InventoryPage(IPage page) : base(page) { }

        public async Task SortBy(SortOptions sortOption)
        {
            string optionLabel = sortOption switch
            {
                SortOptions.NameAsc => "Name (A to Z)",
                SortOptions.NameDesc => "Name (Z to A)",
                SortOptions.PriceAsc => "Price (low to high)",
                SortOptions.PriceDesc => "Price (high to low)",
                _ => throw new ArgumentOutOfRangeException(nameof(sortOption), $"Unsupported sort option: {sortOption}")
            };

            await SortSelect.SelectOptionAsync(new SelectOptionValue { Label = optionLabel });
        }

        public async Task<int> GetInventoryItemCount()
        {
            return await InventoryItems.CountAsync();
        }

        public async Task<int> GetShoppingCartItemsCount()
        {
            var countText = await ShoppingCartItemsCount.InnerTextAsync();
            return int.Parse(countText);
        }

        public async Task<IEnumerable<Product>> GetInventoryItems()
        {
            var items = new List<Product>();
            int itemCount = await GetInventoryItemCount();

            for (int i = 0; i < itemCount; i++)
            {
                ILocator itemLocator = InventoryItems.Nth(i);
                Product product = await ProductMapper.MapAsync(itemLocator);

                items.Add(product);
            }

            return items;
        }

        public async Task GoToShoppingCart()
        {
            await ShoppingCartLink.ClickAsync();
        }
    }
}
