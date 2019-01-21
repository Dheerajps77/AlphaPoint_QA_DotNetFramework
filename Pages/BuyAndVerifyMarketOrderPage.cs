using AlphaPoint_QA.Common;
using AlphaPoint_QA.CommonLocators;
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

        public By placeBuyOrderButton = By.XPath("//button[text()='Place Buy Order']");
        public By placeSellOrderButton = By.XPath("//button[text()='Place Sell Order']");
        public By stopOrderTypeButton = By.XPath("//label[@data-test='Stop Order Type']");
        public By buyAmountTextField = By.XPath("//input[@data-test='Buy Amount']");
        public By sellAmountTextField = By.XPath("//input[@data-test='Sell Amount']");
        public By marketOrderTypeButton = By.XPath("//label[@data-test='Market Order Type']");
        public By limitOrderTypeButton = By.XPath("//label[@data-test='Limit Order Type']");
        public By buyOrderEntryButton = By.XPath("//label[@data-test='Buy Side']");
        public By sellOrderEntryButton = By.XPath("//label[@data-test='Sell Side']");
        public By orderEntryButton = By.XPath("//div[@data-test='Order Entry']");
        public By feesText = By.XPath("//div[contains(@class,'ap-label-with-text')]//label[contains(@class,'order-entry__lwt-label') and text()='Fees']");
        public By orderTotalText = By.XPath("//div[contains(@class,'ap-label-with-text')]//label[contains(@class,'order-entry__lwt-label') and text()='Order Total']");
        public By netText = By.XPath("//div[contains(@class,'ap-label-with-text')]//label[contains(@class,'order-entry__lwt-label') and text()='Net']");


        public BuyAndVerifyMarketOrderPage(IWebDriver driver, ITestOutputHelper output)
        {
            this.driver = driver;
            this.output = output;
            logger = APLogger.GetLog();
        }

        public void BuyAndVerifyMarketOrderFlow(string instrument, IWebDriver driver, string amountEntered)
        {

            Thread.Sleep(3000);

            // This needs to be changed - crate locator class
            CommonFunctionality.DashBoardMenuButton(driver);

            Thread.Sleep(2000);
          
            CommonFunctionality.SelectInstrumentFromExchange(instrument, driver);

            //CommonFunctionality.MarketOrderUnderBuy(driver);
            UserSetFunctions.Click(driver.FindElement(marketOrderTypeButton));
            UserSetFunctions.EnterText(driver.FindElement(buyAmountTextField), amountEntered);
            Thread.Sleep(2000);

            
            //string marketPrice = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[1]/span")).Text;
            Dictionary<string, string> balances = new Dictionary<string, string>();


            if (driver.FindElement(feesText).Enabled && driver.FindElement(orderTotalText).Enabled && driver.FindElement(netText).Enabled)
            {
                // Storing balances in Dictionary
                balances = CommonFunctionality.StoreMarketAmountBalances(driver);
                logger.Info("For Buy Order case ---> Balances stored successfully.");
                output.WriteLine("For Buy Order case ---> Balances stored successfully.");
            }
            else
            {
                logger.Error("For Buy Order case ---> Fees or Order Total or Net amount is not present");
                output.WriteLine("For Buy Order case ---> Fees or Order Total or Net amount is not present");
            }

            // Place Buy Order
            UserSetFunctions.Click(driver.FindElement(placeBuyOrderButton));

            // Verify the balances stored
            foreach (KeyValuePair<string, string> amount in balances)
            {
                output.WriteLine("Key: {0}, Value: {1}", amount.Key, amount.Value);
            }

            Thread.Sleep(2000);
            // This needs to be changed - crate locator class
            CommonFunctionality.FilledOrderTab(driver);
            CommonFunctionality.ScrollingDownVertical(driver);
        }
    }
}
