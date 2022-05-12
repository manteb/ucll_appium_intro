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
            driver.FindElementById("usernameTextField"); //TODO fill in username
            driver.FindElementById("passwordTextField"); //TODO fill in password
            driver.FindElementById("loginButton"); //TODO click the button
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
