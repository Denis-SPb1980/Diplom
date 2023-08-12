using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.PrestashopTests
{
    public class AddAddressUser : BaseTest
    {
        [Test]
        public void AddAddressNewUser()
        {


            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account");

            Thread.Sleep(1000);

            new LoginPage()
                .GoToCreateAccount()
                .GoToMyAccount()
                .GoToAddressesPage()
                .FillUserAddress();

            //    Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'header_user_info']/a[@class = 'account']")));
            //}

        }
    }
}
