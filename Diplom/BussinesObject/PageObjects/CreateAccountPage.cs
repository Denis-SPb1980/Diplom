using Diplom.Core;

namespace Diplom.BussinesObject.PageObjects
{
    public class CreateAccountPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account#account-creation";

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
    }
}
