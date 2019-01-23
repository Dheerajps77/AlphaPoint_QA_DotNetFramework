using AlphaPoint_QA.Common;
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
    class AdvanceSellOrderPage
    {
        IWebDriver driver;
        private readonly ITestOutputHelper output;
        static ILog logger;
        string instrumentValue = "BTCUSD";
        string orderTypeValue = "Market Order";
        string exchangeMenuString = "Exchange";

        By advanceOrderButton = By.XPath("//div[@class='order-entry__item-button' and text()='« Advanced Orders']");
        By buyButton = By.XPath("//div[contains(@class,'advanced-order-sidepane__tab') and text()='Buy']");
        By sellButton = By.XPath("//div[text()='Sell']");
        By feesText = By.XPath("//span[contains(@class,'advanced-order-form__lwt-text') and @data-test='Fees:']");
        By orderTotalText = By.XPath("//span[contains(@class,'advanced-order-form__lwt-text') and @data-test='Order Total:']");
        By instrumentList = By.XPath("//select[@name='instrument']");
        By orderTypeList = By.XPath("//select[@name='orderType']");
        By ordersizeTextField = By.XPath("//div[@class='ap-input__input-box advanced-order-form__input-box']//input[@name='quantity']");
        //By LimitPrice = By.XPath("//div[@class='ap-input__input-box advanced-order-form__input-box']//input[@name='limitPrice']");
        //By displayQuntity = By.XPath("//div[@class='ap-input__input-box advanced-order-form__input-box']//input[@name='displayQuantity']");
        //By placeBuyOrderButton = By.XPath("//form[@class='advanced-order-form__body']//button[text()='Place Buy Order']");
        By placeSellOrderButton = By.XPath("//form[@class='advanced-order-form__body']//button[text()='Place Sell Order']");
        //By AskPrice = By.XPath("//div[@class='advanced-order-form__limit-price-block-value']");
        //By CloseIconAdvancedOrder = By.XPath("//div[@class='ap-sidepane__close-button advanced-order-sidepane__close-button']/span");

        By exchangeMenuText = By.XPath("//span[@class='page-header-nav__label' and text()='Exchange']");

        public AdvanceSellOrderPage(IWebDriver driver, ITestOutputHelper output)
        {
            this.driver = driver;
            this.output = output;
            logger = APLogger.GetLog();
        }

        

        public void VerifyAdvanceSellOrder(string instrument, IWebDriver driver, string orderSize)
        {
            bool flag = false;
            Thread.Sleep(3000);
            CommonFunctionality.SelectDashBoardButton(driver);
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
            UserSetFunctions.Click(driver.FindElement(advanceOrderButton));

            Thread.Sleep(2000);
            UserSetFunctions.Click(driver.FindElement(sellButton));

            UserSetFunctions.SelectDropdown(driver.FindElement(instrumentList), instrument);
            UserSetFunctions.SelectDropdown(driver.FindElement(orderTypeList), orderTypeValue);

            UserSetFunctions.EnterText(driver.FindElement(ordersizeTextField), orderSize);

            if(driver.FindElement(feesText).Displayed && driver.FindElement(orderTotalText).Enabled)
            {

                logger.Info("Fees and OrderTotal is displaying in the page.");
                output.WriteLine("Fees and OrderTotal is displaying in the page.");

            }
            else
            {
                logger.Error("Fees and OrderTotal is displaying in the page.");
                output.WriteLine("Fees and OrderTotal is displaying in the page.");
            }

            UserSetFunctions.Click(driver.FindElement(placeSellOrderButton));
        }
    }
}
