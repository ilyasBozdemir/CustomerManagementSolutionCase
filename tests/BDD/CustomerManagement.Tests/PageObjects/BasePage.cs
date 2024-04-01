using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CustomerManagement.BDD.Tests.PageObjects;

public class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    protected Actions actions;
    protected string baseUrl = "https://localhost:7189/";

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        this.actions = new Actions(driver);
    }

    public void NavigateTo(string relativePath)
    {
        driver.Navigate().GoToUrl(baseUrl + relativePath);
    }
    protected IWebElement FindElement(By locator)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    protected void ClickElement(By locator)
    {
        FindElement(locator).Click();
    }

    protected void SendKeysToElement(By locator, string text)
    {
        FindElement(locator).SendKeys(text);
    }

    protected string GetTextFromElement(By locator)
    {
        return FindElement(locator).Text;
    }

    protected IList<IWebElement> FindAllElements(By locator)
    {
        return driver.FindElements(locator);
    }

    protected void HoverOverElement(By locator)
    {
        var element = FindElement(locator);
        Actions actions = new Actions(driver);
        actions.MoveToElement(element).Perform();
    }

    protected void ScrollIntoElement(By locator)
    {
        var element = FindElement(locator);
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

    protected string GetTitle()
    {
        return driver.Title;
    }

    protected bool IsDisplayed(By locator)
    {
        return FindElement(locator).Displayed;
    }

    protected void TypeText(By locator, string text)
    {
        FindElement(locator).Clear();
        FindElement(locator).SendKeys(text);
    }

    protected IList<IWebElement> FindChildElements(By parentLocator, By childLocator)
    {
        var parentElement = FindElement(parentLocator);
        return parentElement.FindElements(childLocator);
    }

    protected void ScrollIntoElementAndClick(By locator)
    {
        ScrollIntoElement(locator);
        ClickElement(locator);
    }

    protected void SetPageLoadTimeout(TimeSpan timeout)
    {
        driver.Manage().Timeouts().PageLoad = timeout;
    }

    protected void SetImplicitWait(TimeSpan timeout)
    {
        driver.Manage().Timeouts().ImplicitWait = timeout;
    }
}
