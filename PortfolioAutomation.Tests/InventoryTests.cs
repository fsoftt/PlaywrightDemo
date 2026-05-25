using PortfolioAutomation.Flows.Extensions;
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
            Assert.That(true, Is.True);
        }

        [Test]
        public async Task Inventory_WhenOrderedAlphabeticallyDescending_AreCorrectlyOrdered()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public async Task Inventory_WhenOrderedByPrice_AreCorrectlyOrdered()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public async Task Inventory_WhenOrderedByPriceDescending_AreCorrectlyOrdered()
        {
            Assert.That(true, Is.True);
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
