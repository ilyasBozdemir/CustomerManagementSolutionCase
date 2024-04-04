using CustomerManagement.BDD.TestWithAutomation.PageObjects;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerDetailPage : BasePage
{
    private readonly Guid _userId;

    public string Url => GetUrl();
    public CustomerDetailPage(Guid userId)
    {
        _userId = userId;
    }
    private string GetUrl() => $"{_baseUrl}/Details/{_userId}";
   
}