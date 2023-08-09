﻿using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using OpenQA.Selenium;

namespace Diplom.PrestashopTests
{
    internal class CreateAccountTests : BaseTest
    {
        [Test] //создание аккаунта (позитивный тест)

        public void CreateAccountTest()
        {

            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            Thread.Sleep(1000);

            new HomePage()
                .GoToLogin()
                .GoToCreateAccount()
                .GoToMyAccount();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class = 'header_user_info']/a[@class = 'account']")));
        }
    }
}
