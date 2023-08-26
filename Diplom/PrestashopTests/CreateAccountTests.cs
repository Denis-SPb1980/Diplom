using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using OpenQA.Selenium;

namespace Diplom.PrestashopTests
{
    internal class CreateAccountTests : BaseTest
    {
        [Test(Description = "Positive test create account")]
        public void CreateAccount()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
                .GoToLogin()
                .FillEmailAndGoToCreateAccount()
                .CreateNewUserAndGoToMyAccount();
            Assert.IsTrue(HomePage.CheckingUsersDisplay(),"Элемент не найден на странице");
        }

        [Test(Description = "Negative test create account")]
        public void CreateAccountTestWithOutName()
        {
            new LoginPage()
                .OpenPage()
                .FillEmailAndGoToCreateAccount()
                .CreateNewUserWithOutName();
        }
    }
}
