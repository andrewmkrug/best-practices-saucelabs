using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        public CheckoutCompletePage(IWebDriver driver) : base(driver)
        {
        }

        public Boolean isLoaded() {
            return driver.Url.Contains("https://www.saucedemo.com/checkout-complete.html");
        }
    }
}