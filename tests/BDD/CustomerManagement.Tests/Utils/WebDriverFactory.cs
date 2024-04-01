using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CustomerManagement.BDD.Tests.Utils;

public static class WebDriverFactory
{
    private static IWebDriver driver;

    public static void InitializeWebDriver()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--start-maximized"); 
        driver = new ChromeDriver(options);
    }

    public static void CloseWebDriver()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }
}
