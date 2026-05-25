using PortfolioAutomation.Core.Extensions;
using PortfolioAutomation.Flows;
using PortfolioAutomation.Flows.Extensions;
using PortfolioAutomation.Pages.Pages;
using PortfolioAutomation.TestData;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioAutomation.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class InventoryTests : TestBase
    {
        // TODO: move this to base class and make it overridable
        [SetUp]
        public async Task Setup()
        {
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await ScreenshotIfFailed();
            await context.CloseAsync();
        }

        public async Task Inventory_HasElements()
        {
            Assert.That(true, Is.True);
        }

        public async Task Inventory_WhenOrderedAlphabetically_AreCorrectlyOrdered()
        {
            Assert.That(true, Is.True);
        }

        public async Task Inventory_WhenOrderedAlphabeticallyDescending_AreCorrectlyOrdered()
        {
            Assert.That(true, Is.True);
        }

        public async Task Inventory_WhenOrderedByPrice_AreCorrectlyOrdered()
        {
            Assert.That(true, Is.True);
        }

        public async Task Inventory_WhenOrderedByPriceDescending_AreCorrectlyOrdered()
        {
            Assert.That(true, Is.True);
        }

        public async Task Inventory_WhenImageClicked_IsRedirectedToItemPage()
        {
            Assert.That(true, Is.True);
        }

        public async Task Inventory_WhenTitleClicked_IsRedirectedToItemPage()
        {
            Assert.That(true, Is.True);
        }

        public async Task Inventory_WhenAddedOrRemovedFromCart_CartIsUpdated()
        {
            Assert.That(true, Is.True);
        }

        public async Task Inventory_WhenCartIsViewed_ItemsAreDisplayed()
        {
            Assert.That(true, Is.True);
        }
    }
}
