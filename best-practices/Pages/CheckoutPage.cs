using OpenQA.Selenium;

namespace Tests.Pages
{
    public class CheckoutPage
    {
        private IWebDriver driver;

        public CheckoutPage(IWebDriver driver) {
            this.driver = driver;
        }
    }
}