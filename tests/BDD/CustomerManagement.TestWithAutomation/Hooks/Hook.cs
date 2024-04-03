using CustomerManagement.Infrastructure.Services;
using CustomerManagement.TestWithAutomation.Drivers;
using Serilog;
using TechTalk.SpecFlow.Bindings;

namespace CustomerManagement.TestWithAutomation.Hooks;

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
        WebDriverFactory.InitializeWebDriver();

        _driver = WebDriverFactory.GetDriver();
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
    }

    [AfterFeature]
    public static void AfterFeature()
    {
        _logger.Information("Feature finished.");
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        _logger.Information("All Test finished.");
        WebDriverFactory.CloseWebDriver();
        Log.CloseAndFlush();
    }
}
