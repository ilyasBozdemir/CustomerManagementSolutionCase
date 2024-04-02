using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding]
[Scope(Feature = "Customer Management", Scenario = "Customer Listing", Tag = "CustomerListing")]
public class CustomerListingStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    public CustomerListingStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    [Given(@"The user opens the application and enters the address '(.*)'")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address) 
    {
        _scenarioContext.Pending();
    }

    [When(@"The user chooses to view the customer list")]
    public void WhenTheUserChoosesToViewTheCustomerList()
    {
        _scenarioContext.Pending();
    }

    [Then(@"The user sees the current customer list")]
    public void ThenTheUserSeesTheCurrentCustomerList()
    {
        _scenarioContext.Pending();
    }
}
