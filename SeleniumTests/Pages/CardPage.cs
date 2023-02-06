using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1.Pages;

public class CardPage : PageBase
{
    public CardPage(IWebDriver driver, WebDriverWait? wait) : base(driver, wait)
    {
    }

    public void OpenPage()
    {
        driver.FindElement(chooseNewPlaceLocator).Click();
    }

    private By chooseNewPlaceLocator = By.CssSelector(".delivery__profiles-change-btn");
}