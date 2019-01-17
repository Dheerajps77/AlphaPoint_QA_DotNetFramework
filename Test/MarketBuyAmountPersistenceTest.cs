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
    public class MarketBuyAmountPersistenceTest
    {
        private readonly ITestOutputHelper output;
        public static IWebDriver driver;
        static ILog logger;
        static Config data;
        static string username;
        static string password;

        public MarketBuyAmountPersistenceTest(ITestOutputHelper output)
        {
            this.output = output;
            logger = APLogger.GetLog();


            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;
        }

        
        [Fact]
        public void VerifyPricePersistancy()
        {
            driver.Navigate().GoToUrl("https://apexwebqa.azurewebsites.net/exchange");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            UserFunctionality objUserFunctionality = new UserFunctionality(output);
            objUserFunctionality.LogIn();

            MarketBuyAmountPersistencePage ObjPricePersistValuesPage = new MarketBuyAmountPersistencePage(driver, output);
            if (ObjPricePersistValuesPage.VerifyingPersistantAmount("20"))
            {
                logger.Info("MarketBuyAmountPersistenceTest Passed");
            }
            else
            {
                logger.Info("MarketBuyAmountPersistenceTest Failed");
                //logger.Error();
            }
            

        }
    }
}
