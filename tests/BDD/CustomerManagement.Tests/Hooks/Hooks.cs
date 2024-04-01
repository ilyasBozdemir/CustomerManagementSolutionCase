using CustomerManagement.BDD.Tests.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CustomerManagement.BDD.Tests.Hooks;

#region DESC
/*
 
EN:
 
* [Before] and [After]:

The [Before] attribute is used to mark a scenario step or a specific method before the scenario starts.
The [After] attribute is used to mark a scenario step or a specific method after the scenario is completed.
[BeforeTestRun] and [AfterTestRun]:

The [BeforeTestRun] attribute is used to specify the method to run once before running all scenarios.
The [AfterTestRun] attribute is used to specify the method to be run once after all scenarios have been run.
[BeforeScenario] and [AfterScenario]:

The [BeforeScenario] attribute is used to mark a particular method before any scenario starts.
The [AfterScenario] attribute is used to mark a specific method after any scenario is completed.
[BeforeStep] and [AfterStep]:

The [BeforeStep] attribute is used to mark a specific method before any scenario step starts.
The [AfterStep] attribute is used to mark a specific method after any scenario step is completed.

TR:

[Before] ve [After]:

[Before] özniteliği, bir senaryo adımı veya senaryo başlamadan önce belirli bir metodu işaretlemek için kullanılır.
[After] özniteliği ise bir senaryo adımı veya senaryo tamamlandıktan sonra belirli bir metodu işaretlemek için kullanılır.
[BeforeTestRun] ve [AfterTestRun]:

[BeforeTestRun] özniteliği, tüm senaryoların çalıştırılmasından önce bir kez çalıştırılacak metodu belirtmek için kullanılır.
[AfterTestRun] özniteliği ise tüm senaryoların çalıştırılmasından sonra bir kez çalıştırılacak metodu belirtmek için kullanılır.
[BeforeScenario] ve [AfterScenario]:

[BeforeScenario] özniteliği, herhangi bir senaryo başlamadan önce belirli bir metodu işaretlemek için kullanılır.
[AfterScenario] özniteliği ise herhangi bir senaryo tamamlandıktan sonra belirli bir metodu işaretlemek için kullanılır.
[BeforeStep] ve [AfterStep]:

[BeforeStep] özniteliği, herhangi bir senaryo adımı başlamadan önce belirli bir metodu işaretlemek için kullanılır.
[AfterStep] özniteliği ise herhangi bir senaryo adımı tamamlandıktan sonra belirli bir metodu işaretlemek için kullanılır.


 */

#endregion

[Binding]
public class Hooks
{

    private IWebDriver _driver;
    private WebDriverWait _wait;

    [BeforeScenario]
    public void BeforeScenario()
    {
        WebDriverFactory.InitializeWebDriver();
        _driver = WebDriverFactory.GetDriver();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        WebDriverFactory.CloseWebDriver();
    }


    [Before]
    public void BeforeMethod()
    {
       
    }

    [After]
    public void AfterMethod()
    {
       
    }

    [BeforeTestRun]
    public void BeforeTestRun()
    {

    }

    [AfterTestRun]
    public void AfterTestRun()
    {
       
    }

    [BeforeStep]
    public void BeforeStep()
    {
       
    }

    [AfterStep]
    public void AfterStep()
    {
       
    }
}