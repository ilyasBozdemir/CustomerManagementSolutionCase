using CustomerManagement.BDD.Tests.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using CustomerManagement.Tests.PageObjects.Pages;


namespace CustomerManagement.BDD.Tests.Hooks;

/*
 
  BeforeScenario and AfterScenario:
 
  * These attributes are used to perform specific operations before and after each scenario is run.
   For example, starting and closing WebDriver.

  BeforeFeature and AfterFeature:

 * These attributes are used to perform certain operations before and after each feature is executed.
 * For example, preparing a test environment when the feature launches.

  Before and After:
 * These attributes are used to perform specific operations before and after each scenario step.
   However, the BeforeScenario and AfterScenario attributes are preferred instead of using these attributes.

BeforeTestRun and AfterTestRun:

 * These attributes are used to perform certain operations before and after the test run starts.
   For example, opening the database connection before the test run starts and closing the database connection after the test run is finished.
  
BeforeStep and AfterStep:

* These attributes are used to perform specific operations before and after each scenario step.
 It is used in step-by-step tests, where certain actions must be performed before and after each step.



BeforeTestRun: Used to specify the operations performed before the test run begins.

BeforeFeature: Used to specify the operations performed before each feature is run.

BeforeScenario: Used to specify the actions taken before each scenario starts.

BeforeStep: Used to specify the operations performed before each scenario step.

Before: Used to indicate the operations performed before each scenario step. However, the BeforeStep attribute is preferred.

AfterStep: Used to specify the actions performed after each scenario step.

After: Used to indicate the actions taken after each scenario step. However, the AfterStep attribute is preferred.

AfterScenario: Used to indicate the actions taken after each scenario is finished.

AfterFeature: It is used to indicate the operations performed after each feature is completed.

AfterTestRun: Used to specify operations performed after the test run is finished.

 */


//[Binding]
//public class Hooks
//{
//    private readonly ScenarioContext _scenarioContext;
//    private readonly FeatureContext _featureContext;
//    private readonly ScenarioStepContext _scenarioStepContext;

//    private IWebDriver _driver;


//    public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext, ScenarioStepContext scenarioStepContext)
//    {
//        _scenarioContext = scenarioContext;
//        _featureContext = featureContext;
//        _scenarioStepContext = scenarioStepContext;
//    }

//    [BeforeScenario]
//    public void BeforeScenario()
//    {
//        Console.WriteLine("Before scenario: {Scenario}", _scenarioContext.ScenarioInfo.Title);
//        WebDriverFactory.InitializeWebDriver();
//        _driver = WebDriverFactory.GetDriver();
//    }

//    [AfterScenario]
//    public void AfterScenario()
//    {
//        Console.WriteLine("After scenario: {Scenario}", _scenarioContext.ScenarioInfo.Title);
//        WebDriverFactory.CloseWebDriver();
//    }

//    [BeforeFeature]
//    public static void BeforeFeature()
//    {
//        Console.WriteLine("Before feature: {Feature}");
//    }

//    [AfterFeature]
//    public static void AfterFeature()
//    {
//        Console.WriteLine("After feature: {Feature}");
//    }

//    [Before]
//    public void BeforeMethod()
//    {
//        Console.WriteLine("Before : {Before}", _scenarioContext.ScenarioInfo.Title);
//    }

//    [After]
//    public void AfterMethod()
//    {
//        Console.WriteLine("After : {After}", _scenarioContext.ScenarioInfo.Title);
//    }

//    [BeforeTestRun]
//    public static void BeforeTestRun()
//    {
      
//    }

//    [AfterTestRun]
//    public static void AfterTestRun()
//    {
      
//    }

//    [BeforeStep]
//    public void BeforeStep()
//    {
//        Console.WriteLine("Before Step : {Step}", _scenarioStepContext.StepInfo);
//    }

//    [AfterStep]
//    public void AfterStep()
//    {
//        Console.WriteLine("After Step : {Step}", _scenarioStepContext.StepInfo);
//    }
//}
