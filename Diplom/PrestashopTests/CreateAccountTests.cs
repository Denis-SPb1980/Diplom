using Diplom.BussinesObject.PageObjects;
using Diplom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.PrestashopTests
{
    internal class CreateAccountTests
    {
        [Test]

        public void CreateAccountTest()
        {

            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            Thread.Sleep(1000);

            new HomePage()
                .GoToLogin()
                .GoToCreateAccount();

        }
    }
}
