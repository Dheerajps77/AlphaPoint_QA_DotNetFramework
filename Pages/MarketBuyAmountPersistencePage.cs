using AlphaPoint_QA.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Pages
{
    public class MarketBuyAmountPersistencePage
    {
        IWebDriver driver;
        private readonly ITestOutputHelper output;

        public MarketBuyAmountPersistencePage(IWebDriver driver, ITestOutputHelper output)
        {
            this.driver = driver;
            this.output = output;
        }


        By buyAmountTextField = By.XPath("//input[@data-test='Buy Amount']");
        By sellAmountTextField = By.XPath("//input[@data-test='Sell Amount']");
       
        //By textOfHomePage = By.XPath("//a[text()='Your Snapshot']");
        By exchangeMenuText = By.XPath("//span[@class='page-header-nav__label' and text()='Exchange']");
        string exchangeMenuString = "Exchange";

        public bool VerifyingPersistantAmount(string amountEntered)
        {
            bool flag = false;
            CommonFunctionalities.DashBoardMenuButton(driver);
            CommonFunctionalities.SelectAnExchange(driver);
            Thread.Sleep(3000);
            string exchangeStringValueFromSite=driver.FindElement(exchangeMenuText).Text;
            Thread.Sleep(3000);

            if(exchangeStringValueFromSite.Equals(exchangeMenuString))
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

            CommonFunctionalities.MarketOrderUnderBuy(driver);
            driver.FindElement(buyAmountTextField).SendKeys(amountEntered);

            CommonFunctionalities.ClickOnLimitOrderTypeUnderBuy(driver);
            CommonFunctionalities.SelectAnStopUnderOrderEntry(driver);
            CommonFunctionalities.MarketOrderUnderBuy(driver);

            Thread.Sleep(2000);
            string amountPersisted = driver.FindElement(buyAmountTextField).GetAttribute("value");
            output.WriteLine("Amount Persisted - > "+ amountPersisted);
            if (amountEntered.Equals(amountPersisted))
            {
                Assert.True(true, "Test case has been passed for Buy Market Order Type.");
                output.WriteLine("Test case has been passed for Buy Market Order Type.");
                flag = true;
            }
            else
            {
                Assert.False(false, "Test case has been failed for Buy Market Order Type.");
                output.WriteLine("Test case has been failed for Buy Market Order Type.");
                flag = false;
            }

            CommonFunctionalities.ExchangeOrderSell(driver);
            CommonFunctionalities.MarketOrderUnderBuy(driver);
            driver.FindElement(sellAmountTextField).SendKeys(amountEntered);

            CommonFunctionalities.ClickOnLimitOrderTypeUnderBuy(driver);
            CommonFunctionalities.SelectAnStopUnderOrderEntry(driver);
            CommonFunctionalities.MarketOrderUnderBuy(driver);

            Thread.Sleep(2000);
            
            output.WriteLine("Amount Persisted - > " + amountPersisted);
            if (amountEntered.Equals(amountPersisted))
            {
                Assert.True(true, "Test case has been passed for Sell Market Order Type.");
                output.WriteLine("Test case has been passed for Sell Market Order Type.");
                flag = true;
            }
            else
            {
                Assert.False(false, "Test case has been failed for Sell Market Order Type.");
                output.WriteLine("Test case has been failed for Sell Market Order Type.");
                flag = false;
            }


            CommonFunctionalities.LogOut(driver);
            Thread.Sleep(4000);
            driver.Close();
            return flag;
        }
    }
}
