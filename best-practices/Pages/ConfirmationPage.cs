using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class ConfirmationPage : BasePage
    {
        public ConfirmationPage(IWebDriver driver) : base(driver)
        {
        }
        public void visit()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/checkout-step-two.html");
        }

        public void setPageState()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.sessionStorage.setItem('standard-username', 'standard-user')");
            js.ExecuteScript("window.sessionStorage.setItem('cart-contents', '[4,1]')");
            driver.Navigate().Refresh();
        }
        public Boolean hasItems() {
            String cartBadge = "shopping_cart_badge";
            return int.Parse(driver.FindElement(By.ClassName(cartBadge)).Text) > 0;
        }
        public CheckoutCompletePage FinishCheckout()
        {
            String finished = ".btn_action.cart_button";
            IWebElement finishButton = driver.FindElement(By.CssSelector(finished));
            finishButton.Click();
            return new CheckoutCompletePage(driver);
        }
    }
}