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
using OpenQA.Selenium.Remote;

namespace UserInteractions
{
    [TestFixture]
    public class InteractionsDemo
    {
        private Actions _actions;
        private FirefoxDriver _driver;
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
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

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

        [Test]
        public void jQueryDragDropQuiz()
        {
            _driver.Navigate().GoToUrl("http://www.pureexample.com/jquery-ui/basic-droppable.html");

            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ExampleFrame-94")));

            //var sourceLocator = _driver.FindElement(By.ClassName("square ui-draggable"));
            var sourceLocator = _driver.FindElement(By.XPath("//*[@class='square ui-draggable']"));
            var destinationLocator = _driver.FindElement(By.XPath("//*[contains(text(),'Drop here')]"));

            _actions.DragAndDrop(sourceLocator, destinationLocator).Perform();

            var droppedText = _driver.FindElement(By.Id("info")).Text;

            Assert.AreEqual("dropped!", droppedText);
        }


        [Test]
        public void ResizingExample()
        {
            _driver.Navigate().GoToUrl("http://jqueryui.com/resizable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement resizeHandle = _driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));

            _actions.ClickAndHold(resizeHandle).MoveByOffset(100, 100).Perform();

            Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id='resizable' and @style]")).Displayed);
        }

        [Test]
        public void OpenNetworkTabUsingFirefox()
        {
            _driver.Navigate().GoToUrl("http://www.google.com");
            _actions.KeyDown(Keys.Control).KeyDown(Keys.Shift).SendKeys("q").Perform();

            _actions.KeyUp(Keys.Control).KeyUp(Keys.Shift).Perform();
            _driver.Navigate().GoToUrl("http://www.pureexample.com/jquery-ui/basic-droppable.html");
        }

        //Not supported by Selenium Webdriver - http://stackoverflow.com/questions/29381233/how-to-simulate-html5-drag-and-drop-in-selenium-webdriver
        //https://github.com/seleniumhq/selenium-google-code-issue-archive/issues/6315
        [Test]
        public void DragDropHtml5_Quiz()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/drag_and_drop");
            var source = _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("column-a")));

            var jsFile = File.ReadAllText(@"C:\Source\Github\UserInteractionsTutorial\drag_and_drop_helper.js");
            IJavaScriptExecutor js = _driver as IJavaScriptExecutor;
            //Execute java script - #{{id value}}
            js.ExecuteScript(jsFile + "$('#column-a').simulateDragDrop({ dropTarget: '#column-b'});");

            Assert.AreEqual("B", _driver.FindElement(By.XPath("//*[@id='column-b']/header")).Text);
        }

        [Test]
        public void DrawQuiz()
        {

            _driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/gui_user_interactions.html");


            
            _driver.Manage().Window.Maximize();
            //bring the page into focus to reduce intermittency
            //_driver.FindElement(By.TagName("html")).Click();

            IWebElement canvas = _driver.FindElement(By.Id("canvas"));
//            Debug.WriteLine($"canvas x:{canvas.Location.X}");
//            Debug.WriteLine($"canvas y:{canvas.Location.Y}");

            var eventList = _driver.FindElement(By.Id("keyeventslist"));

            var li = eventList.FindElements(By.TagName("li"));
            var eventCount = li.Count;

            double x = 0;
            double y = 0;
            int xInt = 0, yInt = 0, y2, x2;


            const double a = 100;
            const double b = 0.005347;



            for (double i = 0; i < 100; i++)
            {
                //   Random rnd = new Random(i);
                //   var rnd2 = new Random(i + 3);

                //   var x = rnd2.Next(1, 100);
                //   var y = rnd.Next(1, 100);
                x2 = xInt;
                y2 = yInt;
                x = a * Math.Cos(i * 180) * Math.Exp(b * i);
                y = a * Math.Sin(i * 180) * Math.Exp(b * i);
                //x3 = x2 - x;
                //x2 = x;
                //x = i;




                Debug.WriteLine($"x:{x}");
                Debug.WriteLine($"y:{y}");

                xInt = Convert.ToInt32(x);
                yInt = (int)y;


                //Debug.WriteLine($"rnd2:{canvas.Location.Y - y}");
                _actions.DragAndDropToOffset(canvas, x2 + xInt, y2 + yInt)
                    .Perform();
                //var dragndrop = _actions
                //    .ClickAndHold(canvas)
                //    .MoveByOffset(canvas.Location.X - x, canvas.Location.Y - y)
                //    .Release()

                //    .Build();

                //dragndrop.Perform();

            }

            Assert.IsTrue(eventCount < eventList.FindElements(By.TagName("li")).Count);

        }

        [SetUp]
        public void Setup()
        {
            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            //service.FirefoxBinaryPath = @"C:\Users\James\Source\Repos\SeleniumCSharp\packages\WebDriver.GeckoDriver.0.19.0\content\geckodriver.exe";
            //_driver = new FirefoxDriver(service);
            
            _driver = new FirefoxDriver();
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