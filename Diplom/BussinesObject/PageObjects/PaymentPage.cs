using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Diplom.BussinesObject.PageObjects
{
    public class PaymentPage : BasePage
    {
        private By PaymentBankTransferButton = By.ClassName("bankwire");
        private By PaymentChekButton = By.ClassName("cheque");
        private By CurrencyСhoiceDropDawn = By.Id("currency_payement");
        private By ValidePurchaseButton = By.XPath("//*[@class = 'button btn btn-default button-medium']");

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string url = "http://prestashop.qatestlab.com.ua/ru/order?multi-shipping=";

        [AllureStep]
        public override PaymentPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        
        [AllureStep]
        public void PaymentByBankTransfer()
        {
            logger.Info($"The transition to payment by bank transfer has been completed");
            driver.FindElement(PaymentBankTransferButton).Click();
            SelectCurrency();
            driver.FindElement(ValidePurchaseButton).Click();
        }

        [AllureStep]
        public void PaymentByCheck()
        {
            logger.Info($"The transition to payment by check has been completed");
            driver.FindElement(PaymentChekButton).Click();
            SelectCurrency();
            driver.FindElement(ValidePurchaseButton).Click();
            AllureHelper.ScreenShot();
        }

        [AllureStep]
        public void SelectCurrency()
        {
            logger.Info($"Сurrency selection");
            var Random = new Random();
            var num = Random.Next(1,3);
            var select = new SelectElement(driver.FindElement(CurrencyСhoiceDropDawn));
            select.SelectByIndex(num);
        }
    }
}
