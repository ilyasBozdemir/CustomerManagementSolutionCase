using CustomerManagement.Application.Features.Queries.GetCustomers;
using CustomerManagement.BDD.TestWithAutomation.PageObjects;
using CustomerManagement.Domain.Seedwork;
using MediatR;
using Moq;
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


    public void ClickEditLinkById(Guid customerId)
    {
        if (IsIndexPage())
        {
            var editLink = FindElement(By.XPath($"//tr[@id='{customerId.ToString()}']//td[6]/a[text()='Edit']"));
            ClickElement(editLink);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }
    }

    public void ClickDetailsLinkById(Guid customerId)
    {
        if (IsIndexPage())
        {
            var detailsLink = FindElement(By.XPath($"//tr[@id='{customerId.ToString()}']//td[6]/a[text()='Details']"));
            ClickElement(detailsLink);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }
    }

    public void ClickDeleteLinkById(Guid customerId)
    {
        if (IsIndexPage())
        {
            var deleteLink = FindElement(By.XPath($"//tr[@id='{customerId.ToString()}']//td[6]/a[text()='Delete']"));
            ClickElement(deleteLink);
        }
        else
        {
            throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
        }
       
    }

    public void HandleDeleteConfirmation(string expectedMessage)
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();

            if (alert.Text == expectedMessage)
            {
                alert.Accept();
                driver.SwitchTo().DefaultContent();
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



    public bool IsSuccessMessageDisplayed(string expectedMessage)
    {
        try
        {
            Thread.Sleep(1000);
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

    public async Task<Guid> GetFirstCustomerFromDatabase()// testing
    {
        var unitOfWork = new Mock<IUnitOfWork>();
        var mediator = new Mock<IMediator>();



        var handler = new GetCustomersQueryHandler(unitOfWork.Object, mediator.Object);

        var response = await handler.Handle(new GetCustomersQueryRequest(), default);


        return response.Pagination.Items[0].Id;
    }
}
