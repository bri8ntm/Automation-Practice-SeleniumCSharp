using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ggLeap_Shop

{
    class Shop
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

            driver.Url = ("https://admin.ggleap.com");
        }

        [Test]
        public void ShopNavigation()
        {
            driver.FindElement(By.Id("username")).SendKeys("ggbriant");
            driver.FindElement(By.Id("password")).SendKeys("asdfasdf");
            driver.FindElement(By.CssSelector("button[data-qaid='login-btn']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-qaid='menu-link-shop'][href='/shop']")));
            driver.FindElement(By.CssSelector("a[data-qaid='menu-link-shop'][href='/shop']")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector
            ("button[class='gg-button-primary gg-text-subtitle-2 k-button k-button-md k-rounded-md k-button-flat-base k-button-flat ng-star-inserted']")));
            driver.FindElement(By.CssSelector("button[class='gg-button-primary gg-text-subtitle-2 k-button k-button-md " +
                "k-rounded-md k-button-flat-base k-button-flat ng-star-inserted']")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector
                ("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']")));

            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']")));
        }
    }
}

