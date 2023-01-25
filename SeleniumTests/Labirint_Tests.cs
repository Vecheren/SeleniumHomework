using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Practice1
{
    [TestFixture]
    public class Labirint_Tests
    {
        private static IWebDriver driver;
        public static By acceptCookiesLocator = By.CssSelector(".js-cookie-policy-agree");
        public static By booksSelectorLocator = By.XPath("//*[@href = '/books/'][text() = 'Книги']");
        public static By allBooksLinkLocator = By.XPath("//*[@href = '/books/'][text() = 'Все книги']");
        public static By addToCartLocator = By.XPath("(//*[@data-idtov])[1]");
        public static By goToCartLocator = By.CssSelector(".btn-more[href = '/cart/']");
        public static By goToPaymentLocator = By.CssSelector("#cart-total-default button");
        public static By chooseNewPlaceLocator = By.CssSelector(".delivery__profiles-change-btn");
        public static By deliveryTabLocator = By.XPath("//div[@class = 'div-select-text-left-header'][contains(text(), 'Курьер')]");
        public static By addressInputLocator = By.Id("deliveryAddress");
        public static By addressWarningLocator = By.CssSelector(".error-informer");
        public static By deliveryServiceLocator = By.CssSelector(".cdp-container");
        public static By chooseDeliveryLocator = By.CssSelector(".button-save");
        public static By deliveryModalLocator = By.CssSelector(".container");
        
        public static WebDriverWait? wait;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver("chromedriver.exe", options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // неявное
        }
        
        [Test]
        public void Labirint_AddBookAndChooseDeliveryService_Success()
        {
            driver.Navigate().GoToUrl("https://www.labirint.ru/");
            driver.FindElement(acceptCookiesLocator).Click();
            new Actions(driver)
                .MoveToElement(driver.FindElement(booksSelectorLocator))
                .Build()
                .Perform();
            wait.Until((e) => e.FindElement(allBooksLinkLocator)).Click();
            driver.FindElement(addToCartLocator).Click();
            driver.FindElement(goToCartLocator).Click();
            driver.FindElement(goToPaymentLocator).Click();
            driver.FindElement(chooseNewPlaceLocator).Click();
            driver.FindElement(deliveryTabLocator).Click();
            driver.FindElement(addressInputLocator)
                .SendKeys("невалидный адрес какой-то" + Keys.Enter);
            Assert.That(driver.FindElement(addressWarningLocator).Displayed,
                "Не отобразилось предупреждение об ошибочном адресе");
            driver.FindElement(addressInputLocator).Clear();
            driver.FindElement(addressInputLocator).SendKeys("проспект Ленина, 49, Екатеринбург" + Keys.Enter);
            driver.FindElement(deliveryServiceLocator).Click();
            driver.FindElement(chooseDeliveryLocator).Click();
            wait.Until((e) => !e.FindElement(deliveryModalLocator).Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
    }
}