using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.Constant;
using Serilog;
using Xunit.Sdk;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;
public class CustomerEditPage : BasePage
{

    public readonly string FirstNameInputXPath = "//*[@id=\"FirstName\"]";
    public readonly string LastNameInputXPath = "//*[@id=\"LastName\"]";
    public readonly string DateOfBirthInputXPath = "//*[@id=\"DateOfBirth\"]";
    public readonly string PhoneNumberInputXPath = "//*[@id=\"PhoneNumber\"]";
    public readonly string EmailInputXPath = "//*[@id=\"Email\"]";
    public readonly string BankAccountNumberInputXPath = "//*[@id=\"BankAccountNumber\"]";
    public readonly string CustomerEditSaveButtonXPath = "/html/body/div/main/form/button";


    private readonly string _userId;

  
    public string Url => GetUrl();
    public string UserId => _userId;
    public CustomerEditPage(string userId)
    {
        _userId = userId;
    }
    private string GetUrl() => $"{_baseUrl}/Customer/Edit/{_userId}";
    public bool IsEditPage() => GetCurrentUrl().Contains(Url);

    private void FillInputElement(By locator, string value)
    {
        if (IsEditPage())
        {
            SendKeysToElement(locator, value);
        }
        else
        {
            throw new NoSuchElementException(ErrorMessages.EditPageNotLoaded);
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

    public bool IsCustomerInformationUpdated()
    {
        try
        {
            wait.Until(driver => driver.Url == _baseUrl + "/Customer");
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }



    public void ClickConfirmButton()
    {
        if (IsEditPage())
        {
            ClickElement(FindElement(By.XPath(CustomerEditSaveButtonXPath)));
        }
        else
        {
            throw new NoSuchElementException(ErrorMessages.EditPageNotLoaded);
        }
    }
}

