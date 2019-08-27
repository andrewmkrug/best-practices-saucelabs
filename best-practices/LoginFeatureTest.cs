using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using Tests.Pages;

namespace Tests
{
    public class LoginFeatureTest : BaseTest
    {
        [Test]
        public void ShouldBeAbleToLogin()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.visit();
            Assert.True(loginPage.isLoaded());

            InventoryPage inventoryPage = loginPage.login("standard_user", "secret_sauce");
            Assert.True(inventoryPage.isLoaded());
        }
    }
}