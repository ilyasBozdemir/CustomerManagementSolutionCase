using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.Drivers;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;


public class CustomerIndexPage : BasePage
{
    public readonly IWebElement CreateCustomerButton;// /Customer Index

    public CustomerIndexPage(IWebDriver _driver) : base(_driver)
    {
        CreateCustomerButton = driver.FindElement(By.XPath("/html/body/div/main/p/a"));
    }
}
