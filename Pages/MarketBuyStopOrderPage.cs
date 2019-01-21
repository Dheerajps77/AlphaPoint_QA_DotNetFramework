﻿using AlphaPoint_QA.Common;
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
    class MarketBuyStopOrderPage
    {

        IWebDriver driver;
        static ILog logger;
        private readonly ITestOutputHelper output;

        public By placeBuyOrderButton = By.XPath("//button[text()='Place Buy Order']");
        //public By placeSellOrderButton = By.XPath("//button[text()='Place Sell Order']");
        public By stopOrderTypeButton = By.XPath("//label[@data-test='Stop Order Type']");
        public By buyAmountTextField = By.XPath("//input[@data-test='Buy Amount']");
        public By stopPriceTextField = By.XPath("//input[@data-test='Stop Price']");
        //public By sellAmountTextField = By.XPath("//input[@data-test='Sell Amount']");
        //public By marketOrderTypeButton = By.XPath("//label[@data-test='Market Order Type']");
        //public By limitOrderTypeButton = By.XPath("//label[@data-test='Limit Order Type']");
        public By buyOrderEntryButton = By.XPath("//label[@data-test='Buy Side']");
        //public By sellOrderEntryButton = By.XPath("//label[@data-test='Sell Side']");
        //public By orderEntryButton = By.XPath("//div[@data-test='Order Entry']");
        public By feesText = By.XPath("//div[contains(@class,'ap-label-with-text')]//label[contains(@class,'order-entry__lwt-label') and text()='Fees']");
        public By orderTotalText = By.XPath("//div[contains(@class,'ap-label-with-text')]//label[contains(@class,'order-entry__lwt-label') and text()='Order Total']");
        public By netText = By.XPath("//div[contains(@class,'ap-label-with-text')]//label[contains(@class,'order-entry__lwt-label') and text()='Net']");
        public By marketPriceText= By.XPath("//div[contains(@class,'ap-label-with-text')]//label[contains(@class,'order-entry__lwt-label') and text()='Market Price']");

        public MarketBuyStopOrderPage(IWebDriver driver, ITestOutputHelper output)
        {

            this.driver = driver;
            this.output = output;
            logger = APLogger.GetLog();

        }

        public void StopBuyOrder(string instrument, IWebDriver driver, string buyAmount, string stopPrice)
        {
            CommonFunctionality.SelectDashBoardButton(driver);

            Thread.Sleep(2000);

            CommonFunctionality.SelectInstrumentFromExchange(instrument, driver);
            
            //Verifying whether Buy Button and Stop Button is present or not.
            if(driver.FindElement(buyOrderEntryButton).Selected && driver.FindElement(stopOrderTypeButton).Selected)
            {
                logger.Info("For Buy Stop Order case ---> Balances stored successfully.");
                output.WriteLine("For Buy Stop Order case ---> Balances stored successfully.");
            }
            else
            {
                logger.Info("For Buy Stop Order case ---> Balances stored successfully.");
                output.WriteLine("For Buy Stop Order case ---> Balances stored successfully.");
            }


            // Select Stop Buy Order
            UserSetFunctions.Click(driver.FindElement(stopOrderTypeButton));
            UserSetFunctions.EnterText(driver.FindElement(buyAmountTextField), buyAmount);
            UserSetFunctions.EnterText(driver.FindElement(stopPriceTextField), stopPrice);

            // Verify Market Price, Fees and Order Total
            Dictionary<string, string> balances = new Dictionary<string, string>();

            if (driver.FindElement(feesText).Enabled && driver.FindElement(orderTotalText).Enabled && driver.FindElement(marketPriceText).Enabled)
            {
                // Storing balances in Dictionary
                balances = CommonFunctionality.StoreMarketAmountBalances(driver);
                logger.Info("For Buy Stop Order case ---> Balances stored successfully.");
                output.WriteLine("For Buy Stop Order case ---> Balances stored successfully.");
            }
            else
            {
                logger.Error("For Buy stop Order case ---> Market or Order Total or Net amount is not present");
                output.WriteLine("For Buy stop Order case ---> Market or Order Total or Net amount is not present");
            }

            // Place Buy Order
            UserSetFunctions.Click(driver.FindElement(placeBuyOrderButton));

            // Verify Success message

            // Verify entry in Order Book
            // Verify entry Open orders tab

        }
    }
}