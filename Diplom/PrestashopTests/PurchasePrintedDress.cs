using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.PrestashopTests
{
    internal class PurchaseDresses : BaseTest
    {
        [Test(Description = "Positive test of dress sales")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [AllureOwner("Denis")]
        [Description("PurchaseDress")]
        //[AllureTms("Azure")]
        ////[AllureIssue("Azure 420420")]

        public void PurchaseDress()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
                .ChooseDressAndGoToPopUpPrintedDress()
                .AddToCartGoToPopUpBasket()
                .PurchasesCompletedGoToBasket()
                .GoAuthenticationPage()
                .СontinueNewUser()
                .FillUserAddressAndGoToDeliveryPage()
                .СhoiceDeliveryGoToPaymentPage()
                .PaymentByBankTransfer();

           Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'shopping_cart']/a/span[5]")));
        }

        [Test(Description = "Positive test of T-shirts sales")]

        public void PurchaseTShirts()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
                .ChooseTShirtsAndGoToPopUpTSirts()
                .GoToPopUpBasket()
                .PurchasesCompletedGoToBasket()
                .GoAuthenticationPage()
                .ContinueStandartUser()
                .GoToDeliveryPage()
                .СhoiceDeliveryGoToPaymentPage()
                .PaymentByCheck();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'shopping_cart']/a/span[5]")));
        }

        [Test(Description = "Adding T-shirts and blouses to the shopping cart)")]

        public void PurchaseTShirtsAndBlouse()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
                .AddToCartBlouseGoToPopUpBasketPage()
                .ContinuePurchases()
                .AddToCartTShirtsGoToPopUpBasketPage()
                .PurchasesCompletedGoToBasket();

            var elements = Browser.Instance.Driver.FindElements(By.XPath("//*[@id = 'cart_summary']/tbody/*[contains(@id,'product')]"));
            Assert.That(elements.Count, Is.EqualTo(2));
        }
    }
}
