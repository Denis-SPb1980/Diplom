using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Core
{
    internal class Browser
    {
        private static Browser instance = null;
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }
                return instance;
            }
        }
    }
