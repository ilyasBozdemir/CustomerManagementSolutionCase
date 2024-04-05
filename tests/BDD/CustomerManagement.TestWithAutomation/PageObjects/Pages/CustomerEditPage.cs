using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using Serilog;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;
public class CustomerEditPage : BasePage
{
    private readonly string _userId;

    public IWebElement CustomerEditSaveButton;
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
            throw new NoSuchElementException("The expected edit page is not loaded. Unable to perform the action.");
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
            CustomerEditSaveButton = FindElement(By.XPath("/html/body/div/main/form/button"));
            ClickElement(CustomerEditSaveButton);
        }
        else
        {
            throw new NoSuchElementException("The expected edit page is not loaded. Unable to click the customer edit save Button.");
        }
    }
}

