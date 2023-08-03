using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Core
{
    internal class Browser
    {
        private static Browser instance = null;
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }
                return instance;
            }
        }

        private Browser()
        {
            bool isHeadless = false;

            if (isHeadless)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");

                driver = new ChromeDriver(options);
            }
            else
            {
                driver = new ChromeDriver();
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }


        //private Browser()
        //{
        //    driver = AppConfiguration.Browser.BrowserType.ToLower() switch
        //    {
        //        "chrome" => DriverFactory.GetChromeDriver(),
        //        "firefox" => DriverFactory.GetFirefoxDriver(),
        //        _ => DriverFactory.GetChromeDriver()
        //    };

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AppConfiguration.Browser.ImplicityWait);
        //    driver.Manage().Window.Maximize();
        //}

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
        }
    }
}
