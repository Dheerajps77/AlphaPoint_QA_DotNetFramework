using AlphaPoint_QA.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaPoint_QA.Pages
{
    class UserHomePage
    {
        IWebDriver driver;
        public UserHomePage(IWebDriver driver)
        {
            this.driver = driver;
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
