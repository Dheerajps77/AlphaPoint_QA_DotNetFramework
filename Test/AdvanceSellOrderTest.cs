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
   public class AdvanceSellOrderTest
    {
        private readonly ITestOutputHelper output;
        public static IWebDriver driver;
        static ILog logger;
        static Config data;
        static string username;
        static string password;

        string selectInstrument = "BTCUSD";
        string enterOrderSize = "1.1";

        public AdvanceSellOrderTest(ITestOutputHelper output)
        {

            this.output = output;
            logger = APLogger.GetLog();
            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;
        }

        [Fact]
        public void AdvanceSellOrder()
        {
            driver.Navigate().GoToUrl("https://apexwebqa.azurewebsites.net/exchange");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            UserFunctionality objUserFunctionality = new UserFunctionality(output);
            objUserFunctionality.LogIn();

            AdvanceSellOrderPage objAdvanceSellOrderPage = new AdvanceSellOrderPage(driver, output);
            objAdvanceSellOrderPage.VerifyAdvanceSellOrder(selectInstrument, driver, enterOrderSize);
        }
    }
}
