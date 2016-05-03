using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Testruap2
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demo.opencart.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheRuap2Test()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php?route=common/home");
            Assert.AreEqual("Your Store", driver.Title);
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            Assert.AreEqual("Account Login", driver.Title);
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("Vedran27@hotmail.de");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("obedari.123");
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.AreEqual("My Account", driver.Title);
            driver.FindElement(By.LinkText("Modify your wish list")).Click();
            Assert.AreEqual("My Wish List", driver.Title);
            driver.FindElement(By.LinkText("Wish List")).Click();
            Assert.AreEqual("My Wish List", driver.Title);
            driver.FindElement(By.LinkText("Tablets")).Click();
            Assert.AreEqual("", driver.Title);
            driver.FindElement(By.XPath("(//button[@type='button'])[10]")).Click();
            driver.FindElement(By.CssSelector("i.fa.fa-home")).Click();
            Assert.AreEqual("Your Store", driver.Title);
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.CssSelector("ul.dropdown-menu.dropdown-menu-right > li > a")).Click();
            Assert.AreEqual("My Account", driver.Title);
            driver.FindElement(By.LinkText("Wish List")).Click();
            Assert.AreEqual("My Wish List", driver.Title);
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            Assert.AreEqual("Account Logout", driver.Title);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
