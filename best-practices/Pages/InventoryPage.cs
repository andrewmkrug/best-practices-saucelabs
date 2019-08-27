using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests.Pages
{
    public class InventoryPage : BasePage
    {

        public InventoryPage(IWebDriver driver) : base(driver)
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
        
        //TODO how will you handle the isLoaded method that's in a few pages
        public Boolean isLoaded() {
            //TODO what are you going to do with the element locators if you keep reusing them in different methods?
            return pageWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("app_logo"))).Count > 0;
        }
    }
}