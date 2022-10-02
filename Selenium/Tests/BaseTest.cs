using OpenQA.Selenium;
using Selenium.Framework;

namespace Selenium.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        [SetUp]
        public void Init()
        {
            Driver = DriverFactory.GetDriver(Configuration.Browser);
            Driver.Navigate().GoToUrl(Configuration.URL);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Dispose();
        }
    }
}
