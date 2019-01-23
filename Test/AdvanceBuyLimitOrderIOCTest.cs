using AlphaPoint_QA.Common;
using AlphaPoint_QA.Pages;
using AlphaPoint_QA.Utils;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Test
{
    public class AdvanceBuyLimitOrderIOCTest
    {
        private readonly ITestOutputHelper output;
        public static IWebDriver driver;
        static ILog logger;
        static Config data;
        static string username;
        static string password;

        string instrumentText = "BTCUSD";
        string orderTypeText = "Immediate or Cancel";
        string orderSizeValue = "1";
        string limitPriceValue = "2";
        string timeInForceSelectTextValue = "Immediate or Cancel";
        string sellAmount = "0.77";
        string limitAmount = "0.77";

        public AdvanceBuyLimitOrderIOCTest(ITestOutputHelper output)
        {
            this.output = output;
            logger = APLogger.GetLog();
            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;

        }

        [Fact]
        public void AdvanceLimitOrderIOC()
        {
            driver.Navigate().GoToUrl("https://apexwebqa.azurewebsites.net/exchange");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            UserFunctionality objUserFunctionality = new UserFunctionality(output);
            objUserFunctionality.LogIn();

            AdvanceBuyLimitOrderIOCPage objAdvanceBuyLimitOrderIOCPage = new AdvanceBuyLimitOrderIOCPage(driver, output);
            
        }


    }
}
