using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace MyFramework.Pages
{
    public class PortfolioPage : BasePage
    {
        // element selector declaration. any instance variables

        private static readonly string _title = "Portfolio – Terri Shires";
        private static readonly By TitleSelector = By.XPath("//h3[contains(text(), 'Portfolio')]");
        // used to check page...

        
        // constructor
        // when instantiating this pages you only pass through the driver object.
        // the private variables declared above are then passed through into the base constructor
        // to establish the page.

        public PortfolioPage(IWebDriver driver) : base(driver, TitleSelector, _title)
        {
        }

        //now we declare the attributes. just getters, for the elements on the page.
        // They return the element... for manipulation and such.

        private IWebElement TitleElement
        { get { return this.Driver.FindElement(TitleSelector); } }
       
        // And now we can declare our methods.
        // They should return a new page object.





    }
}
