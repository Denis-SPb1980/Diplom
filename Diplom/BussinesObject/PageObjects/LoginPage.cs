using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class LoginPage : BasePage
    {
        private By EmailAddressInput = By.Id("email_create");
        private By CreateAccountButton = By.Id("SubmitCreate");
        private By RegisteredEmailAddressInput = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By SignInButton = By.Id("SubmitLogin");
        private static By MessageErrorAuthenticationFailed = By.XPath("//*[@class = 'alert alert-danger']/ol/li[contains(text(),'Authentication failed')]");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [AllureStep]
        public override LoginPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public CreateAccountPage FillEmailAndGoToCreateAccount()
        {
            var user = UserBuilder.GetUserDataEmail();
            InputMailAddress(user);
            logger.Info($"Try to input mail adress EMail: {user.EMail}");
            return new CreateAccountPage();
        }

        [AllureStep]
        public void InputMailAddress(UserAddressEmailModel user)
        {
            var email = UserBuilder.GetUserDataEmail();
            driver.FindElement(EmailAddressInput).SendKeys(user.EMail);
            driver.FindElement(CreateAccountButton).Click();
        }

        [AllureStep]
        public MyAccountPage LoginAsStandartUser()
        {
            var customer = UserBuilder.GetStandandartUser();
            logger.Info($"Login as standart user {customer}");
            TryToLogin(customer);
            return new MyAccountPage();
        }

        [AllureStep("Try to login")]
        public void TryToLogin(UserLoginModel customer)
        {
            driver.FindElement(RegisteredEmailAddressInput).SendKeys(customer.Mail);
            driver.FindElement(PasswordInput).SendKeys(customer.Password);
            driver.FindElement(SignInButton).Click();
        }

        [AllureStep]
        public static bool CheckingErrorAuthentication()
        {
            try
            {
                Browser.Instance.Driver.FindElement(MessageErrorAuthenticationFailed);
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