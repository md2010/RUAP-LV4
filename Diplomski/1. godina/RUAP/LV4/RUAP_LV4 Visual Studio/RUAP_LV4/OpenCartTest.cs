using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace RUAP_LV4
{
    [TestFixture]
    public class OpenCartTest

    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            driver.Manage().Window.Maximize();
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
        public void TheLogInAndSortTest()
        {           
            driver.Navigate().GoToUrl("https://demo.opencart.com/");          
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();          
            //driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.XPath("//input[@id='input-email']")).SendKeys("sim123@yahoo.com");
            driver.FindElement(By.XPath("//div[@id='content']/div")).Click();
            //driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("Simon1!");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();           
            driver.FindElement(By.LinkText("Show All Laptops & Notebooks")).Click();       
            driver.FindElement(By.Id("input-sort")).Click();
            new SelectElement(driver.FindElement(By.Id("input-sort"))).SelectByText("Name (A - Z)");
        }

        [Test]
        public void TheRegisterUserTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("input-firstname")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("simon");
            driver.FindElement(By.Id("input-lastname")).Click();
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("sims");
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("sim12345@yahoo.com");
            driver.FindElement(By.Id("input-telephone")).Click();
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("+338548596");
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("Simon1!");
            driver.FindElement(By.Id("input-confirm")).Click();
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("Simon1!");
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();
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

        [Test]
        public void TheLogInAddToChartAndEstimateShippingTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("mabelle.stoltenberg@example.org");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("smajlici");
            driver.FindElement(By.XPath("//div[@id='content']/div")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("sim123@yahoo.com");
            driver.FindElement(By.XPath("//div[@id='content']/div")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("Simon1!");
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.LinkText("Mac (1)")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div[2]/div/div/div[2]/div[2]/button/span")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[5]/a/i")).Click();
            driver.FindElement(By.LinkText("Estimate Shipping & Taxes")).Click();
            driver.FindElement(By.Id("input-country")).Click();
            new SelectElement(driver.FindElement(By.Id("input-country"))).SelectByText("Swaziland");
            driver.FindElement(By.Id("input-zone")).Click();
            new SelectElement(driver.FindElement(By.Id("input-zone"))).SelectByText("Hhohho");
            driver.FindElement(By.Id("button-quote")).Click();
            driver.FindElement(By.XPath("//div[@id='modal-shipping']/div/div/div[2]/div/label")).Click();
            driver.FindElement(By.Id("button-shipping")).Click();
        }

        [Test]
        public void TheAddToChartForGuestsTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.LinkText("Components")).Click();
            driver.FindElement(By.LinkText("Monitors (2)")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div[3]/div[2]/div/div[2]/div[2]/button/span")).Click();
            driver.FindElement(By.XPath("//*[@id='cart']/button")).Click();
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

