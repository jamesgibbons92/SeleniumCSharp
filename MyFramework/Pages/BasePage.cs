using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyFramework.Pages
{
    public class BasePage
    {
        //declare the iwebdriver
        private IWebDriver _driver;


        //constructor. 
        //take the webdriver element, takes a known element on the page you are constructing
        //and uses it to check if you are on the correct page.
        //navigates to the URl if not empty.
        //protected BasePage(IWebDriver webDriver, By knownElementOnPage, string loadUrl="")
        // use title if there is no easily identifable element to identify the page.
        protected BasePage(IWebDriver webDriver, By knownElementOnPage, string title, string loadUrl="")
        {
            _driver = webDriver;
            if (loadUrl != String.Empty)
            {
                _driver.Navigate().GoToUrl(loadUrl);
            }
            //this.FindKnownElementOnPage(knownElementOnPage);
            Assert.IsTrue(IsAt(title), $"Looks like we are on an incorrect page to what we expected... Expected title: '{title}', got '{Title}'");
        }

        public string Title => _driver.Title;

        public IWebDriver Driver
        {
            get => _driver;
            set => _driver = value;
        }

        // Use IsAt() or FindKnownElement depending on what you have to work with.

        private bool IsAt(string title) => Driver.Title.Contains(title);


        private void FindKnownElementOnPage(By keop)
        {
            // presumably this throws an exception if it can't find the element.. ?
            Driver.FindElement(keop);
        }

    }
}
