using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;


namespace Diplom.BussinesObject.PageObjects
{
    internal class PopUpBasketPage : BasePage
    {
        private By ContinuePurchasesButton = By.XPath("//*[@class = 'icon-chevron-left left']");
        private By CheckoutButton = By.CssSelector("//*[@class = 'btn btn-default button button-medium']/span");

        private static Logger logger = LogManager.GetCurrentClassLogger();

        //public PopUpCartPage()
        //{
        //    WaitHelper.WaitElement(driver, CheckoutButton);
        //}

        public override PopUpBasketPage OpenPage() => this;

        
        public void ContinuePurchases()
        {
            logger.Info("Continue shopping selected");
            driver.FindElement(ContinuePurchasesButton).Click();
        }

        public BasketPage GoToBasket()
        {
            logger.Info("Purchases completed went to cart");
            driver.FindElement(CheckoutButton).Click();

            return new BasketPage();
        }
    }
}
