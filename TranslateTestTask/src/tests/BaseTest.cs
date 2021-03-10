using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TranslateTestTask.pages;

namespace TranslateTestTask.tests
{
    public class BaseTest
    {
        private IWebDriver _driver;
        protected TranslatePage translatePage;
        
        
        [OneTimeSetUp]
        public void SetUp()
        {
            string browser = ConfigurationManager.AppSettings["browser"];
            switch (browser)
            {
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    Assert.Fail($"INCORRECT BROWSER NAME: {browser}");
                    break;
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            translatePage = new TranslatePage(_driver);
        }

        [TearDown]
        public void CleanUp()
        {
            if (ConfigurationManager.AppSettings["clear_cookies"].Equals("true"))
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor) _driver;
                _driver.Manage().Cookies.DeleteAllCookies();
                js.ExecuteScript("window.sessionStorage.clear();");
            }
            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}