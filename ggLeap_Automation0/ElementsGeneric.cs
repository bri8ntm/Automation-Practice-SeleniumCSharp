using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace ggLeap_Automation0
{
    class ElementsGeneric
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
        public void RadioButtonTest()
        {
            driver.FindElement(By.Id("username")).SendKeys("ggbriant");
            driver.FindElement(By.Id("password")).SendKeys("asdfasdf");
            driver.FindElement(By.CssSelector("button[data-qaid='login-btn']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-qaid='menu-link-settings']")));
            driver.FindElement(By.CssSelector("a[data-qaid='menu-link-settings']")).Click(); // Settings tab

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector
                ("a[data-qaid='settings-menu-link-client-config'][href='/settings/client']"))); // Client config
            driver.FindElement(By.CssSelector("a[data-qaid='settings-menu-link-client-config'][href='/settings/client']")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector
                ("a[data-qaid='settings-menu-link-client-config'][href='/settings/client/general']")));
            //driver.FindElement(By.CssSelector("a[data-qaid='settings-menu-link-client-config'][href='/settings/client/general']")).Click();

            Actions actions = new Actions(driver);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-qaid='menu-link-orders']")));
            actions.MoveToElement(driver.FindElement(By.CssSelector("a[data-qaid='menu-link-orders']"))).Perform();

            IList<IWebElement> rbGdpr = driver.FindElements(By.CssSelector("input[type='radio'][formcontrolname='gdprAgeLevel']")); // GDPR radio buttons
            //driver.FindElement(By.CssSelector("div[class='gg-content__main-page-header ng-tns-c801-2']")).Click();
            //driver.FindElement(By.Id("level-13")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='radio'][formcontrolname='gdprAgeLevel']")));
            rbGdpr[0].Click();

            //// Save changes button
            //driver.FindElement(By.CssSelector
            //    ("button[class='gg-button-primary gg-text-subtitle-2 k-button k-disabled k-button-md k-rounded-md k-button-solid-primary k-button-solid']")).Click();
        }
    }
}
