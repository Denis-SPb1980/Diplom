using Diplom.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.BussinesObject.PageObjects
{
    public class MyAccountPage : BasePage
    {
        private By AddAddresButton = By.XPath("//*[@id='center_column']/div/div[1]/ul/li[1]/a");
      

        public const string url = "http://prestashop.qatestlab.com.ua/ru/my-account";

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public AddressesPage GoToAddressesPage()
        {
            driver.FindElement(AddAddresButton).Click();
            return new AddressesPage();
        }


    }
}
