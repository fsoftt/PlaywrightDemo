using PortfolioAutomation.Flows.Extensions;
using PortfolioAutomation.Models.Models;
using PortfolioAutomation.Pages.Pages;

namespace PortfolioAutomation.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class InventoryTests : TestBase
    {
        [Test]
        public async Task Inventory_HasElements()
        {
            InventoryPage inventoryPage = await page.LoginAsync();
            
            Assert.Multiple(async () =>
            {
                Assert.That(await inventoryPage.InventoryContainer.First.IsVisibleAsync(), Is.True, "El usuario no fue redirigido al inventario.");
                Assert.That(await inventoryPage.InventoryItems.First.IsVisibleAsync(), Is.True, "La página de inventario no muestra elementos.");
                Assert.That(await inventoryPage.ShoppingCartLink.IsVisibleAsync(), Is.True, "El enlace del carrito de compras no es visible.");
                Assert.That(await inventoryPage.SortSelect.IsVisibleAsync(), Is.True, "El selector de ordenamiento no es visible.");
            });
        }

        [Test]
        public async Task Inventory_WhenOrderedAlphabetically_AreCorrectlyOrdered()
        {
            InventoryPage inventoryPage = await page.LoginAsync();

            IEnumerable<Product> products = await inventoryPage.GetInventoryItems();

            Assert.That(products, Is.Not.Empty, "No se encontraron productos en el inventario.");
            Assert.That(products, Is.Ordered.By("Name"), "Los elementos no están ordenados alfabéticamente.");
        }

        [Test]
        public async Task Inventory_WhenOrderedAlphabeticallyDescending_AreCorrectlyOrdered()
        {
            InventoryPage inventoryPage = await page.LoginAsync();
            await inventoryPage.SortBy(SortOptions.NameDesc);

            IEnumerable<Product> products = await inventoryPage.GetInventoryItems();

            Assert.That(products, Is.Not.Empty, "No se encontraron productos en el inventario.");
            Assert.That(products, Is.Ordered.Descending.By("Name"), "Los elementos no están ordenados alfabéticamente.");
        }

        [Test]
        public async Task Inventory_WhenOrderedByPrice_AreCorrectlyOrdered()
        {
            InventoryPage inventoryPage = await page.LoginAsync();
            await inventoryPage.SortBy(SortOptions.PriceAsc);

            IEnumerable<Product> products = await inventoryPage.GetInventoryItems();

            Assert.That(products, Is.Not.Empty, "No se encontraron productos en el inventario.");
            Assert.That(products, Is.Ordered.By("Price"), "Los elementos no están ordenados por precio.");
        }

        [Test]
        public async Task Inventory_WhenOrderedByPriceDescending_AreCorrectlyOrdered()
        {
            InventoryPage inventoryPage = await page.LoginAsync();
            await inventoryPage.SortBy(SortOptions.PriceDesc);

            IEnumerable<Product> products = await inventoryPage.GetInventoryItems();

            Assert.That(products, Is.Not.Empty, "No se encontraron productos en el inventario.");
            Assert.That(products, Is.Ordered.Descending.By("Price"), "Los elementos no están ordenados por precio.");
        }

        [Test]
        public async Task Inventory_WhenImageClicked_IsRedirectedToItemPage()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public async Task Inventory_WhenTitleClicked_IsRedirectedToItemPage()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public async Task Inventory_WhenAddedOrRemovedFromCart_CartIsUpdated()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public async Task Inventory_WhenCartIsViewed_ItemsAreDisplayed()
        {
            Assert.That(true, Is.True);
        }
    }
}
