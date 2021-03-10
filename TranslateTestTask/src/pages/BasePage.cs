using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TranslateTestTask.pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

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

        protected void Clear(IWebElement element)
        {
            waitElement(element).Clear();
        }


        protected void Type(IWebElement element, string text)
        {
            waitElement(element).SendKeys(text);
        }

        protected void SwitchToFrame(IWebElement frame)
        {
            IWebElement fr = waitElement(frame);
            _driver.SwitchTo().Frame(fr);
        }

        protected void ExecuteJavaScript(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public string GetTitle()
        {
            return _driver.Title;
        }

        protected void OpenPage(string relativeUrl)
        {
            string url = $"{ConfigurationManager.AppSettings["baseUrl"]}{relativeUrl}";
            _driver.Navigate().GoToUrl(url);
        }

        public string GetCurrentURL()
        {
            return _driver.Url;
        }

        private IWebElement waitElement(IWebElement element)
        {
            IWebElement el = _wait.Until(e => element);
            return element;
        }
    }
}