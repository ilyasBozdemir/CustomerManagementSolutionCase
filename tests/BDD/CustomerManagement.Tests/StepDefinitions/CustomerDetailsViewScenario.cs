using CustomerManagement.Tests.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Viewing Customer Details")]
public class CustomerDetailsViewScenario
{
    private CustomerIndexPage _indexPage;

    [Given(@"The user opens the application and enters the address '(.*)'")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address) { }

    [When(@"The user selects a customer from the customer list")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList() { }

    [When(@"The user chooses to view the details of the customer")]
    public void WhenTheUserChoosesToViewTheDetailsOfTheCustomer() { }

    [Then(@"The user sees the details of the selected customer")]
    public void ThenTheUserSeesTheDetailsOfTheSelectedCustomer() { }
}
