using OpenQA.Selenium;

namespace Tests.Pages
{
    public class BasePage
    {
        public IWebDriver driver;

        public BasePage(IWebDriver driver) {
            this.driver = driver;
        }
    }
}