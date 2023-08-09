using Diplom.Core;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.BussinesObject.PageObjects
{
    internal class PopUpPrintedDressPage : BasePage
    {
        private By AddToCartButton = By.ClassName("exclusive");
        private By SizeDropDown = By.Id("group_1");
       
        public override PopUpPrintedDressPage OpenPage() => this;

        //public PopUpPrintedDressPage()
        //{
        //    WaitHelper.WaitElement(driver, AddToCartButton);
        //    WaitHelper.WaitElement(driver, SizeDropDown);
        //}

        public PopUpBasketPage GoToPopUpBasket()
        {
            //SelectElement select = new SelectElement(driver.FindElement(SizeDropDown));
            //select.SelectByIndex(2);
            driver.FindElement(AddToCartButton).Click();
            return new PopUpBasketPage();
        }
    }
}
