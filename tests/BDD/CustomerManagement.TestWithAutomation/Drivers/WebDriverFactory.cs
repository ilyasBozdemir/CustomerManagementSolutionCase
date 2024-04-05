using System.Diagnostics;
using System.Reflection;

namespace CustomerManagement.TestWithAutomation.Drivers;

public static class WebDriverFactory
{
    private static IWebDriver _driver;
    private static DriverBrowserType  _browserType = DriverBrowserType.Chrome;

    public static IWebDriver InitializeWebDriver()
    {
        string _driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (_driver == null)
        {
            switch (_browserType)
            {
                case DriverBrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddArgument("--ignore-certificate-errors");
                    options.AddArguments("disable-popup-blocking");
                    //options.AddArgument("--headless");//arkaplanda acar
                    //options.AddArgument("--incognito");
                    options.AddArgument("--allow-insecure-localhost");
                    options.AddArgument("--acceptInsecureCerts");
                    options.AddArgument("--disable-blink-features=AutomationControlled");
                    options.AddArgument("--disable-extensions");


                    ChromeDriverService service = ChromeDriverService.CreateDefaultService(_driverPath);
                    service.HideCommandPromptWindow = false;
                    _driver = new ChromeDriver(service, options);
                    _driver.Manage().Cookies.DeleteAllCookies();
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
                    break;
                case DriverBrowserType.Firefox:
                    break;
                case DriverBrowserType.Edge:
                    break;
                case DriverBrowserType.Safari:
                    break;
                case DriverBrowserType.Brave:
                    break;
                default:
                    break;
            }
        }
        return _driver;
    }
  
    public static IWebDriver GetDriver() => _driver ??= InitializeWebDriver();

    public static bool DriverState() => _driver != null;

  
    public static void CloseWebDriver()
    {
        if (DriverState())
        {
            _driver.Quit();
            _driver = null;
        }
    }

}

