using Diplom.Core;
using OpenQA.Selenium;


namespace Diplom.BussinesObject.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }

        public abstract BasePage OpenPage();
    }
       
}

