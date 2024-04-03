using System.Globalization;
using CustomerManagement.Domain.Seedwork;
using CustomerManagement.Infrastructure.Services;
using CustomerManagement.TestWithAutomation.Drivers;
using Serilog;
using TechTalk.SpecFlow.Bindings;



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
    private static LoggerService _loggerService;
    private static ILogger _logger;
    private static IWebDriver _driver;


    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        string rootDirectory = @"D:\CustomerManagementCase";
        _loggerService = new LoggerService();
        _loggerService.InitializeLogger(rootDirectory);
        _logger = _loggerService.GetLogger();
        _logger.Information("Tests started.");
    }

    [BeforeFeature]
    public static void BeforeFeature()
    {
        _logger.Information("Feature started.");
    }

    [BeforeScenario]
    public static void BeforeScenario()
    {
        _logger.Information("Scenario started.");
        WebDriverFactory.InitializeWebDriver();
        _driver = WebDriverFactory.GetDriver();
    }

    [BeforeStep]
    public static void BeforeStep(ScenarioContext scenarioContext)
    {
        _logger.Information(
            "Step '{StepInfo}' is starting.",
            scenarioContext.StepContext.StepInfo.Text
        );
    }

    [AfterStep]
    public static void AfterStep(ScenarioContext scenarioContext)
    {
        var stepInfo = scenarioContext.StepContext.StepInfo;
        var stepStatus = scenarioContext.StepContext.StepInfo.StepDefinitionType;

        // Senaryo adımının durumuna göre loglama
        if (stepStatus == StepDefinitionType.Given)
        {
            if (scenarioContext.TestError == null)
            {
                _logger.Information("Given step '{StepInfo}' succeeded.", stepInfo.Text);
            }
            else
            {
                _logger.Error(
                    scenarioContext.TestError,
                    "Given step '{StepInfo}' failed.",
                    stepInfo.Text
                );
            }
        }
        else if (stepStatus == StepDefinitionType.When)
        {
            if (scenarioContext.TestError == null)
            {
                _logger.Information("When step '{StepInfo}' succeeded.", stepInfo.Text);
            }
            else
            {
                _logger.Error(
                    scenarioContext.TestError,
                    "When step '{StepInfo}' failed.",
                    stepInfo.Text
                );
            }
        }
        else if (stepStatus == StepDefinitionType.Then)
        {
            if (scenarioContext.TestError == null)
            {
                _logger.Information("Then step '{StepInfo}' succeeded.", stepInfo.Text);
            }
            else
            {
                _logger.Error(
                    scenarioContext.TestError,
                    "Then step '{StepInfo}' failed.",
                    stepInfo.Text
                );
            }
        }
        else
        {
            _logger.Warning("Unknown step type: {StepType}", stepStatus);
        }
    }

    [AfterScenario]
    public static void AfterScenario()
    {
        _logger.Information("Scenario finished.");
        WebDriverFactory.CloseWebDriver();
    }

    [AfterFeature]
    public static void AfterFeature()
    {
        _logger.Information("Feature finished.");


    

        // Serilog'un ILogger sınıfı
        ILogger serilogLogger = Log.Logger;

    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        _logger.Information("All Test finished.");
        Log.CloseAndFlush();
    }

   
}
