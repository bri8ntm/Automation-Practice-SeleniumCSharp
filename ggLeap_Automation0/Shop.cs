using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;


namespace ggLeap_Automation0
{
    class Shop
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

            driver.Url = ("https://ggleap:powerusers_2022@adminbeta.ggleap.com/");

        }

        [Test]
        public void UserCheckout()
        {
            driver.FindElement(By.Id("username")).SendKeys("ggbriant");
            driver.FindElement(By.Id("password")).SendKeys("asdfasdf");
            driver.FindElement(By.CssSelector("button[data-qaid='login-btn']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible
                (By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']")));
            IWebElement searchBar = driver.FindElement(By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']"));
            searchBar.Click();
            searchBar.SendKeys("br");
            searchBar.Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("span[class='k-button-icon k-icon k-i-material k-i-material-stats-button ng-star-inserted']")).Click(); // Statistics hide/reveal button - used to refresh the search query
            Thread.Sleep(2000);
            searchBar.Click();
            searchBar.SendKeys("briant.test1");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".gg-more button"))); // Clicking the user menu (ellipsis)
            IWebElement userSearchMenu = driver.FindElement(By.CssSelector(".gg-more button"));
            userSearchMenu.Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible
               (By.CssSelector(".k-widget.k-reset.k-header.k-menu.k-menu-vertical.k-context-menu li:nth-child(2)"))); // Click the 'Shop' or 2nd option
            IWebElement optionShop = driver.FindElement(By.CssSelector(".k-widget.k-reset.k-header.k-menu.k-menu-vertical.k-context-menu li:nth-child(2)"));
            optionShop.Click();
        }

        [Test]
        public void ShopNavigation()
        {
            driver.FindElement(By.Id("username")).SendKeys("ggbriant");
            driver.FindElement(By.Id("password")).SendKeys("asdfasdf");
            driver.FindElement(By.CssSelector("button[data-qaid='login-btn']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-qaid='menu-link-shop'][href='/shop']")));
            driver.FindElement(By.CssSelector("a[data-qaid='menu-link-shop'][href='/shop']")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector
            ("button[class='gg-button-primary gg-text-subtitle-2 k-button k-button-md k-rounded-md k-button-flat-base k-button-flat ng-star-inserted']")));
            driver.FindElement(By.CssSelector("button[class='gg-button-primary gg-text-subtitle-2 k-button k-button-md " +
                "k-rounded-md k-button-flat-base k-button-flat ng-star-inserted']")).Click(); // "Add user" button

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("glp-category[class='gg-button-tab category-tab gg-text-subtitle-2 ng-star-inserted k-active']")));
            //driver.FindElement(By.CssSelector("glp-category[class='gg-button-tab category-tab gg-text-subtitle-2 ng-star-inserted k-active']")).Click();

            //IWebElement searchInput = driver.FindElement(By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']"));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector
            //    ("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']"))); // Search user bar
            //Actions actions = new Actions(driver);
            //actions.MoveToElement(searchInput).Click().SendKeys("briant.test1").Build().Perform();

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector
            //    ("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']"))); // Search user bar
            //driver.FindElement(By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']")).SendKeys("briant.test1");
            //driver.FindElement(By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']")).Click();


            //driver.FindElement(By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']")).SendKeys("br");
            //driver.FindElement(By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']")).Click();

            //// "Create new user" button
            //driver.FindElement(By.CssSelector
            //    ("button[class='gg-button-outline gg-text-subtitle-2 k-button k-button-md k-rounded-md k-button-solid-base k-button-solid ng-star-inserted']")).Click();

            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".users-area-list")));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[data-qaid='kendo-search-panel-input'][type='search'][placeholder='Search user']")));
        }
    }
}

