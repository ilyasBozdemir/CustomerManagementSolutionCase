using CustomerManagement.BDD.Tests.Utils;
using CustomerManagement.Tests.PageObjects.Pages;
using TechTalk.SpecFlow;

namespace CustomerManagement.Tests.StepDefinitions;

[Binding]
[Scope(Feature = "Customer Management", Scenario = "Creating a New Customer", Tag = "CreateCustomer")]
public class CreatingNewCustomerStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    private CustomerIndexPage _indexPage;
    private CustomerCreatePage _createPage;
    public CreatingNewCustomerStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;

        _indexPage = new CustomerIndexPage(WebDriverFactory.GetDriver());
        _createPage = new CustomerCreatePage(WebDriverFactory.GetDriver());
    }




    [Given(@"The user opens the application and enters the address '(.*)'")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        WebDriverFactory.NavigateTo(address);
        _indexPage.SetImplicitWait(TimeSpan.FromSeconds(0.5));

    }


    [When(@"the user chooses to create a new customer")]
    public void WhenTheUserChoosesToCreateANewCustomer()
    {

        _scenarioContext.Pending();
    }

    [When(@"the user enters the new customer's name as '(.*)'")]
    public void WhenTheUserEntersTheNewCustomerNameAs(string name)
    {
        _scenarioContext.Pending();

    }

    [When(@"the user enters the new customer's last name as '(.*)'")]
    public void WhenTheUserEntersTheNewCustomerLastNameAs(string lastName)
    {

        _scenarioContext.Pending();
    }


    [Then(@"the user sees that the new customer has been successfully created")]
    public void ThenTheUserSeesThatTheNewCustomerHasBeenSuccessfullyCreated()
    {
        _scenarioContext.Pending();

    }
}
