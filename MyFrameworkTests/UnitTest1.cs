using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyFrameworkTests
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver Driver { get; set; }

        protected HomePage ShiresHomePage;


        [TestInitialize]
        public void SetUp()
        {
            Driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //ShiresHomePage.Goto();
            ShiresHomePage = new HomePage(Driver);
            Thread.Sleep(1000);
            ShiresHomePage.ClickPortfolioButton();
            Thread.Sleep(4000);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
