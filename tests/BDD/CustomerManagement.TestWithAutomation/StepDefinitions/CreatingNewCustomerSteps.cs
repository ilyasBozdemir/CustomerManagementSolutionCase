using CustomerManagement.TestWithAutomation.Drivers;
using CustomerManagement.TestWithAutomation.PageObjects.Pages;
using OpenQA.Selenium.Support.UI;

namespace CustomerManagement.TestWithAutomation.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Creating a New Customer", Tag = "CreateCustomer")]
public class CreatingNewCustomerSteps
{
    private IWebDriver _driver;

    [Given(@"The user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        // I used all the steps in this step as a trial.

        _driver = WebDriverFactory.GetDriver();


    }

    [When(@"the user chooses to create a new customer\.")]
    public void WhenTheUserChoosesToCreateANewCustomer()
    {
      
    }

    [When(@"the user enters the new customer's name as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerNameAs(string name)
    {
       
    }

    [When(@"the user enters the new customer's last name as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerLastNameAs(string lastName)
    {
        // Yeni müşterinin soyadı girilir
    }

    [When(@"The user enters the new customer's date of birth as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerDateOfBirthAs(string dateOfBirth)
    {
        // Yeni müşterinin doğum tarihi girilir
    }

    [When(@"The user enters the new customer's phone number as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerPhoneNumberAs(string phoneNumber)
    {
        // Yeni müşterinin telefon numarası girilir
    }

    [When(@"the user enters the new customer's email address as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerEmailAddressAs(string emailAddress)
    {
        // Yeni müşterinin e-posta adresi girilir
    }

    [When(@"The user enters the new customer's bank account number as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerBankAccountNumberAs(string bankAccountNumber)
    {
        // Yeni müşterinin banka hesap numarası girilir
    }

    [When(@"The user confirms that the new customer has been created\.")]
    public void WhenTheUserConfirmsThatTheNewCustomerHasBeenCreated()
    {
        // Yeni müşterinin oluşturulduğu onaylanır
    }

    [Then(@"the user sees that the new customer has been successfully created\.")]
    public void ThenTheUserSeesThatTheNewCustomerHasBeenSuccessfullyCreated()
    {
        // Kullanıcı yeni müşterinin başarıyla oluşturulduğunu görür
    }
}
