using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.TestWithAutomation.Drivers;


namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerCreatePage : BasePage
{
    public readonly IWebElement FirstNameInput;// /Customer/Create
    public readonly IWebElement LastNameInput;// /Customer/Create
    public readonly IWebElement DateOfBirthInput;// /Customer/Create
    public readonly IWebElement PhoneNumberInput;// /Customer/Create
    public readonly IWebElement EmailInput;// /Customer/Create
    public readonly IWebElement BankAccountNumberInput;// /Customer/Create

    public CustomerCreatePage(IWebDriver _driver) : base(_driver)
    {
        base.driver = WebDriverFactory.GetDriver();

        FirstNameInput = driver.FindElement(By.XPath("//*[@id=\"FirstName\"]"));
        LastNameInput = driver.FindElement(By.XPath("//*[@id=\"LastName\"]"));
        DateOfBirthInput = driver.FindElement(By.XPath("//*[@id=\"DateOfBirth\"]"));
        PhoneNumberInput = driver.FindElement(By.XPath("//*[@id=\"PhoneNumber\"]"));
        EmailInput = driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
        BankAccountNumberInput = driver.FindElement(By.XPath("//*[@id=\"BankAccountNumber\"]"));
    }
}
