using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;

namespace Diplom.Core
{
    [AllureNUnit]
    public class BaseTest
    {
        private AllureLifecycle allure;

        [OneTimeSetUp]

        public void Setup()
        {
            allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                AllureHelper.ScreenShot();
            }
            Browser.Instance.CloseBrowser();
        }
    } 
}