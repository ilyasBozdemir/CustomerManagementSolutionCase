using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace CustomerManagement.Tests.TestRunners;

public class TestExecutor
{
    private readonly ITestExecutionEngine _executionEngine;

    public TestExecutor(ITestExecutionEngine executionEngine)
    {
        _executionEngine = executionEngine;
    }

    public void ExecuteTests()
    {
        _executionEngine.OnTestRunStart();
        _executionEngine.OnTestRunEnd();
    }
}
