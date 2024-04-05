using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.Constant;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerCreatePage : BasePage
{
    public readonly string FirstNameInputXPath = "//*[@id=\"FirstName\"]";
    public readonly string LastNameInputXPath = "//*[@id=\"LastName\"]";
    public readonly string DateOfBirthInputXPath = "//*[@id=\"DateOfBirth\"]";
    public readonly string PhoneNumberInputXPath = "//*[@id=\"PhoneNumber\"]";
    public readonly string EmailInputXPath = "//*[@id=\"Email\"]";
    public readonly string BankAccountNumberInputXPath = "//*[@id=\"BankAccountNumber\"]";
    public readonly string CreateCustomerButtonFormXPath = "/html/body/div/main/form/button";

    public string Url => _baseUrl + "/Customer/Create";

    public CustomerCreatePage(): base() { }

    public bool IsCreatePage() => GetCurrentUrl().Contains(Url);

    #region Fill Form Elements

    private void FillInputElement(By locator, string value)
    {
        if (IsCreatePage())
        {
            SendKeysToElement(locator, value);
        }
        else
        {
            throw new NoSuchElementException(
                "The expected index page is not loaded. Unable to perform the action."
            );
        }
    }

    public void FillCustomerFirstName(string FirstName)
    {
        FillInputElement(By.XPath(FirstNameInputXPath), FirstName);
    }

    public void FillCustomerLastName(string LastName)
    {
        FillInputElement(By.XPath(LastNameInputXPath), LastName);
    }

    public void FillCustomerDateOfBirth(string DateOfBirth)
    {
        FillInputElement(By.XPath(DateOfBirthInputXPath), DateOfBirth);
    }

    public void FillCustomerPhoneNumber(string PhoneNumber)
    {
        FillInputElement(By.XPath(PhoneNumberInputXPath), PhoneNumber);
    }

    public void FillCustomerEmail(string Email)
    {
        FillInputElement(By.XPath(EmailInputXPath), Email);
    }

    public void FillCustomerBankAccountNumberInput(string BankAccountNumber)
    {
        FillInputElement(By.XPath(BankAccountNumberInputXPath), BankAccountNumber);
    }

    #endregion



    public void ClickCreateCustomerConfirmButton()
    {
        if (IsCreatePage())
        {
            ClickElement(FindElement(By.XPath(CreateCustomerButtonFormXPath)));
        }
        else
        {
            throw new NoSuchElementException(ErrorMessages.IndexPageNotLoaded);
        }
    }

    public bool IsSuccessMessageDisplayed(string expectedMessage)
    {
        try
        {
            IAlert alert = base.driver.SwitchTo().Alert();

            if (alert.Text.Equals(expectedMessage))
            {
                alert.Accept();
                return true;
            }
            else
                return false;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    public bool IsErrorMessageDisplayed(string errorMessage)
    {
        try
        {
            var errorMessageElement = driver.FindElement(
                By.XPath($"//*[contains(text(), '{errorMessage}')]")
            );
            return errorMessageElement.Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
