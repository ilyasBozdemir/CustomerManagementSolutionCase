using CustomerManagement.TestWithAutomation.PageObjects.Pages;
using Xunit;

namespace CustomerManagement.TestWithAutomation.StepDefinitions;


[Binding, Scope(Feature = "Customer Management", Scenario = "Updating Customer Information", Tag = "UpdatingCustomerInformation")]
public class UpdatingCustomerInformationSteps
{

    private readonly ScenarioContext _scenarioContext;
    private CustomerIndexPage _indexPage;
    private CustomerEditPage _editPage;
    public UpdatingCustomerInformationSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _indexPage = new();

    }

    [Given(@"the user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        //string CustomerId = address.Replace("{customer-id}", _scenarioContext["CustomerId"] as string);

        _indexPage.NavigateTo(address);
    }

    [When(@"the user selects a customer from the customer list\.")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
        var customerID = _indexPage.GetFirstCustomerId();
        _scenarioContext["customerID"] = customerID;

        _editPage = new(customerID);
    }

    [When(@"the user chooses to update customer information\.")]
    public void WhenTheUserChoosesToUpdateCustomerInformation()
    {
        _indexPage.ClickEditLinkById(_editPage.UserId);
    }

    [When(@"the user updates the customer's name to '(.*)'\.")]
    public void WhenTheUserUpdatesTheCustomerNameTo(string name)
    {
        _editPage.FillCustomerFirstName(name);
    }

    [When(@"the user updates the customer's last name to '(.*)'\.")]
    public void WhenTheUserUpdatesTheCustomerLastNameTo(string lastName)
    {
        _editPage.FillCustomerLastName(lastName);
    }

    [When(@"the user confirms the update process\.")]
    public void WhenTheUserConfirmsTheUpdateProcess()
    {
        _editPage.ClickConfirmButton();
    }

    [Then(@"the user sees updated customer information\.")]
    public void ThenTheUserSeesUpdatedCustomerInformation()
    {
        Assert.True(_editPage.IsCustomerInformationUpdated());
    }
}
