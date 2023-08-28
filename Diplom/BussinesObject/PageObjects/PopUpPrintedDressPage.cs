using Diplom.Core;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace Diplom.BussinesObject.PageObjects
{
    public class PopUpPrintedDressPage : BasePage
    {
        private By AddToCartButton = By.XPath("//*[@class = 'exclusive']");
        private IWebElement iframe = Browser.Instance.Driver.FindElement(By.XPath("//iframe[contains(@class, 'fancybox-iframe')]"));
        private By SizeDropDown = By.Id("group_1");
        public override PopUpPrintedDressPage OpenPage() => this;

        [AllureStep]
        public PopUpBasketPage AddToCartGoToPopUpBasket()
        {
            Browser.Instance.SwitchToFrame(iframe);
            SelectElement select = new SelectElement(driver.FindElement(SizeDropDown));
            select.SelectByIndex(2);
            driver.FindElement(AddToCartButton).Click();
            return new PopUpBasketPage();
        }
    }
}