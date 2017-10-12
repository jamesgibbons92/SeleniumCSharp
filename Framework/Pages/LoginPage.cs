using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.Pages
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "user_login")]
        private IWebElement UserName { get; set; }

        public void Goto()
        {
            Browser.Goto("/wp-login.php");
        }

        public void Login(string userName = "gibbonz", string password = "SeleniumUser5")
        {
            //Browser.Driver.FindElement(By.LinkText("log in with a password")).Click();
            //find the field for ther user name
            // Using PageFactory to instantiate the elemnts seen at the top of the page so we can remove this.
            //var userNameField = Browser.Driver.FindElement(By.Id("user_login"));
            //userNameField.SendKeys(userName);
            UserName.SendKeys(userName);

            //find the field for the password
            var passwordField = Browser.Driver.FindElement(By.Id("user_pass"));
            passwordField.SendKeys(password);

            Browser.Driver.FindElement(By.Id("wp-submit")).Click();
        }
    }
}