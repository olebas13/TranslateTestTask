using NUnit.Framework;

namespace TranslateTestTask.tests.positive
{
    public class PositiveTranslateTest : BaseTest
    {
        
        [Test]
        public void Open()
        {
            translatePage
                .OpenTranslatePage()
                .acceptCookies()
                .ClickDocumentModeButton()
                .ClickTextModeButton();
        }
    }
}