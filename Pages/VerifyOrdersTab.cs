using AlphaPoint_QA.Common;
using AlphaPoint_QA.Utils;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Pages
{
    class VerifyOrdersTab
    {
        IWebDriver driver;
        private readonly ITestOutputHelper output;
        static ILog logger;
        static Config data;
        static string username;
        static string password;

        public VerifyOrdersTab(IWebDriver driver, ITestOutputHelper output)
        {
            this.driver = driver;
            this.output = output;
        }

        /// <summary>
        /// Locators for elements
        /// </summary>
        By selectFilledOrdersTab = By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[1]/div[3]/div[1]/div[2]");
        By buyMarketPair = By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[1]/div[3]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[2]");
        By buyMarketSide = By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[1]/div[3]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[3]/div");
        By buyMarketSize = By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[1]/div[3]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[4]/div");
        By buyMarketPrice = By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[1]/div[3]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[5]/div");
        By buyMarketTotal = By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[1]/div[3]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[6]/div");
        By buyMarketFee = By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[1]/div[3]/div[2]/div/div[1]/div/div/div[3]/div[1]/div[7]/div");

        public bool BuyAndVerifyFilledOrdersTab(string instrument, string side, double size)
        {
            var flag = false;

            driver.Navigate().GoToUrl("https://apexwebqa.azurewebsites.net/exchange");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            UserFunctionality objUserFunctionality = new UserFunctionality(output);
            objUserFunctionality.LogIn();

            UserHomePage selectExchange = new UserHomePage(driver, output);
            selectExchange.SelectInstrumentFromExchange(instrument);

            GenericUtils gen = new GenericUtils(output);
            string buyAmountValue = gen.ConvertToDecimal(size);

            BuyOrderEntry boe = new BuyOrderEntry(driver, output);
            string buyMarketOrderTime = boe.PlaceMaketBuyOrder(0.07);
            string lastPrice = boe.GetLastPrice();
            double doubleLastPrice = Convert.ToDouble(lastPrice);
            string totalAmountCalculated = gen.FilledOrdersTotalAmount(size, doubleLastPrice);

            driver.FindElement(selectFilledOrdersTab).Click();

            string expectedRow = instrument + " || " + side + " || " + size + " || " + lastPrice + " || " + totalAmountCalculated + " || " + buyMarketOrderTime;
            output.WriteLine("expectedRow********* " + expectedRow);

            if (GetListOfFilledOrders().Contains(expectedRow))
            {
                output.WriteLine("Matched Expected -> " + expectedRow + " Actual -> ");
                flag = true;
            }
            return flag;

        }


        public ArrayList GetListOfFilledOrders()
        {
            ArrayList filledOrderList = new ArrayList();
            int countOfFilledOrders = driver.FindElements(By.XPath("//div[@class='flex-table__body order-history-table__body']/div")).Count;
            for (int i = 1; i <= countOfFilledOrders; i++)
            {
                String textFinal = "";
                int countItems = driver.FindElements(By.XPath("(//div[@class='flex-table__body order-history-table__body']/div)[" + i + "]/div")).Count;
                output.WriteLine("countItems ---- " + countItems);
                for (int j = 2; j <= (countItems); j++)
                {
                    String text = driver.FindElement(By.XPath("(//div[@class='flex-table__body order-history-table__body']/div)[" + i + "]/div[" + j + "]")).Text;
                    output.WriteLine("text ---- " + text);
                    if (j == 2)
                    {
                        textFinal = text;
                    }
                    else
                    {
                        if (j == 8)
                        {
                            continue;
                        }
                        textFinal = textFinal + " || " + text;
                    }

                }
                filledOrderList.Add(textFinal);
                output.WriteLine("Text FINAL---- " + textFinal);
            }
            return filledOrderList;
        }

        public ArrayList GetListOfOpenOrders()
        {
            ArrayList openOrderList = new ArrayList();
            int countOfOpenOrders = driver.FindElements(By.XPath("//div[@class='flex-table__body order-history-table__body']/div")).Count;
            for (int i = 1; i <= countOfOpenOrders; i++)
            {
                String textFinal = "";
                int countItems = driver.FindElements(By.XPath("(//div[@class='flex-table__body order-history-table__body']/div)[" + i + "]/div")).Count;
                output.WriteLine("countItems ---- " + countItems);
                for (int j = 2; j <= (countItems - 2); j++)
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

        public ArrayList GetListOfInactiveOrders()
        {
            ArrayList inactiveOrderList = new ArrayList();
            int countOfInactiveOrders = driver.FindElements(By.XPath("//div[@class='flex-table__body order-history-table__body']/div")).Count;
            for (int i = 1; i <= countOfInactiveOrders; i++)
            {
                String textFinal = "";
                int countItems = driver.FindElements(By.XPath("(//div[@class='flex-table__body order-history-table__body']/div)[" + i + "]/div")).Count;
                output.WriteLine("countItems ---- " + countItems);
                for (int j = 2; j <= (countItems - 2); j++)
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
                inactiveOrderList.Add(textFinal);
                output.WriteLine("Text FINAL---- " + textFinal);
            }
            return inactiveOrderList;
        }







        public ArrayList WaitForButtonDisable(String buttonTitle)
        {

            ArrayList dateTimeList = new ArrayList();

            String dateTime = "";
            String dateTimeMinusOne = "";
            for (int i = 0; i <= 100; i++)
            {

                String cssCursorValue = driver.FindElement(By.XPath("//button[text()='" + buttonTitle + "']")).GetCssValue("cursor");
                if (cssCursorValue.Equals("not-allowed"))
                {
                    dateTimeList.Add(dateTime);
                    dateTimeList.Add(dateTimeMinusOne);
                    break;
                }
                Thread.Sleep(100);
            }
            return dateTimeList;
        }

    }
}
