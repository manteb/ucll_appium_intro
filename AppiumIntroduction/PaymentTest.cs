using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Drawing;
using System.Diagnostics;

namespace AppiumTraining
{
    public class PaymentTest
    {
        private const string appiumUri = "http://0.0.0.0:4723/wd/hub";
        private AndroidDriver<AndroidElement> driver;

        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions();
            options.PlatformName = "Android";
            options.AddAdditionalCapability(MobileCapabilityType.App, "PathToAPK");
            driver = new AndroidDriver<AndroidElement>(new Uri(appiumUri), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void MakePayment()
        {
            var amount = 10;
            Login();
            var initialBalance = GetBalance();
            driver.FindElementById("makePaymentButton").Click();

            driver.FindElementById("phoneTextField").SendKeys("0499112233");
            driver.FindElementById("nameTextField").SendKeys("Tobania");
            driver.FindElementById("amountTextField").SendKeys(amount.ToString());
            driver.FindElementById("countryButton").Click();


            //TODO search for a country on the bottom of the list -> Swipe needed
            var countries = driver.FindElementsByClassName("android.widget.TextView");
            foreach (var country in countries)
            {
                if (country.Text.Equals("India"))
                {
                    country.Click();
                    break;
                }
            }


            driver.FindElementById("sendPaymentButton").Click();
            driver.FindElementById("android:id/button1").Click();

            var currentBalance = GetBalance();
            Assert.AreEqual(initialBalance - amount, currentBalance);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        private float GetBalance()
        {
            var balance_txt = driver.FindElementByClassName("android.view.View").Text;
            var startIndex = balance_txt.IndexOf(":") + 2;
            var endIndex = balance_txt.IndexOf("$") - 1;
            String balance = balance_txt.Substring(startIndex, endIndex - startIndex + 1);
            return float.Parse(balance);
        }

        private void Login()
        {
            driver.FindElementById("usernameTextField").SendKeys("company");
            driver.FindElementById("passwordTextField").SendKeys("company");
            driver.FindElementById("loginButton").Click();
        }

        private bool ElementExists(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
    }
}
