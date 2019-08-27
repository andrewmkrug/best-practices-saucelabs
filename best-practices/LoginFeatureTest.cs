using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Tests
{
    public class LoginFeatureTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            // Input your SauceLabs Credentials
            String sauceUsername = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
            String sauceAccessKey =
                Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");

            FirefoxOptions capabilities = new FirefoxOptions();

            //sets operating system to macOS version 10.13
            capabilities.PlatformName = "macOS 10.13";

            //sets the browser version to 11.1
            capabilities.BrowserVersion = "latest";

            //sets your test case name so that it shows up in Sauce Labs

            var sauceOptions = new Dictionary<string, object>
            {
                ["username"] = sauceUsername,
                ["accessKey"] = sauceAccessKey,
                ["name"] = TestContext.CurrentContext.Test.Name,
                ["selenium_version"] = "3.141.59"
            };


            capabilities.AddAdditionalCapability("sauce:options", sauceOptions, true);

            //instantiates a remote WebDriver object with your desired capabilities
            driver = new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com/wd/hub"), capabilities);
        }

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

        [TearDown]
        public void Teardown(ITestResult result)
        {
            //Checks the status of the test and passes the result to the Sauce Labs job
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor) driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));

            driver.Quit();
        }
    }
}