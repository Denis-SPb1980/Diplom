using Diplom.BussinesObject;
using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using OpenQA.Selenium;

namespace Diplom.PrestashopTests
{
    public class LoginTest : BaseTest
    {
        [Test(Description = "Positive test login standart user")]
        public void LoginStandartUser()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
                .GoToLogin()
                .LoginAsStandartUser();
            Assert.IsTrue(HomePage.CheckingUsersDisplay(), "Элемент не найден на странице");
        }

        [Test(Description = "Negative test login unknown user")]
        public void LoginUnknownUser()
        {
            var user = UserBuilder.GetUnknownUser();

            new LoginPage()
                .OpenPage()
                .TryToLogin(user);
            Assert.IsTrue(LoginPage.CheckingErrorAuthentication(), "Элемент не найден на странице");
        }
    }
}

