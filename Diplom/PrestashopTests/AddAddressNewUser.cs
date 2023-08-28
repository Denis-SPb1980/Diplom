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
            new LoginPage()
                .OpenPage()
                .FillEmailAndGoToCreateAccount()
                .CreateNewUserAndGoToMyAccount()
                .GoToAddressesPage()
                .FillAndSaveUserAddressWithChoiceCountry();
            Assert.IsTrue(AddressesPage.CheckingAddressDisplay(), "Элемент не найден на странице");
        }
    }
}
