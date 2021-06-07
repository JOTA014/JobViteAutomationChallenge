using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JobViteAutomationChallenge.Helper
{
    public class BaseClass : IDisposable
    {
        protected RemoteWebDriver driver;
        static string chromeDriverPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public void GetChromeDriver()
        {
            driver = new ChromeDriver(chromeDriverPath);
            MaximizeWindows();
        }

        public void GetMozillaDriver()
        {
            driver = new FirefoxDriver(chromeDriverPath);
        }

        public void Dispose()
        {
            driver.Quit();
        }

        private void MaximizeWindows()
        {
            driver.Manage().Window.Maximize();
        }
    }
}
