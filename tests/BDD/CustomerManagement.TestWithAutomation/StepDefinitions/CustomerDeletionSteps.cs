namespace CustomerManagement.TestWithAutomation.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Customer Deletion", Tag = "CustomerDeletion")]
public class CustomerDeletionSteps
{
    private readonly ScenarioContext _scenarioContext;

    public CustomerDeletionSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"The user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        // Kullanıcı uygulamayı açar ve belirtilen adrese girer
    }

    [When(@"The user selects a customer from the customer list\.")]
    public void WhenTheUserSelectsACustomerFromTheCustomerList()
    {
        // Kullanıcı müşteri listesinden bir müşteri seçer
    }

    [When(@"the user chooses to delete the customer\.")]
    public void WhenTheUserChoosesToDeleteTheCustomer()
    {
        // Kullanıcı müşteriyi silmeyi seçer
    }

    [When(@"The user confirms the deletion\.")]
    public void WhenTheUserConfirmsTheDeletion()
    {
        // Kullanıcı silme işlemini onaylar
    }

    [Then(@"the user sees that the customer has been successfully deleted")]
    public void ThenTheUserSeesThatTheCustomerHasBeenSuccessfullyDeleted()
    {
        // Kullanıcı müşterinin başarılı bir şekilde silindiğini görür
    }
}
