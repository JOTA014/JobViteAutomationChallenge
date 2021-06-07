using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;

namespace JobViteAutomationChallenge.Helper
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(string title, IWebDriver driver)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string screenshotfilename = $"{CreateDirectory(ConfigurationHelper.GetConfigValue("ScreenshotDirectory"))}{Runname}.jpg";
            ss.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Png);
        }

        private static string CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
            return path;
        }
    }
}
