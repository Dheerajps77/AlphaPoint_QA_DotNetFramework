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
   public class SellAndVerifyMarketOrderTest
    {
        IWebDriver driver;
        static ILog logger;
        private readonly ITestOutputHelper output;

        static Config data;
        static string username;
        static string password;

        public SellAndVerifyMarketOrderTest(ITestOutputHelper output)
        {
            this.output = output;
            logger = APLogger.GetLog();

            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;
        }

        [Fact]
        public void SellAndVerifyMarketOrderTestCase()
        {
            driver.Navigate().GoToUrl("https://apexwebqa.azurewebsites.net/exchange");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            UserFunctionality objUserFunctionality = new UserFunctionality(output);
            objUserFunctionality.LogIn();

            SellAndVerifyMarketOrderPage objSellAndVerifyMarketOrderPage = new SellAndVerifyMarketOrderPage(driver, output);
            objSellAndVerifyMarketOrderPage.SellAndVerifyMarketOrderFlow("BTCUSD", driver, "1");
        }
    }
}
