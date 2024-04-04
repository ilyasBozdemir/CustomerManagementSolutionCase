using CustomerManagement.TestWithAutomation.Constant;
using CustomerManagement.TestWithAutomation.Drivers;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace CustomerManagement.BDD.TestWithAutomation.PageObjects;

public abstract class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    protected Actions actions;
    protected const string _baseUrl = AppTestConstants.BaseUrl;

    public BasePage()
    {
        this.driver = WebDriverFactory.GetDriver();
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        this.actions = new Actions(driver);

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    }

    public IWebElement FindElement(By locator)
    {
    
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }
    public void NavigateTo(string relativePath)
    {
        driver.Navigate().GoToUrl(_baseUrl + relativePath);
    }
    public void ClickElement(By locator)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        FindElement(locator).Click();
    }
    public  void ClickElement(IWebElement element)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
    }
    public void SendKeysToElement(By locator, string text)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(locator));
        FindElement(locator).SendKeys(text);
    }

    public string GetCurrentUrl()
    {
        return driver.Url;
    }

    public Guid ExtractUserIdFromUrl(string url)
    {
     
        string[] parts = url.Trim('/').Split('/');

  
        string userIdString = parts[parts.Length - 1];

        if (Guid.TryParse(userIdString, out Guid userId))
            return userId;
        else
            throw new ArgumentException("Invalid URL format: Unable to extract user ID.");
        
    }



    public string GetTextFromElement(By locator)
    {
        return FindElement(locator).Text;
    }

    public IList<IWebElement> FindAllElements(By locator)
    {
        return driver.FindElements(locator);
    }

    public void HoverOverElement(By locator)
    {
        var element = FindElement(locator);
        Actions actions = new Actions(driver);
        actions.MoveToElement(element).Perform();
    }

    public void ScrollIntoElement(By locator)
    {
        var element = FindElement(locator);
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    public string GetTitle()
    {
        return driver.Title;
    }

    public bool IsDisplayed(By locator)
    {
        return FindElement(locator).Displayed;
    }

    public void TypeText(By locator, string text)
    {
        FindElement(locator).Clear();
        FindElement(locator).SendKeys(text);
    }

    public IList<IWebElement> FindChildElements(By parentLocator, By childLocator)
    {
        var parentElement = FindElement(parentLocator);
        return parentElement.FindElements(childLocator);
    }

    public void ScrollIntoElementAndClick(By locator)
    {
        ScrollIntoElement(locator);
        ClickElement(locator);
    }

    public void SetPageLoadTimeout(TimeSpan timeout)
    {
        driver.Manage().Timeouts().PageLoad = timeout;
    }

    public void SetImplicitWait(TimeSpan timeout)
    {
        driver.Manage().Timeouts().ImplicitWait = timeout;
    }

}
