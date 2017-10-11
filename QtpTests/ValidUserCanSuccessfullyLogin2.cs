using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace QtpTests
{
    [TestClass]
    public class ValidUserCanSuccessfullyLogin2
    {
        static IWebDriver driver = GetChromeDriver();

        [TestMethod]
        public void RunTest()
        {
            //here we create a new instance of the Chrome driver
            GoTo();

            //find the field for ther user name
            SendKeys("user_login", "gibbonz");

            //find the field for the password
            SendKeys("user_pass", "SeleniumUser5");
            ClickButton("wp-submit");

            var loggedInHeader = driver.FindElement(By.ClassName("main_title"));
            Assert.IsTrue(loggedInHeader.Displayed, "The user was not able to successfully login.");
        }

        public void SendKeys(string id, string value)
        {
            var user = driver.FindElement(By.Id(id));
            user.SendKeys(value);
        }

        public void ClickButton(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.qtptutorial.net/wp-login.php");

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
