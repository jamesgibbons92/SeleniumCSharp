using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;


namespace MyFramework.Pages
{
    public class BasePage
    {
        //declare the iwebdriver
        private IWebDriver driver;


        //constructor. 
        //take the webdriver element, takes a known element on the page you are constructing
        //and uses it to check if you are on the correct page.
        //navigates to the URl if not empty.
        //protected BasePage(IWebDriver webDriver, By knownElementOnPage, string loadUrl="")
        // use title if there is no easily identifable element to identify the page.
        protected BasePage(IWebDriver webDriver, By knownElementOnPage, string title, string loadUrl="")
        {
            this.driver = webDriver;
            if (loadUrl != String.Empty)
            {
                driver.Navigate().GoToUrl(loadUrl);
            }
            //this.FindKnownElementOnPage(knownElementOnPage);
            Assert.IsTrue(IsAt(title), $"Looks like we are on an incorrect page to what we expected... Expected title: '{title}', got '{this.Title}'");
        }

        public string Title
        {
            get { return driver.Title; }
        }

        public IWebDriver Driver
        {
            get { return this.driver; }
            set { this.driver = value; }
        }

        // Use IsAt() or FindKnownElement depending on what you have to work with.

        private bool IsAt(string title)
        {
            // check for title.
            // using the driver object.
            return Driver.Title.Contains(title);
        }


        private void FindKnownElementOnPage(By keop)
        {
            // presumably this throws an exception if it can't find the element.. ?
            this.Driver.FindElement(keop);
        }

    }
}
