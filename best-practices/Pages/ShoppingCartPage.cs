using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class ShoppingCartPage
    {
        private IWebDriver driver;

        public ShoppingCartPage(IWebDriver driver) {
            this.driver = driver;
        }

        public CheckoutStepTwoPage checkout() {
            String checkoutLink = "div.cart_footer > a.btn_action.checkout_button";
            driver.FindElement(By.CssSelector(checkoutLink)).click();
            return new CheckoutStepTwoPage(driver);
        }
    }
}