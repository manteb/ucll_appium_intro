﻿using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace AppiumTraining
{
    public class LoginTest
    {
        private const string appiumUri = "http://0.0.0.0:4723/wd/hub";
        private AndroidDriver<AndroidElement> driver;

        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions();
            options.PlatformName = "Android";
            options.AddAdditionalCapability(MobileCapabilityType.App, "/Users/mante.bos/Documents/ExperiBank.apk");
            driver = new AndroidDriver<AndroidElement>(new Uri(appiumUri), options);
        }

        [Test]
        public void Login()
        {
            driver.FindElementById("usernameTextField").SendKeys("company");
            driver.FindElementById("passwordTextField").SendKeys("company");
            driver.FindElementById("loginButton").Click();

            Assert.IsTrue(ElementExists(By.Id("logoutButton")));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
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
