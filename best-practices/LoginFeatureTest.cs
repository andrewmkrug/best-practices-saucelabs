using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Tests
{
    public class LoginFeatureTest : BaseTest
    {
        [Test]
        public void ShouldBeAbleToLogin()
        {
            //navigate to the url of the Sauce Labs Sample app
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            // Ignore the following selectors
            String username = "standard_user";
            String password = "secret_sauce";
            String userField = "[data-test='username']";
            String passField = "[data-test='password']";
            String loginBtn = "[value='LOGIN']";

            // wait 5 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            // send username keystrokes
            driver.FindElement(By.CssSelector(userField)).SendKeys(username);

            // send password keystrokes
            driver.FindElement(By.CssSelector(passField)).SendKeys(password);

            // click login button to submit keystrokes
            driver.FindElement(By.CssSelector(loginBtn)).Click();

            // ignore assertion
            Assert.Equals("https://www.saucedemo.com/inventory.html", driver.Url);
        }
    }
}