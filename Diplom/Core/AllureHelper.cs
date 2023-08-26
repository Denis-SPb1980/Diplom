using Allure.Commons;
using OpenQA.Selenium;

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