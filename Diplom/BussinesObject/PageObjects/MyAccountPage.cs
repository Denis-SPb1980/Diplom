using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class MyAccountPage : BasePage
    {
        private By AddAddresButton = By.XPath("//*[@id='center_column']/div/div[1]/ul/li[1]/a");
        private By LogoutButton = By.ClassName("logout");
        private By CreateAccountButton = By.Id("SubmitCreate");

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string url = "http://prestashop.qatestlab.com.ua/ru/my-account";

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public AddressesPage GoToAddressesPage()
        {
            driver.FindElement(AddAddresButton).Click();
            return new AddressesPage();
        }

        [AllureStep]
        public void Logout()
        {
            logger.Info($"Account has been logged out");
            driver.FindElement(LogoutButton).Click();
            Assert.IsTrue(BasePage.CheckElementOnPage(CreateAccountButton), "Элемент не найден на странице");
        }
    }
}
