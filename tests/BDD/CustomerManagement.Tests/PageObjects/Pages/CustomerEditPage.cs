using CustomerManagement.BDD.Tests.PageObjects;
using CustomerManagement.Tests.PageObjects.Components;
using OpenQA.Selenium;

namespace CustomerManagement.Tests.PageObjects.Pages;


public class CustomerEditPage : BasePage
{
    private CustomerEditPageComponents _pageComponents;
    public CustomerEditPage(IWebDriver driver) : base(driver)
    {

    }
}
