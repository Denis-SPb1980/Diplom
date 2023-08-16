using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class PopUpBasketPage : BasePage
    {
        private By ContinuePurchasesButton = By.XPath("//*[@class = 'icon-chevron-left left']");
        private By CheckoutButton = By.XPath("//*[@class = 'btn btn-default button button-medium']/span");

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override PopUpBasketPage OpenPage() => this;

        [AllureStep]
        public HomePage ContinuePurchases()
        {
            logger.Info("Continue shopping selected");
            driver.FindElement(ContinuePurchasesButton).Click();
            return new HomePage();
        }

        [AllureStep]
        public BasketPage PurchasesCompletedGoToBasket()
        {
            logger.Info("Purchases completed went to cart");
            driver.FindElement(CheckoutButton).Click();
            AllureHelper.ScreenShot();
            return new BasketPage();
        }
    }
}
