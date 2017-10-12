using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        protected BasePage(IWebDriver webDriver, By knownElementOnPage, string loadUrl = "")
        {
            this.driver = webDriver;
            if (loadUrl != String.Empty)
            {
                driver.Navigate().GoToUrl(loadUrl);
            }
            this.FindKnownElementOnPage(knownElementOnPage);
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


        private void FindKnownElementOnPage(By keop)
        {
            // presumably this throws an exception if it can't find the element.. ?
            this.Driver.FindElement(keop);
        }

    }
}
