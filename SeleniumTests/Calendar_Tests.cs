using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Practice1
{
    [TestFixture]
    public class Calendar_Tests
    {
        private static IWebDriver driver;
        public static By dateFrameLocator = By.TagName("iframe");
        public static By datePickerLocator = By.CssSelector("input#datepicker");
        public static By nextMonthLocator = By.ClassName("ui-datepicker-next");
        public static By calendarLocator = By.Id("ui-datepicker-div");
        public static By thisDayInCalendarLocator = By.ClassName("ui-state-highlight");
        public static By choosenDayLocator = By.ClassName("ui-state-active");
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
            driver.Navigate().GoToUrl("https://jqueryui.com/datepicker/");
            driver.SwitchTo().Frame(driver.FindElement(dateFrameLocator));
            driver.FindElement(datePickerLocator).Click();
            wait.Until((e) => e.FindElement(calendarLocator));
            var thisDayInCalendar = driver.FindElement(thisDayInCalendarLocator);
            Assert.That(int.Parse(thisDayInCalendar.GetAttribute("data-date")) == DateTime.Today.Day);
            var futureDay = (DateTime.Today + TimeSpan.FromDays(8)).Day;
            if (futureDay < DateTime.Today.Day)
            {
                driver.FindElement(nextMonthLocator).Click();
            }

            var futureDayLocator = By.CssSelector($"[data-date = '{futureDay}']");
            driver.FindElement(futureDayLocator).Click();
            driver.FindElement(datePickerLocator).Click();
            var choosenDays = driver.FindElements(choosenDayLocator);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(1, choosenDays.Count, "Не выбран ни один день");
                Assert.AreEqual($"{futureDay}", choosenDays[0].GetAttribute("data-date"), "Выбран неправильный день");
            });
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}