using Bogus;
using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class LoginPage : BasePage
    {
        private By EmailAddressInput = By.Id("email_create");
        private By ErrorMessage = By.XPath("//*[@id = 'create_account_error']/ol/li");
        private By CreateAccountButton = By.Id("SubmitCreate");

        private By RegisteredEmailAddressInput = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By SignInButton = By.Id("SubmitLogin");


        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override LoginPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public CreateAccountPage GoToCreateAccount()
        {

            var user = UserBuilder.GetUserDataLogin();

            InputMailAdress(user);
            return new CreateAccountPage();
        }

        public void InputMailAdress(UserCreateModel user)
        {
            var email = UserBuilder.GetUserDataLogin();

            driver.FindElement(EmailAddressInput).SendKeys(user.EMail);
            driver.FindElement(CreateAccountButton).Click();
            
        }

        public MyAccountPage LoginAsStandartUser()
        {
            var customer = UserBuilder.GetStandandartUser();
            TryToLogin(customer);

            return new MyAccountPage();
        }

        //public AddressPage LoginAndGoToAdressPage()
        //{
        //    var user = UserBuilder.GetStandandartUser();
        //    TryToLogin(user);

        //    return new AddressPage();
        //}

        public void TryToLogin(UserLoginModel customer)
        {
            driver.FindElement(RegisteredEmailAddressInput).SendKeys(customer.Mail);
            driver.FindElement(PasswordInput).SendKeys(customer.Password);
            driver.FindElement(SignInButton).Click();
        }
    }
}
