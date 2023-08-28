using Diplom.Core;
using NLog;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }
        public abstract BasePage OpenPage();

        public static bool CheckElementOnPage(By locator)
        {
            try
            {
                Browser.Instance.Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                logger.Info($"Еlement not found");
                return false;
            }
        }
    }
}