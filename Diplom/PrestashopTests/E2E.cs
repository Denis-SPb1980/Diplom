using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Diplom.PrestashopTests
{
    internal class E2E : BaseTest
    {
        [Test(Description = "Positive test of dress sales")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [AllureOwner("Denis")]
        [Description("PurchaseDress")]
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
            Assert.IsTrue(PaymentPage.CheckingAvailabilityProductsInCart(), "Элемент не найден на странице");
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
            Assert.IsTrue(PaymentPage.CheckingAvailabilityProductsInCart(), "Элемент не найден на странице");
        }

        [Test(Description = "Positive test of T-shirts and blouses sales")]
        public void PurchaseTShirtsAndBlouse()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
                .AddToCartBlouseGoToPopUpBasketPage()
                .ContinuePurchases()
                .AddToCartTShirtsGoToPopUpBasketPage()
                .PurchasesCompletedGoToBasket()
                .CheckingAvailabilityProductsInCart();
            new BasketPage()
                .GoAuthenticationPage()
                .СontinueNewUser()
                .FillUserAddressWithoutSelectCountryAndGoToDeliveryPage()
                .AgreeToTermsGoToPaymentPage();
        }
    }
}
