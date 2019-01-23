using AlphaPoint_QA.Common;
using AlphaPoint_QA.Utils;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Pages
{
    class UserHomePage
    {

        private readonly ITestOutputHelper output;
        static ILog logger;
        static Config data;
        static string username;
        static string password;

        IWebDriver driver;
        public UserHomePage(IWebDriver driver, ITestOutputHelper output)
        {
            this.output = output;
            logger = APLogger.GetLog();
            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;
        }

        /// <summary>
        /// Locators for elements
        /// </summary>
        By loggedInUserName = By.XPath("//*[@id='root']/div[1]/div[1]/div[3]/div[1]/div/button/span/span[2]");
        By signOutButton = By.XPath("//*[@id='root']/div[1]/div[1]/div[3]/div[1]/div/div/div/a[2]/span");
        //By selectServer = By.XPath("");



        //This method Navigates to Exchange selects the Instrument
        public void SelectInstrumentFromExchange()
        {

        }


        //This method Logs out the User
        public void Logout()
        {
            UserSetFunctions.Click(driver.FindElement(loggedInUserName));
            UserSetFunctions.Click(driver.FindElement(signOutButton));
        }
    }
}
