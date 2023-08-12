using Diplom.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.BussinesObject.PageObjects
{
    public class AddressesPage : BasePage
    {
        private By FirstNameInput = By.Id("firstname");
        private By LastNameInput = By.Id("lastname");
        private By AddressInput = By.Id("address1");
        private By PostalCodeInput = By.Id("postcode");
        private By CityInput = By.Id("city");
        private By CountryDropDown = By.XPath("//*[@id = 'id_country']");
        private By MobilePhoneInput = By.Id("phone_mobile");
        private By StateDropDown = By.XPath("//*[@id = 'id_state']");
        private By AddressTitleInput = By.Id("alias");
        private By SaveButton = By.Id("submitAddress");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/address";

        public override AddressesPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public void FillUserAddress()
        {
            var user = UserBuilder.GetUserData();
            InputCustomerAddressAndSave(user);   
        }

        public void InputCustomerAddressAndSave(UserAddressModel user)
        {
            driver.FindElement(FirstNameInput).SendKeys(user.FirstName);
            driver.FindElement(LastNameInput).SendKeys(user.LastName);
            driver.FindElement(AddressInput).SendKeys(user.Address);
            driver.FindElement(PostalCodeInput).SendKeys(user.PostalCode);
            driver.FindElement(CityInput).SendKeys(user.City);
            SelectCountry();
            driver.FindElement(MobilePhoneInput).SendKeys(user.MobilePhone);
            SelectState();
            driver.FindElement(AddressTitleInput).SendKeys(user.AddressAlias);
            driver.FindElement(SaveButton).Click();
        }

        public void SelectCountry()
        {
            var select = new SelectElement(driver.FindElement(CountryDropDown));
            select.SelectByValue("216");
        }

        [AllureStep]
        public void SelectState()
        {
            var select = new SelectElement(driver.FindElement(StateDropDown));
            select.SelectByValue("26");
        }

    }
}
