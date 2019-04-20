using GMTest.PageSelectors;
using NUnit.Framework;

namespace GMTest.TestPages
{
    [TestFixture]
    internal class MailStartPageTest
    {
        //В тестах не использовал чек-бокс на стартовой странице Mail.ru
        [TestCase("Вход", "Test", "TestPassword")]
        [TestCase("Входящие", "Реальный логин", "Реальный пароль")]//Чтобы этот тест заработал, нужно ввести реально существующую пару login/password.
        public void LoginPage_InputCredentials(string pageTitle, string login, string password)
        {
            var mailStartPage = new MailStartPage();
            mailStartPage.SetUpLoginAndPassword(login, password).ClickLoginButton();

            var result = mailStartPage.CheckEntrance();

            Assert.That(result.Contains(pageTitle), $"PageTitle should contain words: {pageTitle}");
        }
    }
}
