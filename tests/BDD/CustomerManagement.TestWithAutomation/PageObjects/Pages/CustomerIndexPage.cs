using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.Domain.ValueObjects;
using CustomerManagement.TestWithAutomation.Drivers;
using SeleniumExtras.WaitHelpers;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerIndexPage : BasePage
{
    public readonly IWebElement CreateCustomerButton;
    public string Url => _baseUrl + "/Customer/Index";
    public CustomerIndexPage()
    {
        this.driver = WebDriverFactory.GetDriver();

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

        CreateCustomerButton = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
    }

    public void ClickCreateCustomerButton()
    {
        CreateCustomerButton.Click();
    }
}
