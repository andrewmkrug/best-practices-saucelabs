using OpenQA.Selenium;

namespace Tests.Pages
{
    public class CheckoutPage : BasePage
    {

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
    }
}