using OpenQA.Selenium;

namespace Selenium.Framework
{
    public class WaitConditions
    {
        public static Func<IWebDriver, bool> ElemensIsDisplayed(By locator)
        {
            bool condition(IWebDriver driver)
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
            }
            return condition;
        }

        public static Func<IWebDriver, bool> ElemensIsNotDisplayed(By locator)
        {
            bool condition(IWebDriver driver)
            {
                try
                {
                    var element = driver.FindElements(locator);
                    return element.Count == 0;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
            }
            return condition;
        }

        public static Func<IWebDriver, bool> ElementIsNotVisible(By locator)
        {
            bool condition(IWebDriver driver)
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Size.Height == 0
                        && element.Size.Width ==0;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
            }
            return condition;
        }
    }
}
