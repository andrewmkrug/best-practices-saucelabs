using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class CheckoutCompletePage
    {
        private IWebDriver driver;
        //TODO more duplication
        public CheckoutCompletePage(IWebDriver driver) {
            this.driver = driver;
        }

        public Boolean isLoaded() {
            return driver.Url.Contains("https://www.saucedemo.com/checkout-complete.html");
        }
    }
}