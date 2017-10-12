using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium.Remote;

namespace UserInteractions
{
    [TestFixture, Parallelizable]
    public class InteractionsDemoParallell1
    {
        private Actions _actions;
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [Test]
        public void DragDropExample1()
        {
            _driver.Navigate().GoToUrl("http://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            _actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
            
        }

        [SetUp]
        public void Setup()
        {
            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            //service.FirefoxBinaryPath = @"C:\Users\James\Source\Repos\SeleniumCSharp\packages\WebDriver.GeckoDriver.0.19.0\content\geckodriver.exe";
            //_driver = new FirefoxDriver(service);

            _driver = new ChromeDriver();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [TearDown]
        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
    [TestFixture, Parallelizable]
    public class InteractionsDemoParallell2
    {
        // should make a base class with these... aint DRY
        private Actions _actions;
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [Test]
        public void DragDropExample2()
        {
            _driver.Navigate().GoToUrl("http://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));

            var drag = _actions
                .ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release(targetElement)
                .Build();

            drag.Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
        }

        [SetUp]
        public void Setup()
        {
            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            //service.FirefoxBinaryPath = @"C:\Users\James\Source\Repos\SeleniumCSharp\packages\WebDriver.GeckoDriver.0.19.0\content\geckodriver.exe";
            //_driver = new FirefoxDriver(service);

            _driver = new ChromeDriver();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [TearDown]
        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
