using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class BasketPage : BasePage
    {
        private By DeleteButton = By.ClassName("icon-trash");
        private By ProceedToCheckoutBatton = By.XPath("//*[@class = 'button btn btn-default standard-checkout button-medium']");
        private By ProductsInBasket = By.XPath("//*[@id = 'cart_summary']/tbody/*[contains(@id,'product')]");

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string url = "http://prestashop.qatestlab.com.ua/ru/order";

        [AllureStep]
        public override BasketPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public AuthenticationPage GoAuthenticationPage()
        {
            driver.FindElement(ProceedToCheckoutBatton).Click();
            AllureHelper.ScreenShot();
            return new AuthenticationPage();
        }

        [AllureStep]
        public void CheckingAvailabilityProductsInCart()
        {
            var elements = Browser.Instance.Driver.FindElements(ProductsInBasket);
            Assert.That(elements.Count, Is.EqualTo(2), "Количество элементов не равно ожидаемому");
        }
    }
}