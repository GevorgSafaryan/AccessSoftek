using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Framework
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver;
            switch (browser)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddArgument("disable-infobars");
                    driver = new ChromeDriver(options);
                    break;
                default:
                    throw new Exception("Usupported browser type");
            }
            return driver;
        }
    }
}
