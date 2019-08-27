using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage visit() {
            driver.Navigate().GoToUrl(baseUrl);
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
        
        public Boolean isLoaded() {
            return pageWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("bot_column"))).Count > 0;
        }
    }
}