using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Selenium.Framework
{
    public static class Wait
    {
        public static WebDriverWait GetWait(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30))
            {
                PollingInterval = TimeSpan.FromMilliseconds(700)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException));

            return wait;
        }
    }
}
