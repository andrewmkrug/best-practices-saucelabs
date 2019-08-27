using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver) {
            this.driver = driver;
        }

        public LoginPage visit() {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            return this;
        }

        public InventoryPage login(String username, String password)
        {
            String userField = "[data-test='username']";
            String passField = "[data-test='password']";
            String loginBtn = "[value='LOGIN']";

            // send username keystrokes
            driver.FindElement(By.CssSelector(userField)).SendKeys(username);

            // send password keystrokes
            driver.FindElement(By.CssSelector(passField)).SendKeys(password);

            // click login button to submit keystrokes
            driver.FindElement(By.CssSelector(loginBtn)).Click();
            return new InventoryPage(driver);
        }
    }
}