using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using SeleniumExtras.PageObjects;


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
    public void FillCustomerFirstName(string FirstName)
    {
        if (IsCreatePage())
        {
            By firstNameLocator = By.XPath("//*[@id=\"FirstName\"]");
            SendKeysToElement(firstNameLocator, FirstName);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to fill the customer first name.");
        }
    }


    public void FillCustomerLastName(string LastName)
    {

        if (IsCreatePage())
        {
            SendKeysToElement(By.XPath("//*[@id=\"LastName\"]"), LastName);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }

    }


    public void FillCustomerDateOfBirth(string DateOfBirth)
    {
        if (IsCreatePage())
        {
            SendKeysToElement(By.XPath("//*[@id=\"DateOfBirth\"]"), DateOfBirth);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }

    }


    public void FillCustomerPhoneNumber(string PhoneNumber)
    {
        if (IsCreatePage())
        {
            SendKeysToElement(By.XPath("//*[@id=\"PhoneNumber\"]"), PhoneNumber);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }

    }


    public void FillCustomerEmail(string Email)
    {
        if (IsCreatePage())
        {
            SendKeysToElement(By.XPath("//*[@id=\"Email\"]"), Email);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }

    }


    public void FillCustomerBankAccountNumberInput(string BankAccountNumber)
    {
        if (IsCreatePage())
        {
            SendKeysToElement(By.XPath("//*[@id=\"BankAccountNumber\"]"), BankAccountNumber);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }
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
