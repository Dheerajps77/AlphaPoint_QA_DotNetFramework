using AlphaPoint_QA.Pages;
using AlphaPoint_QA.Utils;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Common
{
    public class UserFunctionality
    {
        private readonly ITestOutputHelper output;
        public static IWebDriver driver;
        static ILog logger;
        static Config data;
        static string username;
        static string password;

        By CloseIconAdvancedOrder = By.XPath("//div[@class='ap-sidepane__close-button advanced-order-sidepane__close-button']/span");
        By orderEntrySelectTimeInForce = By.XPath("//select[@name='timeInForce']");


        public UserFunctionality(ITestOutputHelper output)
        {
            this.output = output;
            logger = APLogger.GetLog();
            logger.Info("Test Started");


            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;
        }
        public void LogIn()
        {
            username = data.UserPortal.Users["User1"].UserName;
            password = data.UserPortal.Users["User1"].Password;

            LoginPage loginPage = new LoginPage(driver, output);
            loginPage.Login(username, password);
        }

        public void LogOut()
        {

        }

        public void SelectExchange()
        {

        }

        public void SelectOrder()
        {

        }

        public void GetExchangeOrderBuy()
        {

        }

        public void GetExchangeOrderSell ()
        {

        }

        public void AdvanceOrder()
        {

        }

        public void CreateOrdersBuy(int number)
        {

        }

        public void CreateOrdersSell(int number)
        {

        }

        public void CloseAdvancedOrderSection()
        {
            try
            {
                IWebElement closeadvanced = driver.FindElement(CloseIconAdvancedOrder);
                UserSetFunctions.Click(closeadvanced);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SelectTimeInForceOrderEntry(string selectValueOption)
        {
            IWebElement webElementOfTimeInFroce = driver.FindElement(orderEntrySelectTimeInForce);
            SelectElement select = new SelectElement(webElementOfTimeInFroce);

            if(selectValueOption.Equals("Good Til Canceled"))
            {
                select.SelectByText("Good Til Canceled");
            }
            else if(selectValueOption.Equals("Immediate or Cancel"))
            {
                select.SelectByText("Immediate or Cancel");
            }
            else if(selectValueOption.Equals("Fill or Kill"))
            {
                select.SelectByText("Fill or Kill");
            }
        }
    }
}
