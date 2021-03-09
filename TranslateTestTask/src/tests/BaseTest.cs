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

        public IWebDriver _driver;
        public TranslatePage translatePage;
        
        
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
            _driver.Manage().Cookies.DeleteAllCookies();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}