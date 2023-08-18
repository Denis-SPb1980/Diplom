using Diplom.Core.Configuration;
using OpenQA.Selenium;

namespace Diplom.Core
{
    public class Browser
    {
        private static readonly ThreadLocal<Browser> BrowserInstances = new();

        public static Browser Instance => GetBrowser();
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }
        private static Browser GetBrowser()
        {
            return BrowserInstances.Value ??= new Browser();
        }

        //Choose browser
        private Browser() 
        {
            driver = AppConfiguration.Browser.BrowserType.ToLower() switch
            {
                "chrome" => DriverFactory.GetChromeDriver(),
                "firefox" => DriverFactory.GetFirefoxDriver(),
                _ => DriverFactory.GetChromeDriver()
            };

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AppConfiguration.Browser.ImplicityWait);
            driver.Manage().Window.Maximize();
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void SwitchToFrame(IWebElement element)
        {
            driver.SwitchTo().Frame(element);
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            BrowserInstances.Value = null;
            driver = null;
        }
    }
}
