using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace TestsWithPOM
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void Initialize()
        {
            Browser.Initialize();
        }

        [TearDown]
        public void Cleanup()
        {
            Browser.Close();
            Browser.Quit();
        }
    }
}
