﻿using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace QtpTests
{
    [TestClass]
    public class ValidUserCanSuccessfullyLogin
    {
        private static IWebDriver driver;
        [TestMethod]
        public void RunTest()
        {
            //here we create a new instance of the Chrome driver
            driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://www.qtptutorial.net/wp-login.php");

            //find the field for ther user name
            var user = driver.FindElement(By.Id("user_login"));
            user.SendKeys("gibbonz");

            //find the field for the password
            var pass = driver.FindElement(By.Id("user_pass"));
            pass.SendKeys("SeleniumUser5");

            driver.FindElement(By.Id("wp-submit")).Click();

            var loggedInHeader = driver.FindElement(By.ClassName("main_title"));

            if(loggedInHeader.Text != "My Membership")
            {
                Assert.IsTrue(false, "The user was not able to successfully login.");
            }
            
        }

        private static IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
