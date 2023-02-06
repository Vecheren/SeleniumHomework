using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1.Pages;

public abstract class PageBase
{
    public PageBase(IWebDriver driver, WebDriverWait? wait)
    {
        this.driver = driver;
        this.wait = wait;
    }
    
    protected IWebDriver driver;
    protected WebDriverWait? wait;
}