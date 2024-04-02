using OpenQA.Selenium;

namespace CustomerManagement.TestWithAutomation.PageObjects.Components;

public class CustomerCreatePageComponents: BasePageComponents
{
    public readonly IWebElement FirstNameInput;// /Customer/Create
    public readonly IWebElement LastNameInput;// /Customer/Create
    public readonly IWebElement DateOfBirthInput;// /Customer/Create
    public readonly IWebElement PhoneNumberInput;// /Customer/Create
    public readonly IWebElement EmailInput;// /Customer/Create
    public readonly IWebElement BankAccountNumberInput;// /Customer/Create
   

    public CustomerCreatePageComponents(IWebDriver driver) : base(driver)
    {
        _driver = driver;
        FirstNameInput = _driver.FindElement(By.XPath("//*[@id=\"FirstName\"]"));
        LastNameInput = _driver.FindElement(By.XPath("//*[@id=\"LastName\"]"));
        DateOfBirthInput = _driver.FindElement(By.XPath("//*[@id=\"DateOfBirth\"]"));
        PhoneNumberInput = _driver.FindElement(By.XPath("//*[@id=\"PhoneNumber\"]"));
        EmailInput = _driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
        BankAccountNumberInput = _driver.FindElement(By.XPath("//*[@id=\"BankAccountNumber\"]"));
    }
}
