using NUnit.Framework;
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
            options.AddAdditionalCapability(MobileCapabilityType.App, "<linkTo.apk>");
            driver = new AndroidDriver<AndroidElement>(new Uri(appiumUri), options);
        }

        [Test]
        public void Login()
        {
            //Find element username
            //Find element password
            //Find element login button
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
