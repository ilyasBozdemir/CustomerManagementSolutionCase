using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace CustomerManagement.BDD.Tests.Utils;

public static class WebDriverFactory
{
    private static IWebDriver _driver;
   
    public static void InitializeWebDriver()
    {
        ChromeOptions options = new ChromeOptions();
   
        options.AddArgument("--start-maximized");        
        options.AddArgument("--ignore-certificate-errors");
        options.AddArguments("disable-popup-blocking");
        options.AddArgument("--headless");
        _driver = new ChromeDriver(options);
        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
    }

    public static void NavigateTo(string relativePath)
    {
        _driver.Navigate().GoToUrl(relativePath);
    }

    public static void CloseWebDriver()
    {
        if (_driver != null)
        {
            _driver.Quit();
            _driver = null;
        }
    }
    public static IWebDriver GetDriver()
    {
        if (_driver == null)
            InitializeWebDriver();

        return _driver;
    }
}
