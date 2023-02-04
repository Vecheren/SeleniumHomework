using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1;

public abstract class LabirintTestBase
{
    public static IWebDriver driver;
    public static WebDriverWait? wait;
    
    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--incognito");
        driver = new ChromeDriver("chromedriver.exe", options);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // неявное
    }
    
    
    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver = null;
    }
}