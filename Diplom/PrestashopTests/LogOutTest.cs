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
            new LoginPage()
                .OpenPage()
                .FillEmailAndGoToCreateAccount()
                .CreateNewUserAndGoToMyAccount()
                .Logout();
        }
    }
}
