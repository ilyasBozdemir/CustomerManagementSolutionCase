using CustomerManagement.BDD.TestWithAutomation.PageObjects;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerDetailPage : BasePage
{
    private readonly Guid _userId;
    public CustomerDetailPage(Guid userId)
    {
        _userId = userId;

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    }
    public string GetUrl() => $"{_baseUrl}/Details/{_userId}";
   
}