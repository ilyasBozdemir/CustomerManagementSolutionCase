global using FluentAssertions;
global using TechTalk.SpecFlow;
global using Xunit;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;

//Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//test  path

////testing driver 


//string _driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

//ChromeOptions options = new ChromeOptions();
//options.AddArgument("--start-maximized");
//options.AddArgument("--ignore-certificate-errors");
//options.AddArguments("disable-popup-blocking");
////options.AddArgument("--headless");
////options.AddArgument("--incognito");
//options.AddArgument("--allow-insecure-localhost");
//options.AddArgument("--acceptInsecureCerts");
//options.AddArgument("--disable-blink-features=AutomationControlled");
//options.AddArgument("--disable-extensions");


//ChromeDriverService service = ChromeDriverService.CreateDefaultService(_driverPath);
//service.HideCommandPromptWindow = false;
//IWebDriver _driver = new ChromeDriver(service, options);
//_driver.Manage().Cookies.DeleteAllCookies();
//_driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
//_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);

//_driver.Navigate().GoToUrl("https://localhost:7189/Customer");

Console.ReadLine();

