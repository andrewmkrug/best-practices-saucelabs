using System;
using OpenQA.Selenium;

namespace Tests.Pages
{
    public class CheckoutStepTwoPage
    {
        private IWebDriver driver;
        //TODO notice the duplication in all of page our classes
        public CheckoutStepTwoPage(IWebDriver driver) {
            this.driver = driver;
        }

        public ConfirmationPage fillOutInformation(String first, String last, String zip) {
            String firstNameField = "[data-test='firstName']";
            String lastNameField = "[data-test='lastName']";
            String postalField= "[data-test='postalCode']";
            String continueLink = "[value='CONTINUE']";
            // proceed to shipping info (checkout step 1)
            driver.FindElement(By.CssSelector(firstNameField)).SendKeys(first);
            driver.FindElement(By.CssSelector(lastNameField)).SendKeys(last);
            driver.FindElement(By.CssSelector(postalField)).SendKeys(zip);
            driver.FindElement(By.CssSelector(continueLink)).Click();
            return new ConfirmationPage(driver);
        }
    }
}