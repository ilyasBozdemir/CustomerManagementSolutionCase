using CustomerManagement.TestWithAutomation.PageObjects.Pages;
using Serilog;

namespace CustomerManagement.TestWithAutomation.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Customer Listing", Tag = "ListingCustomer")]
public class ListingCustomerSteps
{
    private readonly ScenarioContext _scenarioContext;
    private CustomerIndexPage _indexPage;
    public ListingCustomerSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _indexPage = new();
    }

    [Given(@"The user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        _indexPage.NavigateToCustomerIndexPage(address);
    }

    //[When(@"The user chooses to view the customer list\.")]
    //public void WhenTheUserChoosesToViewTheCustomerList()
    //{
       
    //}

    [Then(@"the user sees the current customer list\.")]
    public void ThenTheUserShouldSeeATableWithCustomerInformation()
    {
        if (_indexPage.IsDataDisplayed())
            Log.Information("The table with customer information is displayed.");
        else
            Log.Warning("The table with customer information is not displayed.");
    }
}
