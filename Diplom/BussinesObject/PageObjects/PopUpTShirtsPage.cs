using Diplom.Core;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace Diplom.BussinesObject.PageObjects
{
    public class PopUpTShirtsPage : BasePage
    {
        private By AddToCartButton = By.XPath("//*[@class = 'exclusive']");
        private IWebElement iframe = Browser.Instance.Driver.FindElement(By.XPath("//iframe[contains(@class, 'fancybox-iframe')]"));
        private By SizeDropDown = By.Id("group_1");

        public override PopUpTShirtsPage OpenPage() => this;

        [AllureStep]
        public PopUpBasketPage GoToPopUpBasket()
        {
            Browser.Instance.SwitchToFrame(iframe);
            driver.FindElement(AddToCartButton).Click();
            AllureHelper.ScreenShot();
            return new PopUpBasketPage();
        }
    }
}
