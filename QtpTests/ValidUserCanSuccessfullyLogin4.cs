using Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QtpTests
{
    [TestClass]
    public class ValidUserCanSuccessfullyLogin4 : TestBase
    {
        [TestMethod]
        public void ValidUserCanSuccessfullyLogin()
        {
            Pages.Login.Goto();
            Pages.Login.Login();
            Assert.IsTrue(Pages.MyMembership.IsAt(), "A valid user was not able to successfully login.");
        }
    }
}
