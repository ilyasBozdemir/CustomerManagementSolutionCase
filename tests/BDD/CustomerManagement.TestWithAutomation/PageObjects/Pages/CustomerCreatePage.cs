using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.Drivers;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerCreatePage : BasePage
{
    private readonly IWebElement FirstNameInput;
    private readonly IWebElement LastNameInput;
    private readonly IWebElement DateOfBirthInput;
    private readonly IWebElement PhoneNumberInput;
    private readonly IWebElement EmailInput;
    private readonly IWebElement BankAccountNumberInput;
    public readonly IWebElement CreateCustomerButtonForm;

    public string Url => _baseUrl + "/Customer/Create";
    public CustomerCreatePage()
    {
        this.driver = WebDriverFactory.GetDriver();

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

        FirstNameInput = driver.FindElement(By.XPath("//*[@id=\"FirstName\"]"));
        LastNameInput = driver.FindElement(By.XPath("//*[@id=\"LastName\"]"));
        PhoneNumberInput = driver.FindElement(By.XPath("//*[@id=\"PhoneNumber\"]"));
        EmailInput = driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
        BankAccountNumberInput = driver.FindElement(By.XPath("//*[@id=\"BankAccountNumber\"]"));
        CreateCustomerButtonForm = driver.FindElement(By.XPath("/html/body/div/main/form/button"));
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
