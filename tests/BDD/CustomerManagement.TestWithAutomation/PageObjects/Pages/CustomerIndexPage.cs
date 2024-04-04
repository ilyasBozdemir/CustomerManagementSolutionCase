using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using System.Security.Policy;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerIndexPage : BasePage
{
    public IWebElement CreateCustomerButton;

    public string Url => _baseUrl + "/Customer/Index";

    public CustomerIndexPage() : base() { }

    public bool IsIndexPage()
    {
        return GetCurrentUrl().Contains(Url);
    }

    public void NavigateToCustomerIndexPage(string url) => NavigateTo(url);

    public void ClickCreateCustomerButton()
    {
        if (IsIndexPage())
        {
            CreateCustomerButton = FindElement(By.XPath("/html/body/div/main/p/a"));
            ClickElement(CreateCustomerButton);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }
    }
}
