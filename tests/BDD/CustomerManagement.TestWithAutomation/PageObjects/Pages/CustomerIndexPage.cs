using CustomerManagement.BDD.TestWithAutomation.PageObjects;

namespace CustomerManagement.TestWithAutomation.PageObjects.Pages;

public class CustomerIndexPage : BasePage
{
    public IWebElement CreateCustomerButton;

    public string Url => _baseUrl + "/Customer";

    public CustomerIndexPage() : base() { }

    public bool IsIndexPage() => GetCurrentUrl().Contains(Url);

    public void NavigateToCustomerIndexPage(string url) => NavigateTo(url);

    public void ClickCreateCustomerButton()
    {
        if (IsIndexPage())
        {
            CreateCustomerButton = FindElement(By.XPath("/html/body/div/main/p/a"));
            ClickElement(CreateCustomerButton);
            return;
        }
        throw new NoSuchElementException("The expected index page is not loaded. Unable to click the Create Customer button.");
    }


    private void ClickLinkByActionAndId(string customerId, string action)
    {
        if (IsIndexPage())
        {
            var link = FindElement(By.XPath($"//tr[@id='{customerId}']//td[6]/a[text()='{action}']"));
            ClickElement(link);
            return;
        }

        throw new NoSuchElementException("The expected index page is not loaded. Unable to click the button.");

    }

    public void ClickEditLinkById(string customerId) => ClickLinkByActionAndId(customerId, "Edit");


    public void ClickDetailsLinkById(string customerId) => ClickLinkByActionAndId(customerId, "Details");


    public void ClickDeleteLinkById(string customerId) => ClickLinkByActionAndId(customerId, "Delete");


    public string GetFirstCustomerId()
    {
        string result = FindElement(By.XPath("//table/tbody/tr[1]")).GetAttribute("id");

        if (result is null)
        {
            throw new NullReferenceException();
        }
        return result;
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

    public bool IsDataDisplayed()
    {
        try
        {
            if (IsIndexPage())
            {
                var tableElementPresent = IsElementPresent(By.XPath("/html/body/div/main/table"));
              
                if (tableElementPresent)
                {
                    return true;
                }

                //var paragraphElementPresent = IsElementPresent(By.XPath("/html/body/div/main/p[2]"));
                //if (paragraphElementPresent)
                //{
                //    return false;
                //}

                return false;

            }
            else
            {
                throw new NoSuchElementException("The expected index page is not loaded. Unable to check if data is displayed.");
            }
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

}


