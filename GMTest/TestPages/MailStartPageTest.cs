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
        [TestCase("Вход", "Test", "TestPassword")]
        [TestCase("Входящие", "Реальный логин", "Реальный пароль")]//Чтобы этот тест заработал, нужно ввести реально существующую пару login/password.
        public void LoginPage_InputCredentials(string pageTitle, string login, string password)
        {
            var result = _page.SetUpLoginAndPassword(login, password)
                              .ClickLoginButton()
                              .CheckEntrance();

            Assert.That(result.Contains(pageTitle), $"PageTitle should contain words: {pageTitle}");
        }

        [TearDown]
        public void TearDown()
        {
            _page.Quit();
        }
    }
}
