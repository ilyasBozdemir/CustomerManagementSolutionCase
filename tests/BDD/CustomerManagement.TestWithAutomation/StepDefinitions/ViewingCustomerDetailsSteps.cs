using CustomerManagement.TestWithAutomation.PageObjects.Pages;
using Serilog;
using System.Net;
using Xunit;

namespace CustomerManagement.TestWithAutomation.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Viewing Customer Details", Tag = "ViewingCustomerDetails")]
public class ViewingCustomerDetailsSteps
{
    private readonly ScenarioContext _scenarioContext;
    private CustomerIndexPage _indexPage;
    private CustomerDetailPage _detailPage;


    public ViewingCustomerDetailsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _indexPage = new();
    }


    [Given(@"the user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        _indexPage.NavigateTo(address);
    }

    [When(@"the user selects a customer from the customer list\.")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
        var customerID = _indexPage.GetFirstCustomerId();
        //_scenarioContext["customerID"] = customerID;
        _detailPage = new(customerID);
    }

    [When(@"the user chooses to view the details of the customer\.")]
    public void WhenTheUserChoosesToViewTheDetailsOfTheCustomer()
    {
        //var customerID = _scenarioContext["customerID"].ToString();
        _indexPage.ClickDetailsLinkById(_detailPage.UserId);
    }

    [Then(@"the user sees the details of the selected customer\.")]
    public void ThenTheUserSeesTheDetailsOfTheSelectedCustomer()
    {
        var statusCode = _detailPage.GetStatusCodeFromUrl(_detailPage.Url);
        Assert.Equal(HttpStatusCode.OK, statusCode);
    }
}
