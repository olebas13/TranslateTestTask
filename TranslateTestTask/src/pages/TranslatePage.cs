using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TranslateTestTask.pages
{
    public class TranslatePage : BasePage
    {
        public TranslatePage(IWebDriver driver) : base(driver)
        {
            
        }

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@src, 'consent')]")]
        private IWebElement acceptCookiesFrame;

        [FindsBy(How = How.Id, Using = "introAgreeButton")]
        private IWebElement acceptCookiesButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'irkilc')]")]
        private IWebElement textModeButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class, 'hL2wFc')]")]
        private IWebElement documentModeButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(@jsname, 'RCbdJd')]")]
        private IWebElement selectSourceLangButton;

        public TranslatePage OpenTranslatePage()
        {
            openPage("/");
            return this;
        }

        public TranslatePage acceptCookies()
        {
            SwitchToFrame(acceptCookiesFrame);
            Click(acceptCookiesButton);
            return this;
        }

        public TranslatePage ClickTextModeButton()
        {
            Click(textModeButton);
            return this;
        }
        
        public TranslatePage ClickDocumentModeButton()
        {
            Click(documentModeButton);
            return this;
        }

        public TranslatePage ClickSelectSourceLangButton()
        {
            Click(selectSourceLangButton);
            return this;
        }
    }
}