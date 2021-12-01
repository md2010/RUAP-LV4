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
    public class AddToChartRequiringFillingAForm
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
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
        public void TheAddToChartRequiringFillingAFormTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.LinkText("Components")).Click();
            driver.FindElement(By.LinkText("Monitors (2)")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div[3]/div/div/div[2]/div[2]/button/span")).Click();
            driver.FindElement(By.XPath("//div[@id='product']/div")).Click();
            driver.FindElement(By.XPath("//div[@id='input-option223']/div/label")).Click();
            driver.FindElement(By.Id("input-option208")).Click();
            driver.FindElement(By.Id("input-option208")).Clear();
            driver.FindElement(By.Id("input-option208")).SendKeys("testggg");
            driver.FindElement(By.Id("input-option217")).Click();
            new SelectElement(driver.FindElement(By.Id("input-option217"))).SelectByText("Blue (+3.10€)");
            driver.FindElement(By.Id("input-option209")).Click();
            driver.FindElement(By.Id("input-option209")).Clear();
            driver.FindElement(By.Id("input-option209")).SendKeys("dfd");
            driver.FindElement(By.Id("button-upload222")).Click();
            driver.FindElement(By.Name("file")).Clear();
            driver.FindElement(By.Name("file")).SendKeys("C:\\fakepath\\ruap-lv3.txt");
            driver.FindElement(By.Id("input-option219")).Click();
            driver.FindElement(By.XPath("//div[@id='product']/div[7]/div/span/button")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Su'])[1]/following::td[2]")).Click();
            driver.FindElement(By.XPath("//div[@id='product']/div[8]/div/span/button/i")).Click();
            driver.FindElement(By.XPath("//div[6]/div/div/table/tbody/tr/td[3]/a/span")).Click();
            driver.FindElement(By.XPath("//div[6]/div/div/table/tbody/tr/td[3]/a/span")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=//div[6]/div/div/table/tbody/tr/td[3]/a/span | ]]
            driver.FindElement(By.Id("input-option221")).Click();
            driver.FindElement(By.XPath("//div[@id='product']/div[9]/div/span/button")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Su'])[2]/following::td[17]")).Click();
            driver.FindElement(By.Id("input-quantity")).Click();
            driver.FindElement(By.Id("button-cart")).Click();
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
