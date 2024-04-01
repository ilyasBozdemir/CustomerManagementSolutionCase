using CustomerManagement.BDD.Tests.PageObjects;
using CustomerManagement.Tests.PageObjects.Components;
using OpenQA.Selenium;

namespace CustomerManagement.Tests.PageObjects.Pages;


public class CustomerIndexPage : BasePage
{
    private CustomerIndexPageComponents _pageComponents;
    public CustomerIndexPage(IWebDriver driver) : base(driver)
    {

    }
}
