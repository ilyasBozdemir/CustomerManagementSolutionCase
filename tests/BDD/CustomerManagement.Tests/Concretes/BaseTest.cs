using CustomerManagement.BDD.Tests.Abstracts;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using CustomerManagement.BDD.Tests.PageObjects;
using OpenQA.Selenium.Chrome;

namespace CustomerManagement.Tests.Concretes;

public class BaseTest : ITestable
{
    protected IWebDriver _driver;
    protected WebDriverWait _driverWait;
    protected CustomerPage _customerPage;

    public BaseTest()
    {
        _driver = new ChromeDriver();
    }

    public void AfterMethod()
    {
      
    }
    public void BeforeMethod()
    {

    }

    public void AfterScenario()
    {
      
    }

    public void AfterStep()
    {
      
    }

    public void AfterTestRun()
    {
      
    }

    public void BeforeScenario()
    {
      
    }

    public void BeforeStep()
    {
      
    }

    public void BeforeTestRun()
    {
      
    }
}
