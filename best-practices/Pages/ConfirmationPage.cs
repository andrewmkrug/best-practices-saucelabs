using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class ConfirmationPage
    {
        private IWebDriver driver;

        public ConfirmationPage(IWebDriver driver) {
            this.driver = driver;
        }

        public CheckoutCompletePage finish() {
            String finished =".btn_action.cart_button";
            driver.FindElement(By.CssSelector(finished)).Click();
            return new CheckoutCompletePage(driver);
        }
    }
}