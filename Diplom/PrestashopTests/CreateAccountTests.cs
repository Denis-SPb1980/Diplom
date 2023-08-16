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

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'header_user_info']/a[@class = 'account']")));
        }

        [Test(Description = "Negative test create account")]

        public void CreateAccountTestWithOutName()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account");

            new LoginPage()
                .OpenPage()
                .FillEmailAndGoToCreateAccount()
                .CreateNewUserWithOutName();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'alert alert-danger']/ol/li[contains(text(),'is required')]")));
        }
    }
}
