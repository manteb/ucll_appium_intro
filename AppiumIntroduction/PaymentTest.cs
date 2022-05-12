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
            options.AddAdditionalCapability(MobileCapabilityType.App, "pathToApk");
            driver = new AndroidDriver<AndroidElement>(new Uri(appiumUri), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void MakePayment()
        {
            //TODO Login
            //TODO Get the balance
            //TODO Click Make payment
            //TODO Fill in phone, name, amount
            //TODO select country (no swipe-needed yet, take one of the first in the list)
            //TODO Click Send payment
            //TODO Click Yes
            //TODO Get the new balance
            //TODO verify that newBalance == balanceBefore - paymentAmount
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
