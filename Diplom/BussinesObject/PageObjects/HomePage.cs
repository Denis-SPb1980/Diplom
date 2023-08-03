using Diplom.Core;
using OpenQA.Selenium;

namespace Diplom.BussinesObject.PageObjects
{
    internal class HomePage : BasePage
    {
        private By LoginButton = By.ClassName("login");
        private By BasketButton = By.XPath("//*[@class = 'shopping_cart']/a");

        private By QuickPrintedSummerDress = By.;








        public const string url = "http://prestashop.qatestlab.com.ua/ru/";

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public LoginPage GoToLogin()
        {
            driver.FindElement(LoginButton).Click();
            return new LoginPage();
        }
    }
}
