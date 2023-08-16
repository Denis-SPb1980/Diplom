using Diplom.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        private By AddNewAddressButton = By.XPath("//*[@class = 'address_add submit']/a");
        private By ProceedToCheckoutBatton = By.XPath("//*[@class = 'button btn btn-default button-medium']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/address";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [AllureStep]
        public override AddressesPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public void FillAndSaveUserAddress()
        {
            logger.Info($"Addres user is filled and saved");
            var user = UserBuilder.GetUserData();
            InputCustomerAddressAndSave(user);   
        }

        [AllureStep]
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
            logger.Info($"Сountry selection");
            var select = new SelectElement(driver.FindElement(CountryDropDown));
            select.SelectByValue("216");
        }
        public void SelectState()
        {
            logger.Info($"Сountry state");
            var Random = new Random();
            var num = Random.Next(1, 10);
            var select = new SelectElement(driver.FindElement(StateDropDown));
            select.SelectByIndex(num);
        }

        [AllureStep]
        public DeliveryPage FillUserAddressAndGoToDeliveryPage()
        {
            FillAndSaveUserAddress();
            driver.FindElement(ProceedToCheckoutBatton).Click();
            return new DeliveryPage();
        }

        [AllureStep]
        public DeliveryPage GoToDeliveryPage()
        {
            driver.FindElement(ProceedToCheckoutBatton).Click();
            AllureHelper.ScreenShot();
            return new DeliveryPage();
        }
    }
}
