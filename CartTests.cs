using Xunit;
using JobViteAutomationChallenge.Helper;
using JobViteAutomationChallenge.PageObject;

namespace JobViteAutomationChallenge
{
    public class CartTests: BaseClass
    {
        private AutomationPracticePO automationPracticePO;
        public CartTests()
        {
            GetChromeDriver();
            automationPracticePO = new AutomationPracticePO(driver);
        }

        [Fact]
        public void AddProuctFromSearch()
        {
            var productToSearch = "dress";
            var specificProduct = "Printed Summer Dress";
            automationPracticePO.GoToPage();
            automationPracticePO.SearchProduct(productToSearch);
            automationPracticePO.AddToCartFromResult(specificProduct);
            var isCarEmpty = automationPracticePO.IsCarEmpty();
            automationPracticePO.TakeScreenshot("SearchProductAndCheckItsReturned");
            Assert.False(isCarEmpty);
        }

        [Fact]
        public void AddProuctFromCategories()
        {
            var specificProduct = "Faded Short Sleeve T-shirts";
            automationPracticePO.GoToPage();
            automationPracticePO.ClickCategory("Women");
            automationPracticePO.AddToCartFromResult(specificProduct);
            var isCarEmpty = automationPracticePO.IsCarEmpty();
            automationPracticePO.TakeScreenshot("SearchProductAndCheckItsReturned");
            Assert.False(isCarEmpty);
        }

        [Fact]
        public void CheckCartNumerOfAddedItems()
        {
            var numberOfItemsToAdd = 2;
            var productToSearch = "dress";
            var specificProduct = "Printed Summer Dress";
            automationPracticePO.GoToPage();
            automationPracticePO.SearchProduct(productToSearch);
            automationPracticePO.AddToCartFromResult(specificProduct);
            automationPracticePO.ClickCategory("Women");
            automationPracticePO.AddToCartFromResult(specificProduct);
            Assert.True(automationPracticePO.CheckNumberOfItemsInCart(numberOfItemsToAdd));
        }

        [Fact]
        public void TestRemoveItems()
        {
            var productToSearch = "dress";
            var specificProduct = "Printed Summer Dress";
            automationPracticePO.GoToPage();
            automationPracticePO.SearchProduct(productToSearch);
            automationPracticePO.AddToCartFromResult(specificProduct);

            var specificProduct2 = "Faded Short Sleeve T-shirts";
            automationPracticePO.GoToPage();
            automationPracticePO.ClickCategory("Women");
            automationPracticePO.AddToCartFromResult(specificProduct2);


            var numberOfItemsToAdd = 2;
            var wereAlloriginallyAdded = automationPracticePO.CheckNumberOfItemsInCart(numberOfItemsToAdd);
            Assert.True(wereAlloriginallyAdded);
            automationPracticePO.RemoveAnyItemFromCart();
            var wasItemRemovedFromCart = automationPracticePO.CheckNumberOfItemsInCart(1);
            Assert.True(wasItemRemovedFromCart);
        }

        [Fact]
        public void ProceedToCheckOutFromCart()
        {
            var productToSearch = "dress";
            var specificProduct = "Printed Summer Dress";
            automationPracticePO.GoToPage();
            automationPracticePO.SearchProduct(productToSearch);
            automationPracticePO.AddToCartFromResult(specificProduct);

            automationPracticePO.GoToCheckoutFromCart();
            var result = automationPracticePO.AreWeOnCheckoutPage();
            Assert.True(result);
        }
    }
}
