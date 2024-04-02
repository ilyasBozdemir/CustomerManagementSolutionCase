using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.PageObjects.Components;
using OpenQA.Selenium;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;


public class CustomerIndexPage : BasePage
{
    private CustomerIndexPageComponents _pageComponents;
 
    public CustomerIndexPage(IWebDriver driver) : base(driver)
    {
       
    }
}
