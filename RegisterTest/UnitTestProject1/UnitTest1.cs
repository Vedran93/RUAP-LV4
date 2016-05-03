using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Ruaptest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new InternetExplorerDriver("C:\\Users\\Student\\Desktop");
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
        public void TheRuapTest()
        {
            // var i
            var rand = new Random();
            var i = rand.Next(1, 100000);
            var j = rand.Next(1, 100000);

            driver.Navigate().GoToUrl(baseURL + "/index.php?route=common/home");
            Assert.AreEqual("Your Store", driver.Title);
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            Assert.AreEqual("Register Account", driver.Title);
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("Vedran"+i);
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("Janjic"+j);
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("Vedran27"+i+"@hotmail.de");
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("00385977522424");
            driver.FindElement(By.Id("input-address-1")).Clear();
            driver.FindElement(By.Id("input-address-1")).SendKeys("Vukovarska 114");
            driver.FindElement(By.Id("input-city")).Clear();
            driver.FindElement(By.Id("input-city")).SendKeys("Osijek");
            driver.FindElement(By.Id("input-postcode")).Clear();
            driver.FindElement(By.Id("input-postcode")).SendKeys("31000");
            new SelectElement(driver.FindElement(By.Id("input-country"))).SelectByText("Croatia");
            Thread.Sleep(1000);
            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByText("Osječko-baranjska");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("obedari.123");
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("obedari.123");
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();
            Assert.AreEqual("Register Account", driver.Title);
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
