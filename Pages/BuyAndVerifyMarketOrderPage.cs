using AlphaPoint_QA.Common;
using AlphaPoint_QA.Utils;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Pages
{
    class BuyAndVerifyMarketOrderPage
    {
        IWebDriver driver;
        static ILog logger;


        private readonly ITestOutputHelper output;
        By buyAmountTextField = By.XPath("//input[@data-test='Buy Amount']");

        public BuyAndVerifyMarketOrderPage(IWebDriver driver, ITestOutputHelper output)
        {
            this.driver = driver;
            this.output = output;
            logger = APLogger.GetLog();
        }
     public void BuyAndVerifyMarketOrderFow(string instrument, IWebDriver driver)
        {
            Thread.Sleep(3000);
            CommonFunctionalities.DashBoardMenuButton(driver);
            Thread.Sleep(2000);
          
            CommonFunctionalities.SelectInstrumentFromExchange(instrument, driver);
           
            CommonFunctionalities.MarketOrderUnderBuy(driver);
            driver.FindElement(buyAmountTextField).SendKeys("20");
            Thread.Sleep(2000);

            
            //string marketPrice = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[1]/span")).Text;
            IWebElement fees = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[2]/span"));

            IWebElement orderTotal = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[3]/span"));

            IWebElement net = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[4]/span"));
            Dictionary<string, string> balances = new Dictionary<string, string>();


            if (fees.Enabled && orderTotal.Enabled && net.Enabled)
            {
                // Storing balances in Dictionary
                balances = CommonFunctionalities.StoreMarketAmountBalances(driver);
                logger.Info("Balances stored successfully.");
                output.WriteLine("Balances stored successfully.");
            }
            else
            {
                logger.Error("Fees or Order Total or Net amount is not present");
                output.WriteLine("Fees or Order Total or Net amount is not present");
            }

            // Place Buy Order
            CommonFunctionalities.PlaceMarketBuyOrder(driver);

            // Verify the balances stored
            foreach (KeyValuePair<string, string> amount in balances)
            {
                output.WriteLine("Key: {0}, Value: {1}", amount.Key, amount.Value);
            }


        }
    }
}
