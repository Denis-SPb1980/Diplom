using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.BussinesObject.PageObjects
{
    internal class BasketPage : BasePage
    {
        private By DeleteButton = By.ClassName("icon-trash");
        private By ProceedToCheckoutBatton = By.XPath("//*[@class = 'button btn btn-default standard-checkout button-medium']");



        public const string url = "http://prestashop.qatestlab.com.ua/ru/order";

        public override BasketPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        
        public AuthenticationPage GoAuthenticationPage()
        {
            driver.FindElement(ProceedToCheckoutBatton).Click();
            return new AuthenticationPage();
        }

    }
}
