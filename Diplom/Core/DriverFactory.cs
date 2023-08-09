﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diplom.Core.Configuration;

namespace Diplom.Core
{
    public class DriverFactory
    {
        public static IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            if (AppConfiguration.Browser.Headless) options.AddArgument("--headless");
            //options.AddArgument("--disable-gpu");
            //options.AddArgument("--incognito");
            //options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");

            return new FirefoxDriver(options);
        }
    }
}
