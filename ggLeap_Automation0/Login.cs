using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace ggLeap_Automation0
{
    class Login
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Url = ("https://admin.ggleap.com");
        }

        //[Test]
        //public void PowerusersLogin()
        //{
        //    String text0 = "Username";
        //    String puLoginPopup = driver.SwitchTo().Alert().Text;
        //    driver.SwitchTo().Alert().SendKeys("ggleap");
        //    driver.SwitchTo().Alert().SendKeys("powerusers2022");
        //    driver.SwitchTo().Alert().Accept(); // use Dismiss() method to cancel

        //    StringAssert.Contains(text0, puLoginPopup);
        //}

        [Test]
        public void SuccessLogin()
        {
            driver.FindElement(By.Id("username")).SendKeys("ggbriant");
            driver.FindElement(By.Id("password")).SendKeys("asdfasdf");
            driver.FindElement(By.CssSelector("button[data-qaid='login-btn']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
        }
    }
}

