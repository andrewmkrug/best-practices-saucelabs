using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class InventoryPage : BasePage
    {

        public InventoryPage(IWebDriver driver) : base()
        { }

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