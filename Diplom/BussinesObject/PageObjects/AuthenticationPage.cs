using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class AuthenticationPage : BasePage
    {
        private By UserMailInput = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By SubmitLoginButtom = By.Id("SubmitLogin");

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string url =
        "http://prestashop.qatestlab.com.ua/ru/authentication?multi-shipping=0&display_guest_checkout=0&back=http%3A%2F%2Fprestashop.qatestlab.com.ua%2Fru%2Forder%3Fstep%3D1%26multi-shipping%3D0";

        [AllureStep]
        public override AuthenticationPage OpenPage()
        {
            logger.Info("Authentication page opened");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public AddressesPage ContinueStandartUser()
        {
            logger.Info("Authentication standart user");
            new LoginPage().LoginAsStandartUser();
            AllureHelper.ScreenShot();
            return new AddressesPage();
        }

        [AllureStep]
        public AddressesPage СontinueNewUser()
        {
            logger.Info("Authentication new user");
            new LoginPage().FillEmailAndGoToCreateAccount();
            new CreateAccountPage().CreateNewUserAndGoToMyAccount();
            return new AddressesPage();
        }
    }
}
