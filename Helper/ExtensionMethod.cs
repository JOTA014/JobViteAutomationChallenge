using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace JobViteAutomationChallenge.Helper
{
    public static class ExtensionMethod
    {
        public static void SetViewportSize(this RemoteWebDriver driver, int width, int height)
        {
            var jsGetPadding = @"return [ window.outerWidth - window.innerWidth,window.outerHeight - window.innerHeight ];";
            var paddingArray = driver.ExecuteScript(jsGetPadding) as ReadOnlyCollection<object>;
            driver.Manage().Window.Size = new Size(width + int.Parse(paddingArray[0].ToString()), height + int.Parse(paddingArray[1].ToString()));

        }
    }
}
