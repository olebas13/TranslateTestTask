using NUnit.Framework;

namespace TranslateTestTask.tests.negative
{
    public class NegativeTranslateTest : BaseTest
    {

        [Test]
        public void InputDigitTest()
        {
            string text = "12341234";
            translatePage
                .OpenTranslatePage()
                .acceptCookies()
                .ClickTextModeButton()
                .ClickSelectSourceLangButton()
                .SelectLanguage("en")
                .ClickSelectTargetLangButton()
                .SelectLanguage("uk")
                .InputSourceText(text);
            
            Assert.AreEqual(translatePage.GetTargetText(), text);
        }

        [Test]
        public void InputSpecialSymbolsTest()
        {
            string text = "#####";
            translatePage
                .OpenTranslatePage()
                .acceptCookies()
                .ClickTextModeButton()
                .ClickSelectSourceLangButton()
                .SelectLanguage("en")
                .ClickSelectTargetLangButton()
                .SelectLanguage("uk")
                .InputSourceText(text);
            
            Assert.AreEqual(translatePage.GetTargetText(), text);
        }
    }
}