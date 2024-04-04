using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using SeleniumExtras.PageObjects;


namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerCreatePage : BasePage
{
    [FindsBy(How = How.XPath, Using = "//*[@id=\"FirstName\"]")]
    private readonly IWebElement FirstNameInput;


    [FindsBy(How = How.XPath, Using = "//*[@id=\"LastName\"]")]
    private readonly IWebElement LastNameInput;


    [FindsBy(How = How.XPath, Using = "//*[@id=\"FirstName\"]")]
    private readonly IWebElement DateOfBirthInput;


    [FindsBy(How = How.XPath, Using = "//*[@id=\"BankAccountNumber\"]")]
    private readonly IWebElement PhoneNumberInput;


    [FindsBy(How = How.XPath, Using = "//*[@id=\"Email\"]")]
    private readonly IWebElement EmailInput;


    [FindsBy(How = How.XPath, Using = "//*[@id=\"FirstName\"]")]
    private readonly IWebElement BankAccountNumberInput;


    [FindsBy(How = How.XPath, Using = "/html/body/div/main/form/button")]
    public readonly IWebElement CreateCustomerButtonForm;

    public string Url => _baseUrl + "/Customer/Create";
    public CustomerCreatePage():base()
    {

    }
    public void NavigateToCustomerPage(string url)
    {
        base.NavigateTo(url);
    }

    public void FillCustomerFirstName(string FirstName)
    {
        By by = FirstNameInput as By;

        base.SendKeysToElement(by, FirstName);
    }

    public void FillCustomerLastName(string LastName)
    {
        By by = LastNameInput as By;
        base.SendKeysToElement(by, LastName);
    }

    public void FillCustomerDateOfBirth(string DateOfBirth)
    {
        By by = DateOfBirthInput as By;
        base.SendKeysToElement(by, DateOfBirth);
    }

    public void FillCustomerPhoneNumber(string PhoneNumber)
    {
        By by = PhoneNumberInput as By;
        base.SendKeysToElement(by, PhoneNumber);
    }

    public void FillCustomerEmail(string Email)
    {
        By by = EmailInput as By;
        base.SendKeysToElement(by, Email);
    }

    public void FillCustomerBankAccountNumberInput(string BankAccountNumber)
    {
        By by = BankAccountNumberInput as By;
        base.SendKeysToElement(by, BankAccountNumber);
    }

    public void ClickCreateCustomerConfirmButton()
    {
        CreateCustomerButtonForm.Click();
    }

    public bool IsSuccessMessageDisplayed(string expectedMessage)
    {
        try
        {
            IAlert alert = base.driver.SwitchTo().Alert();

            if (alert.Text.Equals(expectedMessage))
                return true;
            else
                return false;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }
}
