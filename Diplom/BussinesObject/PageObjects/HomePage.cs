using Bogus.DataSets;
using Diplom.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Diplom.BussinesObject.PageObjects
{
    internal class HomePage : BasePage
    {
        private By LoginButton = By.ClassName("login");
        private By BasketButton = By.XPath("//*[@class = 'shopping_cart']/a");

        private By QuickPrintedSummerDress = By.XPath("//*[@id='homefeatured']/li[6]/div/div[1]/div/a[2]/span");
        private By QuickPrintedDress = By.XPath("//*[@id='homefeatured']/li[3]/div/div[1]/div/a[2]/span");
        private By AddDress = By.XPath("//*[@class='product_img_link'][.//*[@title='Printed Dress']][1]");






        public const string url = "http://prestashop.qatestlab.com.ua/ru/";

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public LoginPage GoToLogin()
        {
            driver.FindElement(LoginButton).Click();
            return new LoginPage();
        }

        public void ActivateQuickView(By product)
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(product))
                .Perform();
        }

        //public void ActivateQuickViewDress()
        //{
        //    ActivateQuickView(AddDress);
        //}

        public PopUpPrintedDressPage GoToPopUpPrintedDress()
        {
            ActivateQuickView(AddDress);
            driver.FindElement(QuickPrintedDress).Click();
            return new PopUpPrintedDressPage();
        }
    }
}
