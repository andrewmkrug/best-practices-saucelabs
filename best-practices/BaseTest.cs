using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
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

        [TearDown]
        public void Teardown(ITestResult result)
        {
            //Checks the status of the test and passes the result to the Sauce Labs job
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor) driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));

            driver.Quit();
        }
    }