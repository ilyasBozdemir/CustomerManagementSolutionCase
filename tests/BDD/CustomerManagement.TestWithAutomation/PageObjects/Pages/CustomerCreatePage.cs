using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.PageObjects.Components;
using OpenQA.Selenium;


namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerCreatePage : BasePage
{
    private CustomerCreatePageComponents _pageComponents;
    public CustomerCreatePage(IWebDriver driver) : base(driver)
    {
        _pageComponents = new CustomerCreatePageComponents(driver);
    }
}
