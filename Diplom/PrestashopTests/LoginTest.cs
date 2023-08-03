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
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginStandartUser()
        {

            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            Thread.Sleep(1000);

            new HomePage()
                .GoToLogin()
                .LoginAsStandartUser();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'header_user_info']/a[@class = 'account']")));
        }



    }
}

