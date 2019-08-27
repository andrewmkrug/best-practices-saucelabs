# Exercise 2: Create Page Objects

## Part One: Create a  `LoginPage`
1. Checkout branch `02_create_page_objects`. 
3. In the **`Pages`** directory, navigate to the class called **`LoginPage`**
4. Create the constructor for the page object:
    ```csharp
    public LoginPage(IWebDriver driver) {
        this.driver = driver;
    }
    ```
5. Create a `visit` method in the `LoginPage` object:
    ```csharp
    public LoginPage Visit() {
        driver.Navigate().GoToUrl("https://www.saucedemo.Com");
        return this;
    }
    ```
6. Open **`LoginFeatureTest`** and import the **`LoginPage`** changes to replace **`driver.Navigate().GoToUrl("https://www.saucedemo.Com")`** For Example:
    
    * Before
    ```csharp
    driver.Navigate().GoToUrl("https://www.saucedemo.Com");
    ```
    * After
    ```csharp
    LoginPage LoginPage = new LoginPage(driver);
    LoginPage.Visit();
    ```

7. Run a `dotnet test` command to see if the test executes successfully:
    ```shell
    dotnet test 
    ```   
    <br />
    
## Part Two: Create `login()` Method
1. Open **`LoginPage`** and create a new class method called `login()`. This method will return a new page object that represents the next page in the journey (i.e. `InventoryPage`)
2. Add the **`LoginPage.visit()`** action in place of **`driver.Navigate().GoToUrl("https://www.saucedemo.Com")`** The method will also expect some `String` data for the credentials (`username` and `password`). For Example:
    ```csharp
    public InventoryPage Login(String username, String password)
    {
        String userField = "[data-test='username']";
        String passField = "[data-test='password']";
        String loginBtn = "[value='LOGIN']";
    }
    ```
3. Add the following Selenium commands in order to send the keystrokes:
    ```csharp
    // send username keystrokes
    driver.FindElement(By.CssSelector(userField)).sendKeys(username);

    // send password keystrokes
    driver.FindElement(By.CssSelector(passField)).sendKeys(password);

    // click login button to submit keystrokes
    driver.FindElement(By.CssSelector(loginBtn)).Click();
    return new InventoryPage(driver);
    ```
    
4. Open `LoginFeatureTest`, and create a test method called `ShouldBeAbleToLogin`. 
This method should use only page objects to perform our login operations.

5. Save and run `dotnet test` to ensure the test still executes:
    ```shell
    dotnet test 
    ```

## Part Three: Create ShouldBeAbleToCheckout test
Now we will create a full end to end scenario where the user is able to login, add an item to a cart, and checkout with that item.

You are only allowed to use Page Objects for this test. And must follow best practices.

However, your page objects can have duplication throughout for now. The goal is to just replace the Selenium code with Page Objects.

1. Create a new test file called `CheckoutFeatureTest`
1. Add a new test method `shouldBeAbleToCheckOut`
1. Copy everything related to the checkout process from `FullJourneyTest`
This means that you will copy all the code from line 106 until the end
4. Dont forget to add the new login logic to the test as well
5. The end result will be a test case where we are logging in, adding an item to a cart, then going through the whole checkout process. Using only Page Objects.
5. Save and run `dotnet test` to ensure the test still executes:
    ```shell
    dotnet test 
    ```


