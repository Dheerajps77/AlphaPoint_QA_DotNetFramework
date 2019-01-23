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
    class AdvancedOrderPage
    {
        static ILog logger;
        private readonly ITestOutputHelper output;
        static Config data;
        public static IWebDriver driver;

        By buyTab = By.XPath("//div[text()='Buy']");
        By sellTab = By.XPath("//div[text()='Sell']");
        By instrument = By.Name("instrument");
        By orderType = By.XPath("//select[@name='orderType']");
        By orderSize = By.XPath("//div[@class='ap-input__input-box advanced-order-form__input-box']//input[@name='quantity']");
        By limitPrice = By.XPath("//div[@class='ap-input__input-box advanced-order-form__input-box']//input[@name='limitPrice']");
        By displayQuntity = By.XPath("//div[@class='ap-input__input-box advanced-order-form__input-box']//input[@name='displayQuantity']");
        By placeByOrder = By.XPath("//form[@class='advanced-order-form__body']//button[text()='Place Buy Order']");
        By askPrice = By.XPath("//div[@class='advanced-order-form__limit-price-block-value']");
        By closeIconAdvancedOrder = By.XPath("//div[@class='ap-sidepane__close-button advanced-order-sidepane__close-button']/span");

        public AdvancedOrderPage(ITestOutputHelper output)
        {
            this.output = output;
            logger = APLogger.GetLog();
            logger.Info("Test Started");
            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;
        }


        public void SelectBuyOrSellTab(string buyOrSell)
        {
            Thread.Sleep(1000);
            try
            {
                if (buyOrSell.Equals("Buy"))
                {
                    driver.FindElement(buyTab).Click();
                }
                else if (buyOrSell.Equals("Sell"))
                {
                    driver.FindElement(sellTab).Click();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public string GetAskPrice()
        {
            return driver.FindElement(askPrice).Text;
        }


        public void PlaceBuyOrderWithReserveOrderType(string instruments, string ordertype, string ordersize, string limitprice, string displayquantity)
        {
            try
            {

                IWebElement instrumet = driver.FindElement(instrument);
                UserSetFunctions.VerifyWebElement(instrumet);
                UserSetFunctions.SelectDropdown(instrumet, instruments);

                IWebElement ordertyp = driver.FindElement(orderType);
                UserSetFunctions.VerifyWebElement(ordertyp);
                UserSetFunctions.SelectDropdown(ordertyp, ordertype);

                IWebElement ordersiz = driver.FindElement(orderSize);
                UserSetFunctions.VerifyWebElement(ordersiz);
                UserSetFunctions.EnterText(ordersiz, ordersize);

                IWebElement limitpric = driver.FindElement(limitPrice);
                UserSetFunctions.VerifyWebElement(limitpric);
                UserSetFunctions.EnterText(limitpric, limitprice);

                IWebElement displayquntity = driver.FindElement(displayQuntity);
                UserSetFunctions.VerifyWebElement(displayquntity);
                UserSetFunctions.EnterText(displayquntity, displayquantity);


                IWebElement placebuyorder = driver.FindElement(placeByOrder);
                UserSetFunctions.VerifyWebElement(placebuyorder);
                UserSetFunctions.Click(placebuyorder);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void PlaceBuyOrderWithImmediateOrCancelType(string instruments, string ordertype, string ordersize, string limitprice)
        {
            try
            {
                IWebElement instrumet = driver.FindElement(instrument);
                UserSetFunctions.SelectDropdown(instrumet, instruments);

                IWebElement ordertyp = driver.FindElement(orderType);
                UserSetFunctions.SelectDropdown(ordertyp, ordertype);

                IWebElement ordersiz = driver.FindElement(orderSize);
                UserSetFunctions.EnterText(ordersiz, ordersize);

                IWebElement limitpric = driver.FindElement(limitPrice);
                UserSetFunctions.EnterText(limitpric, limitprice);

                IWebElement placebuyorder = driver.FindElement(placeByOrder);
                UserSetFunctions.Click(placebuyorder);
            }
            catch (Exception e)
            {
                throw e;
            }
        }





    }
}
