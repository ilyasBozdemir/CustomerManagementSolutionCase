namespace CustomerManagement.TestWithAutomation.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Customer Listing", Tag = "ListingCustomer")]
public class ListingCustomerSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ListingCustomerSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        // Kullanıcı uygulamayı açar ve belirtilen adrese girer
    }

    [When(@"The user chooses to view the customer list\.")]
    public void WhenTheUserChoosesToViewTheCustomerList()
    {
        // Kullanıcı müşteri listesini görüntülemeyi seçer
    }

    [Then(@"the user sees the current customer list")]
    public void ThenTheUserSeesTheCurrentCustomerList()
    {
        // Kullanıcı mevcut müşteri listesini görür
    }
}
