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
    public  void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
        //A customer ID previously added to the database
        var customerID =  Guid.Parse("985fbc72-1386-4079-4307-08dc54de8c95".ToLower());
        _scenarioContext["customerID"] = customerID;
    }




    [When(@"the user chooses to delete the customer\.")]
    public void WhenTheUserChoosesToDeleteTheCustomer()
    {
        Guid guid = Guid.Parse(_scenarioContext["customerID"].ToString());

        _indexPage.ClickDeleteLinkById(Guid.Parse(_scenarioContext["customerID"].ToString()));
    }

    [When(@"The user confirms the deletion\.")]
    public void WhenTheUserConfirmsTheDeletion()
    {
        _indexPage.HandleDeleteConfirmation("Are you sure you want to delete this customer?");
    }

    [Then(@"the user sees that the customer has been successfully deleted")]
    public void ThenTheUserSeesThatTheCustomerHasBeenSuccessfullyDeleted()
    {
        Assert.True(_indexPage.IsSuccessMessageDisplayed("The deletion was successful."));
    }
}
