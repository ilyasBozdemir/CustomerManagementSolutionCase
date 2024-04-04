using CustomerManagement.TestWithAutomation.PageObjects.Pages;
using Xunit;

namespace CustomerManagement.TestWithAutomation.StepDefinitions;

[Binding, Scope(Feature = "Customer Management", Scenario = "Creating a New Customer", Tag = "CreateCustomer")]
public class CreatingNewCustomerSteps
{
    private CustomerIndexPage _indexPage;
    private CustomerCreatePage _createPage;


    private CreatingNewCustomerSteps()
    {
        _indexPage = new();
        _createPage = new();
    }


    [Given(@"The user opens the application and enters the address '(.*)'\.")]
    public void GivenTheUserOpensTheApplicationAndEntersTheAddress(string address)
    {
        _indexPage.NavigateToCustomerIndexPage(address);
    }

    [When(@"the user chooses to create a new customer\.")]
    public void WhenTheUserChoosesToCreateANewCustomer()
    {
        _indexPage.ClickCreateCustomerButton();
    }

    [When(@"the user enters the new customer's name as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerNameAs(string name)
    {
        _createPage.FillCustomerFirstName(name);
    }

    [When(@"the user enters the new customer's last name as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerLastNameAs(string lastName)
    {
        _createPage.FillCustomerLastName(lastName);
    }

    [When(@"The user enters the new customer's date of birth as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerDateOfBirthAs(string dateOfBirth)
    {
        _createPage.FillCustomerDateOfBirth(dateOfBirth);
    }

    [When(@"The user enters the new customer's phone number as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerPhoneNumberAs(string phoneNumber)
    {
        _createPage.FillCustomerPhoneNumber(phoneNumber);
    }

    [When(@"the user enters the new customer's email address as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerEmailAddressAs(string emailAddress)
    {
        _createPage.FillCustomerEmail(emailAddress);
    }

    [When(@"The user enters the new customer's bank account number as '(.*)'\.")]
    public void WhenTheUserEntersTheNewCustomerBankAccountNumberAs(string bankAccountNumber)
    {
        _createPage.FillCustomerBankAccountNumberInput(bankAccountNumber);
    }

    [When(@"The user confirms that the new customer has been created\.")]
    public void WhenTheUserConfirmsThatTheNewCustomerHasBeenCreated()
    {
        _createPage.ClickCreateCustomerConfirmButton();
    }

    [Then(@"the user sees that the new customer has been successfully created\.")]
    public void ThenTheUserSeesThatTheNewCustomerHasBeenSuccessfullyCreated()
    {
        Assert.True(_createPage.IsSuccessMessageDisplayed("Customer created successfully."));
    }
}
