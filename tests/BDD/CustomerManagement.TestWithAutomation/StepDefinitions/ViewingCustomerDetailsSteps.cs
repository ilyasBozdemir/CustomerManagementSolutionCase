namespace CustomerManagement.TestWithAutomation.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Viewing Customer Details", Tag = "ViewingCustomerDetails")]
public class ViewingCustomerDetailsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ViewingCustomerDetailsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        // Kullanıcı uygulamayı açar ve belirtilen adrese girer.
        string CustomerId = address.Replace("{customer-id}", _scenarioContext["CustomerId"] as string);
    }

    [When(@"the user selects a customer from the customer list\.")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
        // Kullanıcı müşteri listesinden bir müşteri seçer
    }

    [When(@"the user chooses to view the details of the customer\.")]
    public void WhenTheUserChoosesToViewTheDetailsOfTheCustomer()
    {
        // Kullanıcı müşterinin detaylarını görüntülemeyi seçer
    }

    [Then(@"the user sees the details of the selected customer")]
    public void ThenTheUserSeesTheDetailsOfTheSelectedCustomer()
    {
        // Kullanıcı seçilen müşterinin detaylarını görür
    }
}
