using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TranslateTestTask.pages
{
    public class BasePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(_driver, this);
        }

        protected void Click(IWebElement element)
        {
            waitElement(element).Click();
        }

        public void Clear(IWebElement element)
        {
            waitElement(element).Clear();
        }


        public void Type(IWebElement element, string text)
        {
            waitElement(element).SendKeys(text);
        }

        public void SwitchToFrame(IWebElement frame)
        {
            IWebElement fr = waitElement(frame);
            _driver.SwitchTo().Frame(fr);
        }

        public string getTitle()
        {
            return _driver.Title;
        }

        public void openPage(string relativeUrl)
        {
            string url = $"{ConfigurationManager.AppSettings["baseUrl"]}{relativeUrl}";
            _driver.Navigate().GoToUrl(url);
        }

        private IWebElement waitElement(IWebElement element)
        {
            IWebElement el = _wait.Until(e => element);
            return element;
        }
    }
}