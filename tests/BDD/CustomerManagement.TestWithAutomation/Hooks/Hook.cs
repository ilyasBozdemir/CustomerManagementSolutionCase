using Serilog;
using TechTalk.SpecFlow.Bindings;
using CustomerManagement.Infrastructure.Services;
using CustomerManagement.TestWithAutomation.Constant;
using CustomerManagement.TestWithAutomation.Drivers;


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
        _loggerService = new LoggerService();
        _loggerService.InitializeLogger(AppTestConstants.exportRootDirectory);
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
    public static void BeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        string featureName = featureContext.FeatureInfo.Title;
        string scenarioName = scenarioContext.ScenarioInfo.Title;

        _logger.Information($"Scenario '{scenarioName}' of feature '{featureName}' started.");
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
    public static void AfterScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        string featureName = featureContext.FeatureInfo.Title;
        string scenarioName = scenarioContext.ScenarioInfo.Title;

        _logger.Information($"Scenario '{scenarioName}' of feature '{featureName}' finished.");
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
