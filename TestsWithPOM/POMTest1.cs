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
using Framework.Pages;
using OpenQA.Selenium.Remote;

namespace TestsWithPOM
{
    [TestFixture]
    public class PomTest1 : TestBase
    {
        [Test]
        public void TestMethod1()
        {
            //Pages.
            Pages.Login.Goto();
        }

    }
}
