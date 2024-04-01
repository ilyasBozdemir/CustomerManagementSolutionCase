using CustomerManagement.Application.Features.DTOs;
using CustomerManagement.BDD.Tests.Components;
using OpenQA.Selenium;

namespace CustomerManagement.BDD.Tests.PageObjects;



public class CustomerPage : BasePage
{
    private CreateCustomerComponents customerComponents;


    public CustomerPage(IWebDriver driver) : base(driver)
    {

    }


    public void AddCustomer(CustomerDTO customer)
    {

    }


    public void DeleteCustomer(string customerId)
    {

    }
 

    public void UpdateCustomer(Guid Id ,CustomerDTO customer)
    {

    }
}
