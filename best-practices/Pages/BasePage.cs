using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests.Pages
{
    public class BasePage
    {
        public IWebDriver driver;
        public String baseUrl;
        protected WebDriverWait pageWait;

        public BasePage(IWebDriver driver) {
            this.driver = driver;
            pageWait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            baseUrl = "https://www.saucedemo.com";
        }
    }
}