using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using NUnit.Allure.Attributes;
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
        [Test(Description = "AddressInputTest")]
        [AllureTag("Smoke")]
        [AllureOwner("Denis")]
        public void AddAddressNewUser()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account");

            new LoginPage()
                .FillEmailAndGoToCreateAccount()
                .CreateNewUserAndGoToMyAccount()
                .GoToAddressesPage()
                .FillAndSaveUserAddress();

               Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'address_update']/a[2]")));
        }
    }
}
