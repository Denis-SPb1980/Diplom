using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Diplom.BussinesObject.PageObjects
{
    public class HomePage : BasePage
    {
        private By LoginButton = By.ClassName("login");
        private By BasketButton = By.XPath("//*[@class = 'shopping_cart']/a");

        private By QuickPrintedDress = By.XPath("//*[@id='homefeatured']/li[3]/div/div[1]/div/a[2]/span");
        private By QuickAddTShirts = By.XPath("//*[@id='homefeatured']/li[1]/div/div/div[1]/a[2]/span");
        private By AddDress = By.XPath("//*[@class='product_img_link'][.//*[@title='Printed Dress']][1]");
        private By AddTShirts = By.XPath("//*[@class='product-container']//img[contains(@class,'replace-2x')][contains(@src,'tshirts')][1]");
        private By AddBlouse = By.XPath("//*[@class='product_img_link'][.//*[@title='Blouse']][1]");
        private By AddToCartTShirts = By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]/span");
        private By AddToCartBlouse = By.XPath("//*[@id='homefeatured']/li[2]/div/div[2]/div[2]/a[1]/span");


        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string url = "http://prestashop.qatestlab.com.ua/ru/";

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public LoginPage GoToLogin()
        {
            driver.FindElement(LoginButton).Click();
            return new LoginPage();
        }

        [AllureStep]
        public void ActivateQuickView(By product)
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(product))
                .Perform();
        }

        [AllureStep]
        public PopUpPrintedDressPage ChooseDressAndGoToPopUpPrintedDress()
        {
            logger.Info($"Printed dress quick view activated");
            ActivateQuickView(AddDress);
            driver.FindElement(QuickPrintedDress).Click();
            return new PopUpPrintedDressPage();
        }

        [AllureStep]
        public PopUpTShirtsPage ChooseTShirtsAndGoToPopUpTSirts()
        {
            logger.Info($"TShirt quick view activated");
            ActivateQuickView(AddTShirts);
            driver.FindElement(QuickAddTShirts).Click();
            AllureHelper.ScreenShot();
            return new PopUpTShirtsPage();
        }

        [AllureStep]
        public PopUpBasketPage AddToCartBlouseGoToPopUpBasketPage()
        {
            logger.Info($"Blouse dress quick view activated and added to the cart");
            ActivateQuickView(AddBlouse);
            driver.FindElement(AddToCartBlouse).Click();
            return new PopUpBasketPage();
        }

        [AllureStep]
        public PopUpBasketPage AddToCartTShirtsGoToPopUpBasketPage()
        {
            logger.Info($"TShirts dress quick view activated and added to the cart");
            ActivateQuickView(AddTShirts);
            driver.FindElement(AddToCartTShirts).Click();
            return new PopUpBasketPage();
        }
    }
}
