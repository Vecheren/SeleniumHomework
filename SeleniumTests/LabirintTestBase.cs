using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1;

public abstract class LabirintTestBase
{
    protected static IWebDriver driver;
    protected static WebDriverWait? wait;
    
    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--incognito");
        driver = new ChromeDriver("chromedriver.exe", options);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 
    }
    
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver = null;
    }
}