using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class ConfirmationPage : BasePage
    {
        public ConfirmationPage(IWebDriver driver) {
            super(driver);
        }
        public void visit()
        {
            driver.navigate().to("https://www.saucedemo.com/checkout-step-two.html");
        }

        public void setPageState()
        {
            ((JavascriptExecutor)driver).executeScript("window.sessionStorage.setItem('standard-username', 'standard-user')");
            ((JavascriptExecutor)driver).executeScript("window.sessionStorage.setItem('cart-contents', '[4,1]')");
            driver.navigate().refresh();
        }
        public Boolean hasItems() {
            String cartBadge = "shopping_cart_badge";
            return Integer.parseInt(driver.findElement(By.className(cartBadge)).getText()) > 0;
        }
        public CheckoutCompletePage FinishCheckout()
        {
            String finished = ".btn_action.cart_button";
            WebElement finishButton = driver.findElement(By.cssSelector(finished));
            finishButton.click();
            return new CheckoutCompletePage(driver);
        }
    }
}