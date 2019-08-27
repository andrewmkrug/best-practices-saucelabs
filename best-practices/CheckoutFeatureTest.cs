using System;
using NUnit.Framework;
using Tests.Pages;

namespace Tests
{
    public class CheckoutFeatureTest : BaseTest
    {
        public void ShouldBeAbleToCheckoutWithItems()
        {
            ConfirmationPage confirmationPage = new ConfirmationPage(driver);
            confirmationPage.visit();
            Assert.True(confirmationPage.isLoaded());

            confirmationPage.setPageState();
            Assert.True(confirmationPage.hasItems());
            CheckoutCompletePage completePage = confirmationPage.FinishCheckout();
            Assert.True(completePage.isLoaded());
        }
    }
}