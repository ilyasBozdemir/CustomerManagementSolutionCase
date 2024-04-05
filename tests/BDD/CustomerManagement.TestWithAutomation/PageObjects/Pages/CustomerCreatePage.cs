using CustomerManagement.BDD.TestWithAutomation.PageObjects;


namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerCreatePage : BasePage
{
    public IWebElement FirstNameInput;
    public IWebElement LastNameInput;
    public IWebElement DateOfBirthInput;
    public IWebElement PhoneNumberInput;
    public IWebElement EmailInput;
    public IWebElement BankAccountNumberInput;
    public IWebElement CreateCustomerButtonForm;

    public string Url => _baseUrl + "/Customer/Create";
    public CustomerCreatePage() : base()
    {

    }


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
            throw new NoSuchElementException("The expected index page is not loaded. Unable to perform the action.");
        }
    }

    public void FillCustomerFirstName(string FirstName)
    {
        FillInputElement(By.XPath("//*[@id=\"FirstName\"]"), FirstName);
    }

    public void FillCustomerLastName(string LastName)
    {
        FillInputElement(By.XPath("//*[@id=\"LastName\"]"), LastName);
    }

    public void FillCustomerDateOfBirth(string DateOfBirth)
    {
        FillInputElement(By.XPath("//*[@id=\"DateOfBirth\"]"), DateOfBirth);
    }

    public void FillCustomerPhoneNumber(string PhoneNumber)
    {
        FillInputElement(By.XPath("//*[@id=\"PhoneNumber\"]"), PhoneNumber);
    }

    public void FillCustomerEmail(string Email)
    {
        FillInputElement(By.XPath("//*[@id=\"Email\"]"), Email);
    }

    public void FillCustomerBankAccountNumberInput(string BankAccountNumber)
    {
        FillInputElement(By.XPath("//*[@id=\"BankAccountNumber\"]"), BankAccountNumber);
    }

    #endregion



    public void ClickCreateCustomerConfirmButton()
    {
        if (IsCreatePage())
        {
            CreateCustomerButtonForm = FindElement(By.XPath("/html/body/div/main/form/button"));
            ClickElement(CreateCustomerButtonForm);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
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
}
