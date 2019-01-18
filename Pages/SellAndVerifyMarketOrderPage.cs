using AlphaPoint_QA.Common;
using AlphaPoint_QA.CommonLocators;
using AlphaPoint_QA.Utils;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Pages
{
    class SellAndVerifyMarketOrderPage : OrderEntryLocators
    {
        IWebDriver driver;
        static ILog logger;
        private readonly ITestOutputHelper output;

        public SellAndVerifyMarketOrderPage(IWebDriver driver, ITestOutputHelper output)
        {
            this.driver = driver;
            this.output = output;
            logger = APLogger.GetLog();
        }

        By exchangeMenuText = By.XPath("//span[@class='page-header-nav__label' and text()='Exchange']");
        string exchangeMenuString = "Exchange";

        public void SellAndVerifyMarketOrderFlow(string instrument, IWebDriver driver, string amountPrice)
        {
            bool flag = false;
            Thread.Sleep(3000);
            CommonFunctionality.DashBoardMenuButton(driver);
            Thread.Sleep(2000);


            string exchangeStringValueFromSite = driver.FindElement(exchangeMenuText).Text;
            Thread.Sleep(3000);

            if (exchangeStringValueFromSite.Equals(exchangeMenuString))
            {
                Assert.True(true, "Verification for exchangeMenu value has been passed.");
                output.WriteLine("Verification for exchangeMenu value has been passed.");
                flag = true;
            }
            else
            {
                Assert.False(false, "Verification for exchangeMenu value has been failed.");
                output.WriteLine("Verification for exchangeMenu value has been failed.");
                flag = false;
            }

            CommonFunctionality.SelectInstrumentFromExchange(instrument, driver);
            UserSetFunctions.Click(driver.FindElement(sellOrderEntryButton));
            UserSetFunctions.Click(driver.FindElement(marketOrderTypeButton));
            UserSetFunctions.EnterText(driver.FindElement(sellAmountTextField), amountPrice);

            Dictionary<string, string> balances = new Dictionary<string, string>();
            if (driver.FindElement(feesText).Enabled && driver.FindElement(orderTotalText).Enabled && driver.FindElement(netText).Enabled)
            {
                // Storing balances in Dictionary
                balances = CommonFunctionality.StoreMarketAmountBalances(driver);
                logger.Info("For Sell Order case --> Balances stored successfully.");
                output.WriteLine("For Sell Order case --> Balances stored successfully.");
            }
            else
            {
                logger.Error("For Sell Order case --> Fees or Order Total or Net amount is not present");
                output.WriteLine("For Sell Order case --> Fees or Order Total or Net amount is not present");
            }

            Thread.Sleep(2000);
            UserSetFunctions.Click(driver.FindElement(placeSellOrderButton));
            // This needs to be changed - crate locator class
            CommonFunctionality.FilledOrderTab(driver);
            CommonFunctionality.ScrollingDownVertical(driver);
        }
    }
}
