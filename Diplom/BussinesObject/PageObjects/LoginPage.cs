using Bogus;
using Diplom.Core;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public CreateAccountPage GoToCreateAccount()
        {

            var user = UserBuilder.GetAddressEmail();

            InputMailAdress(user);
            return new CreateAccountPage();
        }

        public void InputMailAdress(UserAddressEmailModel user)
        {
            var email = UserBuilder.GetAddressEmail();

            driver.FindElement(EmailAddressInput).SendKeys(user.EMail);
            driver.FindElement(CreateAccountButton).Click();
            
        }
    }
}
