using Diplom.Core;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    public class CreateAccountPage : BasePage
    {
        private By FirstNameInput = By.Id("customer_firstname");
        private By LastNameInput = By.Id("customer_lastname");
        private By PasswordInput = By.Id("passwd");
        private By RegisterButton = By.Id("submitAccount");


        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account#account-creation";

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public MyAccountPage GoToMyAccount()
        {

            var user = UserBuilder.GetUserDataLogin();

            InputUserData(user);
            return new MyAccountPage();
        }

        public void InputUserData(UserCreateModel user)
        {
            driver.FindElement(FirstNameInput).SendKeys(user.FirstName);
            driver.FindElement(LastNameInput).SendKeys(user.LastName);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(RegisterButton).Click();
        }
           

        



    }
}
