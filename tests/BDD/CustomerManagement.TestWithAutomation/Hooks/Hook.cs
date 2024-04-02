using CustomerManagement.TestWithAutomation.Drivers;
using OpenQA.Selenium;

namespace CustomerManagement.TestWithAutomation.Hooks;

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


[Binding]
public class Hooks
{
    private static IWebDriver _driver;

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        
    }

    [BeforeFeature]
    public static void BeforeFeature()
    {
     
    }

    [BeforeScenario]
    public static void BeforeScenario()
    {
        WebDriverFactory.InitializeWebDriver();
        _driver = WebDriverFactory.GetDriver();
    }

    [BeforeStep]
    public static void BeforeStep()
    {
     
    }

    [AfterStep]
    public static void AfterStep()
    {
    
    }

    [AfterScenario]
    public static void AfterScenario()
    {
       
        WebDriverFactory.CloseWebDriver();
    }

    [AfterFeature]
    public static void AfterFeature()
    {
       
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
      
    }
}

