using System.Collections.Generic;
using System.Linq;
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

        [FindsBy(How = How.XPath, Using = "//button[contains(@jsname, 'RCbdJd')]")]
        private IWebElement selectSourceLangButton;

        [FindsBy(How = How.XPath, Using = "//button[contains(@jsname, 'zumM6d')]")]
        private IWebElement selectTargetLangButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'ordo2')]")]
        private IList<IWebElement> languagesList;

        [FindsBy(How = How.XPath, Using = "//textarea[contains(@jsname, 'BJE2fc')]")]
        private IWebElement sourceTextField;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'eyKpYb')]//span[contains(@jsname, 'W297wb')]")]
        private IWebElement targetTextField;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'VhOj3e')]")]
        private IWebElement fixSourceTextField;

        public TranslatePage OpenTranslatePage()
        {
            OpenPage("/");
            return this;
        }

        public TranslatePage acceptCookies()
        {
            if (acceptCookiesFrame.Displayed)
            {
                SwitchToFrame(acceptCookiesFrame);
                Click(acceptCookiesButton);
            }
            return this;
        }

        public TranslatePage ClickTextModeButton()
        {
            Click(textModeButton);
            return this;
        }
        
        public TranslatePage ClickSelectSourceLangButton()
        {
            Click(selectSourceLangButton);
            return this;
        }

        public TranslatePage ClickSelectTargetLangButton()
        {
            Click(selectTargetLangButton);
            return this;
        }

        public TranslatePage InputSourceText(string text)
        {
            Clear(sourceTextField);
            Type(sourceTextField, text);
            return this;
        }

        public string GetTargetText()
        {
            string text = targetTextField.Text;
            return text;
        }

        public bool FixSourceTextFieldIsDisplayed()
        {
            return fixSourceTextField.Displayed;
        }

        public TranslatePage SelectLanguage(string langAttr)
        {
            foreach (var lang in languagesList
                .Where(lang => lang.GetAttribute("data-language-code").Equals(langAttr)))
            {
                ExecuteJavaScript(lang);
            }

            return this;
        }
    }
}