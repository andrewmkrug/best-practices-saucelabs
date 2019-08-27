using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Tests
{
    public class Tests
    {
        protected IWebDriver driver;

        [Test]
        public void Test1()
        {
            // Input your SauceLabs Credentials
            String sauceUsername = Environment.GetEnvironmentVariable("SAUCE_USERNAME", EnvironmentVariableTarget.User);
            String sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY", EnvironmentVariableTarget.User);
    
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
            Console.WriteLine("creating remote WebDriver and setting capabilities");
    
            //navigate to the url of the Sauce Labs Sample app
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
            Console.WriteLine("navigating to web application");
    
            // Specify Data
            String firstname = "john";
            String lastname = "doe";
            String postal = "94040";
    
            // Ignore the following selectors
            String username = "standard_user";
            String password = "secret_sauce";
            String userField = "[data-test='username']";
            String passField = "[data-test='password']";
            String loginBtn = "[value='LOGIN']";
            String backpack = "#inventory_container > div > div:nth-child(1) > div.pricebar > button";
            String cart = "#shopping_cart_container > a > svg";
            String rmvBtn = "#cart_contents_container > div > div.cart_list > div.cart_item > div.cart_item_label > div.item_pricebar > button";
            String continueShopping = "div.cart_footer > a.btn_secondary";
            String checkoutLink = "div.cart_footer > a.btn_action.checkout_button";
            String firstNameField = "[data-test='firstName']";
            String lastNameField = "[data-test='lastName']";
            String postalField= "[data-test='postalCode']";
            String continueLink = "div.checkout_buttons > input";
            String finished = "div.cart_footer > a.btn_action.cart_button";
            String complete = "https://www.saucedemo.com/checkout-complete.html";
    
            // wait 5 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    
            // send username keystrokes
            driver.FindElement(By.CssSelector(userField)).SendKeys(username);
            Console.WriteLine("sending username");
    
            // send password keystrokes
            driver.FindElement(By.CssSelector(passField)).SendKeys(password);
            Console.WriteLine("sending password");
    
    
            // click login button to submit keystrokes
            driver.FindElement(By.CssSelector(loginBtn)).Click();
            Console.WriteLine("clicking 'Submit' button");
    
            // add items to the cart
            driver.FindElement(By.CssSelector(backpack)).Click();
            Console.WriteLine("adding backpack");
    
            // proceed to checkout
            driver.FindElement(By.CssSelector(cart)).Click();
            Console.WriteLine("clicking cart icon");
    
            // remove item from cart
            driver.FindElement(By.CssSelector(rmvBtn)).Click();
            Console.WriteLine("removing item from cart");
    
            // continue shopping
            driver.FindElement(By.CssSelector(continueShopping)).Click();
            Console.WriteLine("clicking 'Continue Shopping' button");
    
            // re-add item to cart and proceed to checkout
            driver.FindElement(By.CssSelector(backpack)).Click();
            Console.WriteLine("re-adding backpack back to cart");
    
            // wait 5 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    
            driver.FindElement(By.CssSelector(cart)).Click();
            Console.WriteLine("clicking cart icon");
    
    
            //Click Checkout Link
            driver.FindElement(By.CssSelector(checkoutLink)).Click();
            Console.WriteLine("clicking the 'Checkout' button");
    
            // wait 5 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    
            // proceed to shipping info (checkout step 1)
            driver.FindElement(By.CssSelector(firstNameField)).SendKeys(firstname);
            Console.WriteLine("adding first name in shipping info");
    
            driver.FindElement(By.CssSelector(lastNameField)).SendKeys(lastname);
            Console.WriteLine("adding last name in shipping info");
    
            driver.FindElement(By.CssSelector(postalField)).SendKeys(postal);
            Console.WriteLine("adding zip code in shipping info");
    
            //Click Cart Checkout Link
            driver.FindElement(By.CssSelector(continueLink)).Click();
            Console.WriteLine("clicking the 'Continue' button ");
    
            //  proceed to confirmation page (checkout step 2)
            driver.FindElement(By.CssSelector(finished)).Click();
            Console.WriteLine("clicking the 'Finished' button");
    
            // wait 5 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    
            // assert that the test is finished by checking the last page's URL
            Assert.Equals(driver.Url, complete);
            Console.WriteLine("asserting last page's url = 'https://www.saucedemo.com/checkout-complete.html'" );
    
            // Then quit the driver session
            driver.Quit();

        }
    }
}