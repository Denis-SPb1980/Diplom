using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using OpenQA.Selenium;

namespace Diplom.PrestashopTests
{
    internal class LogOutTest : BaseTest
    {
        [Test(Description = "Login and logout of account")]

        public void LoginAndLogoutOfAccount()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
                .GoToLogin()
                .FillEmailAndGoToCreateAccount()
                .CreateNewUserAndGoToMyAccount()
                .Logout();

           Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.Id("SubmitCreate")));
        }
    }
}
