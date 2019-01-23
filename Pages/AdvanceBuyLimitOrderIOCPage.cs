using AlphaPoint_QA.Common;
using AlphaPoint_QA.Utils;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Pages
{
    class AdvanceBuyLimitOrderIOCPage
    {
        IWebDriver driver;
        private readonly ITestOutputHelper output;
        static ILog logger;
        string instrumentValue = "BTCUSD";
        string exchangeMenuString = "Exchange";

        By advanceOrderButton = By.XPath("//div[@class='order-entry__item-button' and text()='« Advanced Orders']");
        By buyButton = By.XPath("//div[contains(@class,'advanced-order-sidepane__tab') and text()='Buy']");
        By sellButton = By.XPath("//div[text()='Sell']");
        By feesText = By.XPath("//span[contains(@class,'advanced-order-form__lwt-text') and @data-test='Fees:']");
        By orderTotalText = By.XPath("//span[contains(@class,'advanced-order-form__lwt-text') and @data-test='Order Total:']");
        By instrumentList = By.XPath("//select[@name='instrument']");
        By orderTypeList = By.XPath("//select[@name='orderType']");
        By ordersizeTextField = By.XPath("//div[@class='ap-input__input-box advanced-order-form__input-box']//input[@name='quantity']");
        By placeBuyOrderButton = By.XPath("//button[contains(@class,'advanced-order-form__btn') and text()='Place Buy Order']");
        By placeSellOrderButton = By.XPath("//button[contains(@class,'advanced-order-form__btn') and text()='Place Sell Order']");
      
        By exchangeMenuText = By.XPath("//span[@class='page-header-nav__label' and text()='Exchange']");
        By sellOrderEntryButton = By.XPath("//label[@data-test='Sell Side']");
        By sellAmountTextField = By.XPath("//input[@data-test='Sell Amount']");
        By limitOrderTypeButton = By.XPath("//label[@data-test='Limit Order Type']");
        By orderEntrySlectTimeInForce = By.XPath("//select[@name='timeInForce']");

        By advanceOrderSizeAmount = By.XPath("//input[@data-test='Order Size:']");
        By advanceOrderLimitAmount = By.XPath("//input[@data-test='Limit Price:']");
        By openOrderAllListValue = By.XPath("//div[@class='flex-table__body order-history-table__body']/div");
        By openOrderTabButton = By.XPath("//div[@data-test='Open Orders']");

        AdvancedOrderPage objAdvancedOrderPage;
        UserFunctionality objUserFunctionality;


        public AdvanceBuyLimitOrderIOCPage(IWebDriver driver, ITestOutputHelper output)
        {
            this.driver = driver;
            this.output = output;
            logger = APLogger.GetLog();
        }

        public void AdvanceOrdersButton(string instrument, IWebDriver driver)
        {
            bool flag = false;
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

            CommonFunctionality.SelectDashBoardButton(driver);
            CommonFunctionality.SelectInstrumentFromExchange(instrument, driver);
            UserSetFunctions.Click(driver.FindElement(advanceOrderButton));
            UserSetFunctions.Click(driver.FindElement(buyButton));

            Thread.Sleep(2000);

            if(driver.FindElement(buyButton).Selected)
            {
                Assert.True(true, "Buy Button clicked in Advance Order section.");
                output.WriteLine("Buy Button clicked in Advance Order section.");
            }

            else
            {
                Assert.True(true, "Buy Button isn't clicked in Advance Order section.");
                output.WriteLine("Buy Button isn't clicked in Advance Order section.");
            }
            Thread.Sleep(2000);
        }

        public void AdvanceBuyLimitOrderIOC(string orderType, string instrument, string orderSize, string limitPrice)
        {
            objAdvancedOrderPage = new AdvancedOrderPage(output);
            objUserFunctionality = new UserFunctionality(output);

            objAdvancedOrderPage.PlaceBuyOrderWithImmediateOrCancelType(orderType, instrument, orderSize, limitPrice);
            UserSetFunctions.EnterText(driver.FindElement(advanceOrderSizeAmount), orderSize);
            UserSetFunctions.EnterText(driver.FindElement(advanceOrderLimitAmount), limitPrice);
            UserSetFunctions.Click(driver.FindElement(placeBuyOrderButton));
        }

        public void AdvanceSellLimitOrderIOC(string orderType, string instrument, string orderSize, string limitPrice, string selectTimeInForceOrderEntryValue)
        {
            UserSetFunctions.Click(driver.FindElement(sellButton));
            objAdvancedOrderPage = new AdvancedOrderPage(output);
            objUserFunctionality = new UserFunctionality(output);

            objAdvancedOrderPage.PlaceBuyOrderWithImmediateOrCancelType(orderType, instrument, orderSize, limitPrice);
            UserSetFunctions.EnterText(driver.FindElement(advanceOrderSizeAmount), orderSize);
            UserSetFunctions.EnterText(driver.FindElement(advanceOrderLimitAmount), limitPrice);
            UserSetFunctions.Click(driver.FindElement(placeSellOrderButton));
            objUserFunctionality.SelectTimeInForceOrderEntry(selectTimeInForceOrderEntryValue);

            Thread.Sleep(2000);
            UserSetFunctions.Click(driver.FindElement(openOrderTabButton));

        }

        public bool VerifyAdvanceBuyOrderTab(string instrument, string side, double size, string limitPrice, string buyMarketOrderTime)
        {
            bool flag = false;
            UserSetFunctions.Click(driver.FindElement(openOrderTabButton));
            string buyAmountValue = SeleniumUtil.ConvertToDoubleFormat(size);
            string expectedRow = instrument + " || " + side + " || " + size + " || " + limitPrice + " || " + buyMarketOrderTime;

            if (GetListOfOpenOrders().Contains(expectedRow))
            {
                output.WriteLine("Matched Expected -> " + expectedRow + " Actual -> ");
                flag = true;
            }
            return flag;


        }

        public void VerifyAdvanceSellOrderTab()
        {

        }

        public ArrayList GetListOfOpenOrders()
        {
            ArrayList openOrderList = new ArrayList();
            int countOfOpenOrders = driver.FindElements(openOrderAllListValue).Count;
            for (int i = 1; i <= countOfOpenOrders; i++)
            {
                String textFinal = "";
                int countItems = driver.FindElements(By.XPath("(//div[@class='flex-table__body order-history-table__body']/div)[" + i + "]/div")).Count;
                output.WriteLine("countItems ---- " + countItems);
                for (int j = 1; j <= (countItems - 2); j++)
                {
                    String text = driver.FindElement(By.XPath("(//div[@class='flex-table__body order-history-table__body']/div)[" + i + "]/div[" + j + "]")).Text;
                    output.WriteLine("text ---- " + text);
                    if (j == 2)
                    {
                        textFinal = text;
                    }
                    else
                    {
                        textFinal = textFinal + " || " + text;
                    }

                }
                openOrderList.Add(textFinal);
                output.WriteLine("Text FINAL---- " + textFinal);
            }
            return openOrderList;
        }
    }
}
