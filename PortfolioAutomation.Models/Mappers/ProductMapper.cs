using Microsoft.Playwright;
using PortfolioAutomation.Models.Models;

namespace PortfolioAutomation.Models.Mappers
{
    public static class ProductMapper
    {
        public static async Task<Product> MapAsync(ILocator productLocator)
        {
            var name = await productLocator.Locator(".inventory_item_name").InnerTextAsync();
            var description = await productLocator.Locator(".inventory_item_desc").InnerTextAsync();
            var priceText = await productLocator.Locator(".inventory_item_price").InnerTextAsync();
            var price = decimal.Parse(priceText.Replace("$", ""));
            var imageUrl = await productLocator.Locator(".inventory_item_img img").GetAttributeAsync("src");
            var id = await productLocator.GetAttributeAsync("id");

            return new Product(name, description, price, imageUrl ?? string.Empty, id ?? string.Empty);
        }
    }
}
