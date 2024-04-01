using CustomerManagement.Tests.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Customer Deletion")]
public class CustomerDeletionScenario
{
    private CustomerIndexPage _indexPage;

    [Given(@"The user opens the application and enters the address '(.*)'")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
    
    }

    [When(@"The user selects a customer from the customer list")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
     
    }

    [When(@"The user chooses to delete the customer")]
    public void WhenTheUserChoosesToDeleteTheCustomer()
    {
        // Simulate user action to choose deleting the customer
    }

    [When(@"The user confirms the deletion")]
    public void WhenTheUserConfirmsTheDeletion()
    {
        // Simulate user action to confirm the deletion
    }

    [Then(@"The user sees that the customer has been successfully deleted")]
    public void ThenTheUserSeesThatTheCustomerHasBeenSuccessfullyDeleted()
    {

    }
}

