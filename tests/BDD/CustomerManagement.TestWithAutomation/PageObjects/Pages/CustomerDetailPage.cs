using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using System.Net;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerDetailPage : BasePage
{
    private readonly string _userId;

    public string Url => GetUrl();
    public string UserId => _userId;
    public CustomerDetailPage(string userId)
    {
        _userId = userId;
    }
    private string GetUrl() => $"{_baseUrl}/Customer/Details/{_userId}";
    public bool IsDetailPage() => GetCurrentUrl().Contains(Url);

    public HttpStatusCode GetStatusCodeFromUrl(string url)
    {
        var statusCode = GetStatusCodeAsync(url).GetAwaiter().GetResult();

        return statusCode;
    }
}