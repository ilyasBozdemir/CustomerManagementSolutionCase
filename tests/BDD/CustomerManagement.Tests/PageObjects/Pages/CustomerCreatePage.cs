using CustomerManagement.BDD.Tests.PageObjects;
using CustomerManagement.Tests.PageObjects.Components;
using OpenQA.Selenium;


namespace CustomerManagement.Tests.PageObjects.Pages;

public class CustomerCreatePage : BasePage
{
    private CustomerCreatePageComponents _pageComponents;
    public CustomerCreatePage(IWebDriver driver) : base(driver)
    {
        _pageComponents = new CustomerCreatePageComponents(driver);
    }
}
