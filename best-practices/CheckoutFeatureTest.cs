using System;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class CheckoutFeatureTest : BaseTest
    {
        public void ShouldBeAbleToCheckoutWithItems()
        {
            // wait 5 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ConfirmationPage confirmationPage = new ConfirmationPage(driver);
            confirmationPage.visit();
            confirmationPage.setPageState();
            Assert.True(confirmationPage.hasItems());

            CheckoutCompletePage completePage = confirmationPage.FinishCheckout();
            // assert that the test is finished by checking the last page's URL
            Assert.True(completePage.IsLoaded());
        }
    }
}