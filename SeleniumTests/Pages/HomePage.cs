using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1.Pages;

public class HomePage : PageBase
{
    private By acceptCookiesLocator = By.CssSelector(".js-cookie-policy-agree");
    private By booksSelectorLocator = By.CssSelector(".b-header-b-menu-e-text[href = '/books/']");
    private By allBooksLinkLocator = By.CssSelector(".b-toggle-container [href = '/books/']");
    private By addToCartLocator = By.XPath("(//*[@data-idtov])[1]");
    private By goToCartLocator = By.CssSelector(".btn-more[href = '/cart/']");
    private By goToPaymentLocator = By.CssSelector("#cart-total-default button");

    public HomePage(IWebDriver driver, WebDriverWait? wait) : base(driver, wait){}
    
    public void AddBlockToCard()
    {
        driver.FindElement(addToCartLocator).Click();
        driver.FindElement(goToCartLocator).Click();
        wait.Until(ExpectedConditions.ElementIsVisible(goToPaymentLocator));
        driver.FindElement(goToPaymentLocator).Click();
    }

    public void OpenPage()
    {
        driver.Navigate().GoToUrl("https://www.labirint.ru/");
        driver.FindElement(acceptCookiesLocator).Click();
        new Actions(driver)
            .MoveToElement(driver.FindElement(booksSelectorLocator))
            .Build()
            .Perform();
        // wait.Until(ExpectedConditions.ElementIsVisible(allBooksLinkLocator));
        driver.FindElement(allBooksLinkLocator).Click();
    }
}