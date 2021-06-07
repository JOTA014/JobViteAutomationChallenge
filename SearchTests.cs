using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using Xunit;
using JobViteAutomationChallenge.Helper;
using JobViteAutomationChallenge.PageObject;

namespace JobViteAutomationChallenge
{
    public class SearchTests : BaseClass
    {
        private AutomationPracticePO automationPracticePO;
        public SearchTests()
        {
            GetChromeDriver();
            automationPracticePO = new AutomationPracticePO(driver);
        }
        [Fact]
        public void SearchProductAndCheckItsReturned()
        {
            var productToSearch = "dress";
            var specificProduct = "Printed Summer Dress";
            automationPracticePO.GoToPage();
            automationPracticePO.SearchProduct(productToSearch);
            var result = automationPracticePO.CheckSearchResults(specificProduct);
            automationPracticePO.TakeScreenshot("SearchProductAndCheckItsReturned");
            Assert.True(result);
        }
        
        [Fact]
        public void SearchProductAndCheckItsNOTReturned()
        {
            var productToSearch = "dress";
            var specificProduct = "Pants";
            automationPracticePO.GoToPage();
            automationPracticePO.SearchProduct(productToSearch);
            var result = automationPracticePO.CheckSearchResults(specificProduct);
            automationPracticePO.TakeScreenshot("SearchProductAndCheckItsNOTReturned");
            Assert.False(result);
        }

        //All searchResult must include the keywords used to search
        [Fact]
        public void CheckSearchResultOnlyIncludesProductsWithKeyWords()
        {
            var productToSearch = "dress";
            automationPracticePO.GoToPage();
            automationPracticePO.SearchProduct(productToSearch);
            var result = automationPracticePO.AllResultsContainsKeyWords(productToSearch);
            automationPracticePO.TakeScreenshot("CheckSearchResultOnlyIncludesProductsWithKeyWords");
            Assert.True(result);
        }

    }
}
