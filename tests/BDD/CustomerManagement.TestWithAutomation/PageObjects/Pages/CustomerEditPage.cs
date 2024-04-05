using CustomerManagement.BDD.TestWithAutomation.PageObjects;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;
public class CustomerEditPage : BasePage
{
    private readonly Guid _userId;
    public string Url => GetUrl();
    public CustomerEditPage(Guid userId)
    {
        _userId = userId;
    }
    private string GetUrl() => $"{_baseUrl}/Edit/{_userId}";
    public bool IsEditPage() => GetCurrentUrl().Contains(Url);

}

