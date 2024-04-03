using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.Drivers;
using OpenQA.Selenium;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;


public class CustomerEditPage : BasePage
{
    public CustomerEditPage(IWebDriver _driver) : base(_driver)
    {
        base.driver = WebDriverFactory.GetDriver();
    }
}
