using System.Configuration;
using NUnit.Framework;

namespace TranslateTestTask.tests.positive
{
    public class PositiveTranslateTest : BaseTest
    {
        
        [Test]
        public void OpenTranslatePageTest()
        {
            translatePage
                .OpenTranslatePage()
                .acceptCookies();
            Assert.AreEqual(translatePage.GetTitle(), "Google Переводчик");
            Assert.AreEqual(translatePage.GetCurrentURL(), $"{ConfigurationManager.AppSettings["baseUrl"]}/");
        }

        [Test]
        public void TranslateFromEngIntoUkrTest()
        {
            translatePage
                .OpenTranslatePage()
                .acceptCookies()
                .ClickTextModeButton()
                .ClickSelectSourceLangButton()
                .SelectLanguage("en")
                .ClickSelectTargetLangButton()
                .SelectLanguage("uk")
                .InputSourceText("Hello");
            
            Assert.IsNotEmpty(translatePage.GetTargetText());
            Assert.AreEqual(translatePage.GetTargetText(), "Здравствуйте");
        }

        [Test]
        public void TranslateFromUkrIntoEngTest()
        {
            translatePage
                .OpenTranslatePage()
                .acceptCookies()
                .ClickTextModeButton()
                .ClickSelectSourceLangButton()
                .SelectLanguage("uk")
                .ClickSelectTargetLangButton()
                .SelectLanguage("en")
                .InputSourceText("Здравствуйте");
            
            Assert.IsNotEmpty(translatePage.GetTargetText());
            Assert.AreEqual(translatePage.GetTargetText(), "Hello");
        }

        [Test]
        public void ShowTheFixSourceTextTest()
        {
            translatePage
                .OpenTranslatePage()
                .acceptCookies()
                .ClickTextModeButton()
                .ClickSelectSourceLangButton()
                .SelectLanguage("uk")
                .InputSourceText("привітяксправи");
            
            Assert.IsTrue(translatePage.FixSourceTextFieldIsDisplayed());
        }
    }
}