using GMTest.PageSelectors;
using NUnit.Framework;

namespace GMTest.TestPages
{
    [TestFixture]
    internal class MailStartPageTest
    {
        private MailStartPage _page;

        [SetUp]
        public void SetUp()
        {
            _page = new MailStartPage();
        }

        //В тестах не использовал чек-бокс на стартовой странице Mail.ru
        //Оба теста можно сделать более жёсткими, если добавить парсинг страницы с редиректом, можно воспользоваться регулярным выражением.
        [Test]
        public void LoginPage_InputValidAuthData_RedirectToMailBox()
        {
            var redirectUrl = "https://e.mail.ru/messages/inbox";
            var login = "ivan.test1985.ivanov";
            var password = "fsfw24dsad2SD";

            var result = _page.SetUpLoginAndPassword(login, password)
                .ClickLoginButton()
                .IsRedirectedToUrl(redirectUrl);

            Assert.That(result, "After feeling in the valid auth data redirect to mail box wasn't happen");
        }

        [Test]
        public void LoginPage_InputWrongAuthData_RedirectToLoginPage()
        {
            var redirectUrl = "https://e.mail.ru/login";
            var login = "Test";
            var password = "TestPassword";

            var result = _page.SetUpLoginAndPassword(login, password)
                .ClickLoginButton()
                .IsRedirectedToUrl(redirectUrl);

            Assert.That(result, "After feeling in the wrong auth data redirect to login page wasn't happen");
        }

        [TearDown]
        public void TearDown()
        {
            _page.Quit();
        }
    }
}
