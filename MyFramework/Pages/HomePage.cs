﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace MyFramework.Pages
{
    public class HomePage : BasePage
    {
        // element selector declaration. any instance variables
        private static readonly string Title = "Terri Shires";
        private static readonly string Uri = "http://wwww.tshires.co.uk";

        private static readonly By PortfolioButtonSelector = By.XPath("//h5/a[@href='http://www.tshires.co.uk/portfolio/']");
        private static readonly By BlogButtonSelector = By.XPath("//a[@href='http://www.tshires.co.uk/blog/']");
        private static readonly By ContactButtonSelector = By.XPath("//a[@href='http://www.tshires.co.uk/contact/']");

        // constructor
        // when instantiating this pages you only pass through the driver object.
        // the private variables declared above are then passed through into the base constructor
        // to establish the page.

        public HomePage(IWebDriver driver) : base(driver, PortfolioButtonSelector, Title, Uri)
        {
        }

        //now we declare the attributes. just getters, for the elements on the page.
        // They return the element... for manipulation and such.

        private IWebElement PortfolioButtonElement
        {
            get { return Driver.FindElement(PortfolioButtonSelector); }
        }

        private IWebElement BlogButtonElement
        {
            get { return Driver.FindElement(BlogButtonSelector); }
        }

        private IWebElement ContactButtonElement
        {
            get { return Driver.FindElement(ContactButtonSelector); }
        }

        // And now we can declare our methods.
        
            // This one returns a new page object, because it navigates.
        public PortfolioPage ClickPortfolioButton()
        {
            PortfolioButtonElement.Click();
            //Cactus.Drivers.Support.GenerateXpathFromElement(PortfolioButtonElement);
            return new PortfolioPage(Driver);
            
        }

        // another one may just be a void, and do an action then assert.


        public void Goto()
        {
            Driver.Navigate().GoToUrl(Uri);
        }
    }
}
