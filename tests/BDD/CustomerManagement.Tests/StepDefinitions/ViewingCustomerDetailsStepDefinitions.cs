using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding]
[Scope(Feature = "Customer Management", Scenario = "Viewing Customer Details")]
public class ViewingCustomerDetailsStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    public ViewingCustomerDetailsStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    [Given(@"The user opens the application and enters the address '(.*)'")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        _scenarioContext.Pending();
    }

    [When(@"The user selects a customer from the customer list")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
        _scenarioContext.Pending();
    }

    [When(@"The user chooses to view the details of the customer")]
    public void WhenTheUserChoosesToViewTheDetailsOfTheCustomer()
    {
        _scenarioContext.Pending();
    }

    [Then(@"The user sees the details of the selected customer")]
    public void ThenTheUserSeesTheDetailsOfTheSelectedCustomer()
    {
        _scenarioContext.Pending();
    }
}