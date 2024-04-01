using CustomerManagement.Tests.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Updating Customer Information")]
public class UpdatingCustomerInformationScenario
{
    private CustomerEditPage _editPage;

    [Given(@"The user opens the application and enters the address '(.*)'")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {

    }

    [When(@"The user selects a customer from the customer list")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {

    }

    [When(@"The user chooses to update customer information")]
    public void WhenTheUserChoosesToUpdateCustomerInformation()
    {

    }

    [When(@"The user updates the customer's name to '(.*)'")]
    public void WhenTheUserUpdatesTheCustomerNameTo(string updatedName)
    {

    }

    [When(@"The user updates the customer's last name to '(.*)'")]
    public void WhenTheUserUpdatesTheCustomerLastNameTo(string updatedLastName)
    {

    }

    [When(@"The user confirms the update process")]
    public void WhenTheUserConfirmsTheUpdateProcess()
    {

    }
    [Then(@"The user sees updated customer information")]
    public void ThenTheUserSeesUpdatedCustomerInformation()
    {
      
    }

    [When(@"the system validates the following rules:")]
    public void AndTheSystemValidatesTheFollowingRules(Table table)
    {
        foreach (var row in table.Rows)
        {
            string rule = row["Rule"];
            string expectedResult = row["Result"];
        }
    }
}
