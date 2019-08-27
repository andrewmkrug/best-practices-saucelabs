using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class InventoryPage
    {
        private IWebDriver driver;

        public InventoryPage(IWebDriver driver) {
            this.driver = driver;
        }

        public void addBackpackToCart() {
            String backpack = "div:nth-child(1) > div.pricebar > button";
            driver.FindElement(By.CssSelector(backpack)).Click();
        }

        public ShoppingCartPage goToShoppingCart() {
            String cart = "#shopping_cart_container > a > svg";
            driver.FindElement(By.CssSelector(cart)).Click();
            return new ShoppingCartPage(driver);
        }
    }
}