global using TechTalk.SpecFlow;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Chrome;
global using OpenQA.Selenium.Support.UI;
using System.Reflection;
using CustomerManagement.TestWithAutomation.PageObjects.Pages;
using Xunit;


//testing driver 

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

//CustomerCreatePage  _createPage = new CustomerCreatePage();

//_customerPage.NavigateToCustomerPage("https://localhost:7189/Customer/Index");
//_customerPage.ClickCreateCustomerButton();
//_customerPage.FillCustomerFirstName("Mehmet");
//_customerPage.FillCustomerLastName("Bozdemir");
//_customerPage.FillCustomerDateOfBirth("12.04.1996");
//_customerPage.FillCustomerPhoneNumber("+905553331122");
//_customerPage.FillCustomerEmail("john.doe@example.com");
//_customerPage.FillCustomerBankAccountNumberInput("1234567890");
//_customerPage.ClickCreateCustomerConfirmButton();
//Assert.True(_customerPage.IsSuccessMessageDisplayed("Customer created successfully."));



Console.ReadLine();

