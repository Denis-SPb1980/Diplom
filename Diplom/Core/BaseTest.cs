using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Core
{
    public class BaseTest
    {
        [SetUp]

        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
