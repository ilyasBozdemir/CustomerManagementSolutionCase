using CustomerManagement.Application.Features.Queries.GetCustomers;
using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.Domain.Seedwork;
using MediatR;
using Moq;
using SeleniumExtras.WaitHelpers;
using Serilog;
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


    private void ClickLinkByActionAndId(string customerId, string action)
    {
        if (IsIndexPage())
        {
            var link = FindElement(By.XPath($"//tr[@id='{customerId}']//td[6]/a[text()='{action}']"));
            ClickElement(link);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the button.");
        }
    }
    public void ClickEditLinkById(string customerId)
    {
        ClickLinkByActionAndId(customerId, "Edit");
    }

    public void ClickDetailsLinkById(string customerId)
    {
        ClickLinkByActionAndId(customerId, "Details");
    }

    public void ClickDeleteLinkById(string customerId)
    {
        ClickLinkByActionAndId(customerId, "Delete");
    }

    public string GetFirstCustomerId()
    {
        var customerId = FindElement(By.XPath("//table/tbody/tr[1]")).GetAttribute("id");

        return customerId;
    }

    public bool IsSuccessMessageDisplayed(string expectedMessage)
    {
        try
        {
            WaitUntilAlertIsPresent();
            IAlert alert = base.driver.SwitchTo().Alert();

            if (alert.Text == expectedMessage)
            {
                alert.Accept();
                return true;
            }
            else
                return false;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

   

    public void HandleDeleteConfirmation(string expectedMessage)
    {
        try
        {
           Thread.Sleep(200);   
            IAlert alert = driver.SwitchTo().Alert();

            if (alert.Text == expectedMessage)
            {
                alert.Accept();
            }
            else
            {
                Console.WriteLine("Unexpected alert message: " + alert.Text);
            }

          
        }
        catch (NoAlertPresentException)
        {
            Console.WriteLine("No alert present.");
        }
    }


}
