using System.Collections.Generic;

namespace GMTest.PageSelectors
{
    internal class MailStartPage
    {
        private readonly WebDriverHelper driverHelper = new WebDriverHelper();
        private const string MailUrl = "https://mail.ru/";

        public MailStartPage()
        {
            driverHelper.StartDriverWithPage(MailUrl);
        }
        
        public MailStartPage SetUpLoginAndPassword(string login = null, string password = null)
        {
            var dict = new Dictionary<string, string>()
            {
                { "#mailbox\\:login", login },
                { "#mailbox\\:password", password }
            };
            driverHelper.FindAndFillFields(dict);
            return this;
        }

        public MailStartPage ClickLoginButton()
        {
            var loginButtonSelector = "input.o-control";
            driverHelper.ClickButtonBySelector(loginButtonSelector);
            return this;
        }

        public string CheckEntrance()
        {
            var pageTitle = driverHelper.CheckRedirectPage();
            return pageTitle;
        }

        public void Quit()
        {
            driverHelper.CloseDriver();
        }
    }
}
