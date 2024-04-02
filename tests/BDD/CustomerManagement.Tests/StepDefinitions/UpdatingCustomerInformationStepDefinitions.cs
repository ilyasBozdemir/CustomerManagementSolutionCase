using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding]
[Scope(Feature = "Customer Management", Scenario = "Updating Customer Information")]
public class UpdatingCustomerInformationStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    public UpdatingCustomerInformationStepDefinitions(ScenarioContext scenarioContext)
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

    [When(@"The user chooses to update customer information")]
    public void WhenTheUserChoosesToUpdateCustomerInformation()
    {
        _scenarioContext.Pending();
    }

    [When(@"The user updates the customer's name to '(.*)'")]
    public void WhenTheUserUpdatesTheCustomerNameTo(string updatedName)
    {
        _scenarioContext.Pending();
    }

    [When(@"The user updates the customer's last name to '(.*)'")]
    public void WhenTheUserUpdatesTheCustomerLastNameTo(string updatedLastName)
    {
        _scenarioContext.Pending();
    }

    [When(@"The user confirms the update process")]
    public void WhenTheUserConfirmsTheUpdateProcess()
    {
        _scenarioContext.Pending();
    }
    [Then(@"The user sees updated customer information")]
    public void ThenTheUserSeesUpdatedCustomerInformation()
    {
        _scenarioContext.Pending();
    }
}

