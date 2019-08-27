# Exercise 4: Configure Atomic Tests

## Part One: Implement the `JavascriptExecutor` to Bypass Pages
1. Open **`ConfirmationPage`** and add the following class method:
    ```csharp
    public void setPageState() {
        driver.navigate().refresh();
    }
    ```
2. In **`setPageState()`** add the following
    * **`JavaScriptExecutor`** command to bypass logging in through the **`LoginPage`** object:
    ```csharp
    ((JavascriptExecutor)driver).executeScript("window.sessionStorage.setItem('standard-username', 'standard-user')");
    ```
    * **`JavaScriptExecutor`** command to bypass adding items to the cart through the **`InventoryPage`** object:
    ```csharp
    ((JavascriptExecutor)driver).executeScript("window.sessionStorage.setItem('cart-contents', '[4,1]')");
    ```
3. Add a `Boolean` method called `hasItems()`:
    ```csharp
    public Boolean hasItems() {
        String cartBadge = "shopping_cart_badge";
        return Integer.parseInt(driver.findElement(By.className(cartBadge)).getText()) > 0;
    }
    ```
    
<br />

## Part Two: Modify `CheckoutFeatureTest`
1. Open **`CheckoutFeatureTest`**, delete the existing commands, and add the following:
    ```csharp
    @Test
    public void ShouldBeAbleToCheckoutWithItems() {
        // wait 5 seconds
        driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS) ;

        ConfirmationPage confirmationPage = new ConfirmationPage(driver);
        confirmationPage.visit();
        confirmationPage.setPageState();
        Assert.assertTrue(confirmationPage.hasItems());

        CheckoutCompletePage completePage = confirmationPage.FinishCheckout();
        // assert that the test is finished by checking the last page's URL
        Assert.assertTrue(completePage.IsLoaded());
    }
    ```
2. Save all and run the following command to ensure the build passes:
    ```shell
    dotnet test
    ```
3. Use `git stash` or `git commit` to discard or save your changes. Checkout the next branch to proceed to the next exercise
    ```shell
    git checkout 05_create_base_page
    ```