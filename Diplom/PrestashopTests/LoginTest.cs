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

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'header_user_info']/a[@class = 'account']")));
        }

        [Test(Description = "Negative test login unknown user")]
        public void LoginUnknownUser()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account");

            var user = UserBuilder.GetUnknownUser();

            new LoginPage()
                .OpenPage()
                .TryToLogin(user);

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'alert alert-danger']/ol/li[contains(text(),'Authentication failed')]")));
        }
    }
}

