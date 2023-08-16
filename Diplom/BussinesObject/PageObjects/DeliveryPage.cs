using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class DeliveryPage : BasePage
    {
        private By DeliveryNextDayButtoon = By.XPath("//*[@class = 'delivery_options']/div[2]/div/table/tbody/tr/td[1]/div/span");
        private By AgreeChekBox = By.Id("cgv");
        private By ProceedToCheckoutBatton = By.XPath("//*[@class = 'button btn btn-default standard-checkout button-medium']");
        private By ErrorMessage = By.ClassName("fancybox-error");

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string url = "http://prestashop.qatestlab.com.ua/ru/order";

        [AllureStep]
        public override DeliveryPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public PaymentPage СhoiceDeliveryGoToPaymentPage()
        {
            driver.FindElement(DeliveryNextDayButtoon).Click();
            driver.FindElement(AgreeChekBox).Click();
            driver.FindElement(ProceedToCheckoutBatton).Click();
            AllureHelper.ScreenShot();
            return new PaymentPage();
        }
    }
}
