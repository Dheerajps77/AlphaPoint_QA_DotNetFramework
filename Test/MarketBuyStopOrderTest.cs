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
    public class MarketBuyStopOrderTest
    {
        private readonly ITestOutputHelper output;
        public static IWebDriver driver;
        static ILog logger;
        static Config data;
        static string username;
        static string password;

        string instrumentText = "BTCUSD";
        string buyStopAmount = "0.77";
        string buyStopPrice = "0.77";

        public MarketBuyStopOrderTest(ITestOutputHelper output)
        {

            this.output = output;
            logger = APLogger.GetLog();


            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;
        }

        
        //Need to test this test case.
        [Fact]
        public void VerifyBuyStopOrder()
        {
            driver.Navigate().GoToUrl("https://apexwebqa.azurewebsites.net/exchange");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            UserFunctionality objUserFunctionality = new UserFunctionality(output);
            objUserFunctionality.LogIn();

            MarketBuyStopOrderPage objMarketBuyStopOrderPage = new MarketBuyStopOrderPage(driver, output);
         objMarketBuyStopOrderPage.StopBuyOrder(instrumentText, driver, buyStopAmount, buyStopPrice);
        }
    }
}
