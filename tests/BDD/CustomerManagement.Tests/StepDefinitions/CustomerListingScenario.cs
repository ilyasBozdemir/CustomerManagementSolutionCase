using CustomerManagement.Tests.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Customer Listing")]
public class CustomerListingScenario
{
    private CustomerIndexPage _indexPage;

    [Given(@"The user opens the application and enters the address '(.*)'")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address) { }

    [When(@"The user chooses to view the customer list")]
    public void WhenTheUserChoosesToViewTheCustomerList() { }

    [Then(@"The user sees the current customer list")]
    public void ThenTheUserSeesTheCurrentCustomerList() { }
}
