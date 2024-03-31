using CustomerManagement.BDD.Tests.Utils;
using TechTalk.SpecFlow;

namespace CustomerManagement.BDD.Tests.Hooks;

[Binding]
public class Hooks
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        // Senaryo başlamadan önce yapılacak işlemleri burada tanımlayabilirsiniz
        // Örneğin, WebDriver'ı başlatma
        WebDriverFactory.InitializeWebDriver();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        // Senaryo tamamlandıktan sonra yapılacak işlemleri burada tanımlayabilirsiniz
        // Örneğin, WebDriver'ı kapatma
        WebDriverFactory.CloseWebDriver();
    }
}