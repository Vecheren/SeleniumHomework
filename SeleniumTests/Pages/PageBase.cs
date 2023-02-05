using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1.Pages;

public abstract class PageBase
{
    protected IWebDriver driver;
    protected WebDriverWait? wait;
    
    public PageBase(IWebDriver _driver, WebDriverWait? _wait)
    {
        driver = _driver;
        wait = _wait;
    }
}