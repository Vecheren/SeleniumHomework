using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1.Pages;

public class DeliveryPage : PageBase
{
    public DeliveryPage(IWebDriver driver, WebDriverWait? wait) : base(driver, wait)
    {
    }

    public string Address { get; set; } = "проспект Ленина 50 Екатеринбург Свердловская область";

    public void SwitchToDeliveryTab() => driver.FindElement(deliveryTabLocator).Click();

    public bool IsVisibleAddressError() => driver.FindElement(addressWarningLocator).Displayed;
    public string GetAddressErrorText() => driver.FindElement(addressWarningLocator).Text;

    public void FillInAddress()
    {
        var addressInput = driver.FindElement(addressInputLocator);
        wait.Until(ExpectedConditions.ElementIsVisible(addressWarningLocator));
        addressInput.Clear();
        addressInput.SendKeys(Address + Keys.Enter);
    }

    public void ChooseDeliveryService()
    {
        wait.Until(ExpectedConditions.ElementIsVisible(deliveryServiceLocator));
        driver.FindElement(deliveryServiceLocator).Click();
    }

    public void ReturnToCard()
    {
        driver.FindElement(chooseDeliveryLocator).Click();
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(deliveryModalLocator));
    }

    private By deliveryTabLocator =
        By.XPath("//div[@class = 'div-select-text-left-header'][contains(text(), 'Курьер')]");

    private By addressInputLocator = By.Id("deliveryAddress");
    private By addressWarningLocator = By.CssSelector(".error-informer");
    private By deliveryServiceLocator = By.CssSelector(".cdp-container");
    private By chooseDeliveryLocator = By.CssSelector(".button-save");
    private By deliveryModalLocator = By.CssSelector(".container .modal-container");
}