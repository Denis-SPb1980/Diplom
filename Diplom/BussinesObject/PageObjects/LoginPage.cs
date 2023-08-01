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


        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account";
        public override BasePage OpenPage()
        {
            throw new NotImplementedException();
        }

        public CreateAccountPage GoToCreateAccount()
        {
            driver.FindElement(EmailAddressInput).SendKeys("test1980@mail.ru");
            driver.FindElement(CreateAccountButton).Click();
            return new CreateAccountPage();
        }
    }
}
