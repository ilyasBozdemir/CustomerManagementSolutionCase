using CustomerManagement.Tests.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Creating a New Customer")]
public class CustomerCreationScenario
{
    private CustomerCreatePage _createPage;

    [Given(@"The user opens the application and enters the address '(.*)'")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address) { }

    [When(@"the user chooses to create a new customer")]
    public void WhenTheUserChoosesToCreateANewCustomer() { }

    [When(@"the user enters the new customer's name as '(.*)'")]
    public void WhenTheUserEntersTheNewCustomerNameAs(string name) { }

    [When(@"the user enters the new customer's last name as '(.*)'")]
    public void WhenTheUserEntersTheNewCustomerLastNameAs(string lastName) { }

    [Then(@"the user sees that the new customer has been successfully created")]
    public void ThenTheUserSeesThatTheNewCustomerHasBeenSuccessfullyCreated() { }

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
