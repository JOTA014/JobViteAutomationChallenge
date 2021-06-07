using JobViteAutomationChallenge.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JobViteAutomationChallenge.PageObject
{
    public class AutomationPracticePO
    {
        private IWebDriver Driver;
        private int MaxWaitingTime => int.Parse(ConfigurationHelper.GetConfigValue("MaxWaitingTime"));
        private string contactFormHeader = "Customer service - Contact us";
        public AutomationPracticePO(IWebDriver driver)
        {
            Driver = driver;
        }
        public string Url = "http://automationpractice.com/";
        private IWebElement SearchBar => Driver.FindElement(By.Id("search_query_top"));
        private IWebElement SearchButton => Driver.FindElement(By.Name("submit_search"));
        private IWebElement ContactButton => Driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[2]/a"));
        #region contactForm
        //Contact Form Elements
        private IWebElement ContactUsErrorPanel => Driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div"));
        private IWebElement ContactSubjectHeading => Driver.FindElement(By.Id("id_contact"));
        private IWebElement ContactEmail => Driver.FindElement(By.Id("email"));
        private IWebElement ContactOrderReference => Driver.FindElement(By.Id("id_order"));
        private IWebElement ContactFilePicker => Driver.FindElement(By.Id("fileUpload"));
        private IWebElement ContactMessage => Driver.FindElement(By.Id("message"));
        private IWebElement ContactSendMessage => Driver.FindElement(By.Id("submitMessage"));
        #endregion
        #region Cart
        private IWebElement shoppingCart => Driver.FindElement(By.ClassName("shopping_cart"));
        private IWebElement categories => Driver.FindElement(By.Id("block_top_menu"));
        #endregion
        public void GoToPage()
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(MaxWaitingTime);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(MaxWaitingTime);
            Driver.Navigate().GoToUrl(Url);
        }

        public void SearchProduct(string productName)
        {
            SearchBar.SendKeys(productName);
            SearchButton.Click();
        }

        public bool CheckSearchResults(string productName)
        {
            var products = Driver.FindElements(By.ClassName("product-name"));
            return products.Any(x => x.Text.ToLower().Equals(productName.ToLower()));
        }

        public bool AllResultsContainsKeyWords(string keyWord)
        {
            var products = Driver.FindElements(By.ClassName("product-name"));
            return products.All(x => x.Text.ToLower().Contains(keyWord.ToLower()));
        }

        public void AddToCartFromResult(string productName)
        {
            var products = Driver.FindElements(By.ClassName("product-container"));
            var product = products.FirstOrDefault(y => y.FindElement(By.ClassName("product-name")).Text.Equals(productName));
            ScrollToElement(product);
            HoverElement(product);
            var addToCartButton = product.FindElements(By.TagName("a")).FirstOrDefault(y => y.GetAttribute("title").Equals("Add to cart"));
            addToCartButton.Click();
            ClickOnContinueShopping();
        }

        public bool IsCarEmpty()
        {
            return shoppingCart.FindElements(By.ClassName("ajax_cart_no_product")).First().GetAttribute("style").Equals("display: inline-block;");
        }

        public bool CheckNumberOfItemsInCart(int items)
        {
            ExpandShoppingCart();
            return shoppingCart.FindElement(By.ClassName("ajax_cart_quantity")).Text.Equals(items.ToString());
        }

        private void ClickOnContinueShopping()
        {
            var buttonContainer = Driver.FindElement(By.ClassName("product-container"));
            var continueShoppingButton = buttonContainer.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/span"));
            continueShoppingButton.Click();
        }

        private void HoverElement(IWebElement element)
        {
            var action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }

        private void ScrollToElement(IWebElement element)
        {
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void GoToContactUsForm()
        {
            ContactButton.Click();
        }

        public void ContactSelectAnySubjectHeading()
        {
            var selectElement = new SelectElement(ContactSubjectHeading);
            selectElement.SelectByText("Customer service");
        }

        public void ConctacSetConctacEmail(string email)
        {
            ContactEmail.SendKeys(email);
        }

        public void ConctacSetOrderReference(string orderReference)
        {
            ContactOrderReference.SendKeys(orderReference);
        }

        public void ContactAttachFile(string filePath)
        {
            ContactFilePicker.SendKeys(filePath);            
        }

        public void ContactSetMessage(string message)
        {
            ContactMessage.SendKeys(message);
        }

        public void ContactClickSendMessageButton()
        {
            ContactSendMessage.Click();
        }

        public bool IsThereAContactFormError()
        {
            try
            {
                return ContactUsErrorPanel.Displayed && ContactUsErrorPanel.GetAttribute("class").Equals("alert alert-danger");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void TakeScreenshot(string title)
        {
            ScreenshotHelper.TakeScreenshot(title, Driver);
        }

        public void ClickCategory(string category)
        {
            categories.FindElements(By.TagName("a")).First(l => l.Text.ToLower().Equals(category.ToLower())).Click();
        }

        public void RemoveAnyItemFromCart()
        {
            ScrollToElement(shoppingCart);
            ExpandShoppingCart();
            shoppingCart.FindElements(By.ClassName("ajax_cart_block_remove_link")).First().Click();
            Wait(5, 5);
        }

        private void ExpandShoppingCart()
        {
            var element = Driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[3]/div/div"));
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].style='display: block;'", element);
        }

        //Dirty one, I know. Taken as is from: https://stackoverflow.com/questions/20798752/how-can-i-ask-the-selenium-webdriver-to-wait-for-few-seconds-after-sendkey
        public void Wait(double delay, double interval)
        {
            var now = DateTime.Now;
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(delay));
            wait.PollingInterval = TimeSpan.FromSeconds(interval);
            wait.Until(wd => (DateTime.Now - now) - TimeSpan.FromSeconds(delay) > TimeSpan.Zero);
        }

        public void GoToCheckoutFromCart()
        {
            ScrollToElement(shoppingCart);
            ExpandShoppingCart();
            Driver.FindElement(By.Id("button_order_cart")).Click();
        }

        public bool AreWeOnCheckoutPage()
        {
            Debug.WriteLine(Driver.FindElement(By.Id("cart_title")).Text);
            var result = Driver.FindElement(By.Id("cart_title")).Text.Trim().Contains("SHOPPING-CART SUMMARY");
            Debug.WriteLine(result);
            return result;
        }
    }
}
