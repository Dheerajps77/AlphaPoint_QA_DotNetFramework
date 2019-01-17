using AlphaPoint_QA.Pages;
using AlphaPoint_QA.Utils;
using log4net;
using OpenQA.Selenium;
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
    }
}
