using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AlphaPoint_QA.Utils
{
    public static class SeleniumUtil
    {


        public static IWebElement waitForElementPresence(IWebDriver driver, By findByCondition, int waitInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.Parse(waitInSeconds.ToString()));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(findByCondition));
            return driver.FindElement(findByCondition);
        }

        public static IWebElement WaitForElementVisibility(IWebDriver driver, By findByCondition, int waitInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.Parse(waitInSeconds.ToString()));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(findByCondition));
            return driver.FindElement(findByCondition);
        }

        public static IWebElement waitForElementClickable(IWebDriver driver, By findByCondition, int waitInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.Parse(waitInSeconds.ToString()));
            wait.Until(ExpectedConditions.ElementToBeClickable(findByCondition));
            return driver.FindElement(findByCondition);
        }

        public static int countWindow(IWebDriver driver)
        {
            ICollection<String> windowHandle = driver.WindowHandles;
            int count = windowHandle.Count;
            return count;
        }

        public static void switchWindowByIndex(IWebDriver driver, int windowno)
        {
            ICollection<String> window = driver.WindowHandles;
            driver.SwitchTo().Window(window.ToArray()[windowno].ToString());
        }

        public static void closeCurrentBrowserTab(IWebDriver driver)
        {
            driver.Close();
        }
    }
}
