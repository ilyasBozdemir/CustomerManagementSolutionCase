using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.PageObjects.Components;
using OpenQA.Selenium;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;


public class CustomerEditPage : BasePage
{
    private CustomerEditPageComponents _pageComponents;
    public CustomerEditPage(IWebDriver driver) : base(driver)
    {

    }
}
