using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1.Pages;

public class DeliveryPage : PageBase
{
    private By deliveryTabLocator =
        By.XPath("//div[@class = 'div-select-text-left-header'][contains(text(), 'Курьер')]");

    private By addressInputLocator = By.Id("deliveryAddress");
    private By addressWarningLocator = By.CssSelector(".error-informer");
    private By deliveryServiceLocator = By.CssSelector(".cdp-container");
    private By chooseDeliveryLocator = By.CssSelector(".button-save");
    private By deliveryModalLocator = By.CssSelector(".container .modal-container");
    private string invalidAddress = "невалидный адрес какой-то";
    private string validAddress = "проспект Ленина 50 Екатеринбург Свердловская область";

    public DeliveryPage(IWebDriver driver, WebDriverWait? wait) : base(driver, wait){}
    
    public void SwitchToDeliveryTab()
    {
        driver.FindElement(deliveryTabLocator).Click();
    }

    public bool IsVisibleAddressError() => driver.FindElement(addressWarningLocator).Displayed;

    public void FillInAddress(bool addressIsValid)
    {
        var address = (addressIsValid) ? validAddress : invalidAddress;
        var addressInput = driver.FindElement(addressInputLocator);
        wait.Until(ExpectedConditions.ElementIsVisible(addressWarningLocator));
        addressInput.Clear();
        addressInput.SendKeys(address + Keys.Enter);
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
}