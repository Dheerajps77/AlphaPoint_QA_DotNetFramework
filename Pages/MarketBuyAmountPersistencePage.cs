using AlphaPoint_QA.Common;
using AlphaPoint_QA.CommonLocators;
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

        public MarketBuyAmountPersistencePage(IWebDriver driver, ITestOutputHelper output)
        {
            this.driver = driver;
            this.output = output;
        }

        By exchangeMenuText = By.XPath("//span[@class='page-header-nav__label' and text()='Exchange']");
        string exchangeMenuString = "Exchange";

        

        public bool VerifyingPersistantAmount(string amountEntered)
        {
     
            bool flag = false;
            CommonFunctionality.SelectDashBoardButton(driver);
            CommonFunctionality.NavigateToExchange(driver);
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

            UserSetFunctions.Click(driver.FindElement(marketOrderTypeButton));
            UserSetFunctions.EnterText(driver.FindElement(buyAmountTextField), amountEntered);
            UserSetFunctions.Click(driver.FindElement(limitOrderTypeButton));
            UserSetFunctions.Click(driver.FindElement(stopOrderTypeButton));
            UserSetFunctions.Click(driver.FindElement(marketOrderTypeButton));

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

            UserSetFunctions.Click(driver.FindElement(sellOrderEntryButton));
            UserSetFunctions.Click(driver.FindElement(marketOrderTypeButton));
            UserSetFunctions.Click(driver.FindElement(sellAmountTextField));
            UserSetFunctions.Click(driver.FindElement(limitOrderTypeButton));
            UserSetFunctions.Click(driver.FindElement(stopOrderTypeButton));
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
             CommonFunctionality.LogOut(driver);
            Thread.Sleep(4000);
            driver.Close();
            return flag;
        }
    }
}
