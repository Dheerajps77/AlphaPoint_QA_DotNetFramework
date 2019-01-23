﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlphaPoint_QA.Utils
{
    public static class SeleniumUtil
    {


        public static string GetCurrentTime()
        {
            DateTime date = DateTime.Now;
            string format = "M-dd-yyyy h:mmtt";
            string formattedDate = date.ToString(format).ToLower();
            return formattedDate;
        }


        public static String ConvertToDoubleFormat(double amount)
        {
            return String.Format("{0:0.00000000}", amount);
        }

        public static double ConvertStringToDouble(string amount)
        {
            return Convert.ToDouble(amount);
        }

        public static String FilledOrdersTotalAmount(double size, double price)
        {
            double totalAmount = size * price;
            return String.Format("{0:0.00000000}", totalAmount);
        }

        public static void TurnOffImplicitWaits(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public static void TurnOnImplicitWaits(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public static IWebElement WaitForElementVisibility(IWebDriver driver, By findByCondition, int waitInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds));
            wait.Until(ExpectedConditions.ElementExists(findByCondition));
            return driver.FindElement(findByCondition);
        }

        public static IWebElement WaitForElementPresence(IWebDriver driver, By findByCondition, int waitInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(findByCondition));
            return driver.FindElement(findByCondition);
        }

        public static IWebElement WaitForElementClickable(IWebDriver driver, By findByCondition, int waitInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(findByCondition));
            return driver.FindElement(findByCondition);
        }

        public static void CloseCurrentBrowserTab(IWebDriver driver)
        {
            driver.Close();
        }

        public static bool isElementPresent(IWebDriver driver, By locator)
        {
            TurnOffImplicitWaits(driver);
            bool result = false;
            try
            {
                result = driver.FindElement(locator).Displayed;
            }
            catch (Exception e)
            {
                TurnOnImplicitWaits(driver);
            }
            finally
            {
                TurnOnImplicitWaits(driver);
            }
            return result;
        }

        public static IWebElement ScrollToViewElement(IWebDriver driver, By findByCondition)
        {
            IWebElement element = driver.FindElement(findByCondition);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            return driver.FindElement(findByCondition);
        }

        public static void ScrollUp(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,-250)", "");
        }

        public static void HoverElement(IWebDriver driver, By locator)
        {
            Actions action = new Actions(driver);
            IWebElement we = driver.FindElement(locator);
            action.MoveToElement(we).Build().Perform();
        }

        public static void GetScreenshot(IWebDriver driver, string screenshotName)
        {
            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            file.SaveAsFile(screenshotName, ScreenshotImageFormat.Png);
        }

        public static void refreshPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public static void selectDropDownByValue(IWebDriver driver, By locator, String value)
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(locator));
            dropdown.SelectByValue(value);
        }

        public static void OpenNewBrowserWindow(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
