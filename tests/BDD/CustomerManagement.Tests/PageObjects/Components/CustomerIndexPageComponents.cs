using OpenQA.Selenium;

namespace CustomerManagement.Tests.PageObjects.Components;

public class CustomerIndexPageComponents : BasePageComponents
{
    public readonly IWebElement CreateCustomerButton;// /Customer Index
    public CustomerIndexPageComponents(IWebDriver driver) : base(driver)
    {
        CreateCustomerButton = _driver.FindElement(By.XPath("/html/body/div/main/p/a"));
    }
}
