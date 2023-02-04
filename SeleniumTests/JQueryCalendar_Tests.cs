using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Practice1;

public class JQueryCalendar_Tests
{
    private static IWebDriver driver;
    public static By dateFrameLocator = By.TagName("iframe");
    public static WebDriverWait? wait;
    
    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        driver = new ChromeDriver("chromedriver.exe", options);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 
    }

    [Test]
    public void JQueryUI_ChooseDate_Success()
    {
        var addedDaysAmount = 8;
        driver.Navigate().GoToUrl("https://jqueryui.com/datepicker/");
        driver.SwitchTo().Frame(driver.FindElement(dateFrameLocator));
        var thisDatePlusAddedDays = DateTime.Today.AddDays(addedDaysAmount);
        (driver as IJavaScriptExecutor).ExecuteScript($"$('#datepicker').datepicker('setDate','{thisDatePlusAddedDays.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}')");
        var selectedDate =(driver as IJavaScriptExecutor).ExecuteScript("return $.datepicker.formatDate('yy-mm-dd', $('#datepicker').datepicker('getDate'))");
        Assert.AreEqual(thisDatePlusAddedDays.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), selectedDate, $"Выбранная дата не равна текущей дате + {addedDaysAmount} дней");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver = null;
    }
}