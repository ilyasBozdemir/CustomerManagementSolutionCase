namespace CustomerManagement.TestWithAutomation.StepDefinitions;


[Binding, Scope(Feature = "Customer Management", Scenario = "Updating Customer Information", Tag = "UpdatingCustomerInformation")]
public class UpdatingCustomerInformationSteps
{
    private readonly ScenarioContext _scenarioContext;

    public UpdatingCustomerInformationSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        // Kullanıcı uygulamayı açar ve belirtilen adrese girer
    }

    [When(@"the user selects a customer from the customer list\.")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
        // Kullanıcı müşteri listesinden bir müşteri seçer
    }

    [When(@"the user chooses to update customer information\.")]
    public void WhenTheUserChoosesToUpdateCustomerInformation()
    {
        // Kullanıcı müşteri bilgilerini güncellemeyi seçer
    }

    [When(@"the user updates the customer's name to '(.*)'\.")]
    public void WhenTheUserUpdatesTheCustomerNameTo(string name)
    {
        // Kullanıcı müşterinin adını belirtilen değere günceller
    }

    [When(@"the user updates the customer's last name to '(.*)'\.")]
    public void WhenTheUserUpdatesTheCustomerLastNameTo(string lastName)
    {
        // Kullanıcı müşterinin soyadını belirtilen değere günceller
    }

    [When(@"the user confirms the update process\.")]
    public void WhenTheUserConfirmsTheUpdateProcess()
    {
        // Kullanıcı güncelleme işlemini onaylar
    }

    [Then(@"the user sees updated customer information")]
    public void ThenTheUserSeesUpdatedCustomerInformation()
    {
        // Kullanıcı güncellenen müşteri bilgilerini görür
    }
}
