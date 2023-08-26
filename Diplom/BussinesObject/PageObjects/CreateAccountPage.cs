using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class CreateAccountPage : BasePage
    {
        private By FirstNameInput = By.Id("customer_firstname");
        private By LastNameInput = By.Id("customer_lastname");
        private By PasswordInput = By.Id("passwd");
        private By RegisterButton = By.Id("submitAccount");
        private By MessageErrorIsRequired = By.XPath("//*[@class = 'alert alert-danger']/ol/li[contains(text(),'is required')]");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account#account-creation";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public MyAccountPage CreateNewUserAndGoToMyAccount()
        {
            var user = UserBuilder.GetUserDataLogin();
            InputUserData(user);
            logger.Info($"Create new user FirstName: {user.FirstName} LastName: {user.LastName} Password: {user.Password}");
            return new MyAccountPage();
        }

        [AllureStep]
        public void CreateNewUser()
        {
            var user = UserBuilder.GetUserDataLogin();
            InputUserData(user); 
        }

        [AllureStep]
        public void InputUserData(UserCreateModel user)
        {
            driver.FindElement(FirstNameInput).SendKeys(user.FirstName);
            driver.FindElement(LastNameInput).SendKeys(user.LastName);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(RegisterButton).Click();
        }

        [AllureStep]
        public void CreateNewUserWithOutName()
        {
            var user = UserBuilder.GetUserDataLogin();
            InputUserDataWithOutName(user);
            Assert.IsTrue(BasePage.CheckElementOnPage(MessageErrorIsRequired),"Элемент не найден на странице");
        }

        [AllureStep]
        public void CreateUserWithOutName()
        {
            var user = UserBuilder.GetUserDataLogin();
            InputUserData(user);
        }

        [AllureStep]
        public void InputUserDataWithOutName(UserCreateModel user)
        {
            driver.FindElement(LastNameInput).SendKeys(user.LastName);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(RegisterButton).Click();
        }
    }
}
