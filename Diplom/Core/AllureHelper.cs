using Allure.Commons;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Core
{
    internal class AllureHelper
    {
        private static AllureLifecycle allure = AllureLifecycle.Instance;

        public static void ScreenShot()
        {
            Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
            byte[] bytes = screenshot.AsByteArray;
            allure.AddAttachment("Screenshot", "image/png", bytes);
        }
    }
}
