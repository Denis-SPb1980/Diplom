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
        private By ProceedToCheckoutBatton = By.XPath("//*[@class = 'button btn btn-default button-medium']");
        private static By DeleteAddressButton = By.XPath("//*[@class = 'address_update']/a[2]");

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
        public void FillAndSaveUserAddressWithoutSelectCountry()
        {
            logger.Info($"Addres user is filled and saved");
            var user = UserBuilder.GetUserData();
            InputCustomerAddressAndSave(user);
        }

        [AllureStep]
        public void FillAndSaveUserAddressWithChoiceCountry()
        {
            logger.Info($"Addres user is filled and saved");
            var user = UserBuilder.GetUserData();
            SelectCountry();
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
            driver.FindElement(MobilePhoneInput).SendKeys(user.MobilePhone);
            SelectState();
            driver.FindElement(AddressTitleInput).SendKeys(user.AddressAlias);
            driver.FindElement(SaveButton).Click();
        }
        public void SelectCountry()
        {
            logger.Info($"Сountry selection");
            var select = new SelectElement(driver.FindElement(CountryDropDown));
            select.SelectByIndex(1);
        }
        public void SelectState()
        {
            logger.Info($"Сountry state");
            var select = new SelectElement(driver.FindElement(StateDropDown));
            select.SelectByIndex(3);
        }

        [AllureStep]
        public DeliveryPage FillUserAddressAndGoToDeliveryPage()
        {
            FillAndSaveUserAddressWithChoiceCountry();
            driver.FindElement(ProceedToCheckoutBatton).Click();
            return new DeliveryPage();
        }

        [AllureStep]
        public DeliveryPage FillUserAddressWithoutSelectCountryAndGoToDeliveryPage()
        {
            FillAndSaveUserAddressWithoutSelectCountry();
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

        [AllureStep]
        public static bool CheckingAddressDisplay()
        {
            try
            {
                Browser.Instance.Driver.FindElement(DeleteAddressButton);
                return true;
            }
            catch (NoSuchElementException)
            {
                logger.Info($"Еlement not found");
                return false;
            }
        }
    }
}
