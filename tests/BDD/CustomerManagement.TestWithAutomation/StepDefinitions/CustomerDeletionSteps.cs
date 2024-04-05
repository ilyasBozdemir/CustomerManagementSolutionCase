using CustomerManagement.TestWithAutomation.PageObjects.Pages;
using Serilog;
using Xunit;

namespace CustomerManagement.TestWithAutomation.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Customer Deletion", Tag = "CustomerDeletion")]
public class CustomerDeletionSteps
{
    private readonly ScenarioContext _scenarioContext;
    private CustomerIndexPage _indexPage;


    public CustomerDeletionSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _indexPage = new();
    }

    

    [Given(@"The user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        _indexPage.NavigateToCustomerIndexPage(address);
    }


    [When(@"The user selects a customer from the customer list\.")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
        var customerID = _indexPage.GetFirstCustomerId();
        _scenarioContext["customerID"] = customerID;
    }


    [When(@"the user chooses to delete the customer\.")]
    public void WhenTheUserChoosesToDeleteTheCustomer()
    {
        var customerID = _scenarioContext["customerID"].ToString();
        _indexPage.ClickDeleteLinkById(customerID);
    }



    [When(@"The user confirms the deletion\.")]
    public void WhenTheUserConfirmsTheDeletion()
    {
        _indexPage.HandleDeleteConfirmation("Are you sure you want to delete this customer?");
    }



    [Then(@"the user sees that the customer has been successfully deleted\.")]
    public void ThenTheUserSeesThatTheCustomerHasBeenSuccessfullyDeleted()
    {
        Assert.True(_indexPage.IsSuccessMessageDisplayed("The deletion was successful."));
    }
}
