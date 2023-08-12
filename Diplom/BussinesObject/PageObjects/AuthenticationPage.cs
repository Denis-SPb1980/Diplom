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
        public class AuthenticationPage : BasePage
        {
            private By UserMailInput = By.Id("email");
            private By PasswordInput = By.Id("passwd");
            private By SubmitLoginButtom = By.Id("SubmitLogin");

            private static Logger logger = LogManager.GetCurrentClassLogger();

            public const string url =
            "http://prestashop.qatestlab.com.ua/ru/authentication?multi-shipping=0&display_guest_checkout=0&back=http%3A%2F%2Fprestashop.qatestlab.com.ua%2Fru%2Forder%3Fstep%3D1%26multi-shipping%3D0";

            public override AuthenticationPage OpenPage()
            {
                logger.Info("Authentication page opened");

                Browser.Instance.NavigateToUrl(url);
                return this;
            }

            
            public AddressesPage LoginAndGoToAdressesPage()
            {
                logger.Info("Authentication ");
                var user = UserBuilder.GetStandandartUser();

                TryToLogin(user);
                return new AddressesPage();
            }

        
            public void TryToLogin(UserLoginModel user)
            {
                logger.Info("User authentication data entry");

                driver.FindElement(UserMailInput).SendKeys(user.Mail);
                driver.FindElement(PasswordInput).SendKeys(user.Password);
                driver.FindElement(SubmitLoginButtom).Click();
            }
        }
}
