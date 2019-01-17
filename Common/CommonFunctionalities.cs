using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AlphaPoint_QA.Common
{
    class CommonFunctionalities
    {
        //public static WebDriverWait wait;

        // public static IWebDriver driver;
        //public static string siteURL = "https://apexwebqa.azurewebsites.net/login";
        //public static string adminURL = "https://apexqa2.azurewebsites.net/admin/";
        //public static string _userName = "dhirender";
        //public static string _passWord = "1234";
        //public static Actions action;

        static By userName = By.XPath("//input[@name='username']");
        static By passWord = By.XPath("//input[@name='password']");
        static By loginInButton = By.XPath("//button[text()='Log In']");
        static By selectServerfromList = By.XPath("//select[@name='tradingServer']");
        static By dashBoardMenu = By.XPath("//div[@class='page-header-nav__menu-toggle']");
        static By selectExchangeLink = By.XPath("//a[@href='/exchange']");
        static By marketOrderTypeButton = By.XPath("//label[@data-test='Market Order Type']");
        static By limitOrderTypeButton = By.XPath("//label[@data-test='Limit Order Type']");
        static By stopOrderTypeButton = By.XPath("//label[@data-test='Stop Order Type']");
        static By buySideButtonUnderOrderEntry = By.XPath("//label[@data-test='Buy Side']");
        static By sellSideButtonUnderOrderEntry = By.XPath("//label[@data-test='Sell Side']");
        static By buyAmountTextField = By.XPath("//input[@data-test='Buy Amount']");
        static By sellAmountTextField = By.XPath("//input[@data-test='Sell Amount']");
        static By selectingAnOrder = By.XPath("//div[@data-test='Order Entry']");
        static By userLogoButton = By.XPath("//button[contains(@class,'user-summary__popover-menu-trigger')]");
        static By signOutButton = By.XPath("//a[contains(@class,'popover-menu__item user-summary')]");
        static By advanceOrderButton = By.XPath("//div[text()='« Advanced Orders']");
        static By adminUsername = By.XPath("//input[@placeholder='Username']");
        static By adminPassword = By.XPath("//input[@placeholder='Password']");
        static By adminLoginButton = By.XPath("//button[@id='login-btn']");
        static By openUserMenu = By.XPath("//button[@id='OpenUserMenu']");
        static By adminSignOut = By.XPath("//*[@id='SignOut']/div/div/div");
        static By adminUsertext = By.XPath("//span[text()='Users']");
        static By buyAndSell = By.XPath("//a[@href='/buy-sell']");
        static By userSetting = By.XPath("//a[@href='/settings/profile']");
        static By wallets = By.XPath("//a[@href='/wallets']");

        static By selectExchange = By.XPath("//*[@id='root']/div[1]/div[1]/div[2]/a[2]");
        static By clinkOnInstrument = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/button");
        static By selectInstrumentDASCUSD = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div[1]");
        static By selectInstrumentBTCUSD = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div[2]");
        static By selectInstrumentETHCUSD = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div[3]");
        static By selectInstrumentLTCUSD = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div[4]");
        static By selectInstrumentLTCBTC = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div[5]");
        static By selectInstrumentBTCEUR = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div[6]");
        static By selectInstrumentFUELBTC = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div[7]");
        static By selectInstrumentETHBTC = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div[8]");
        static By getInstrumentName = By.XPath("//*[@id='root']/div[1]/div[2]/div[1]/div[1]/button/span[1]");

        static By balanceAmountInWallet = By.XPath("//div[@class='wallet-card__amount']//span");
        static By dashBoardMenuListItems = By.XPath("//a[contains(@class,'page-header-nav__item page-header-nav__item--hoverable')]");

        static By stopButtonUnderOrderEntry = By.XPath("//label[@data-test='Stop Order Type']");
        static By placeBuyOrderButton = By.XPath("//button[text()='Place Buy Order']");


        public static string StoreBalanceAmountFromWallet(IWebDriver driver)
        {
            IWebElement balance = driver.FindElement(balanceAmountInWallet);
            return balance.Text;

        }

        //Click On "Place Buy Order" under BuyMarket will be execute by using below method.
        public static void PlaceMarketBuyOrder(IWebDriver driver)
        {
            driver.FindElement(placeBuyOrderButton).Click();
        }
        public static void MarketOrderUnderBuy(IWebDriver driver)
        {
            driver.FindElement(marketOrderTypeButton).Click();
        }


        ////Below method is use to perform browser open.
        //public static void BrowserOpening(IWebDriver driver)
        //{
        //    driver = new ChromeDriver("E:\\Software\\Webdriver\\New Version");
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl(siteURL);
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        //    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        //}

        //Below method is use to select the Server name.
        public static void SelectServer(IWebDriver driver)
        {
            SelectElement sel = new SelectElement(driver.FindElement(selectServerfromList));
            sel.SelectByText("wss://apiapexqa2.alphapoint.com/WSGateway/");
        }

        //Below method is use to perform Login function.
        //public static void UserLogin(IWebDriver driver)
        //{
        //    driver.FindElement(userName).SendKeys(_userName);
        //    driver.FindElement(passWord).SendKeys(_passWord);
        //    driver.FindElement(loginInButton).Click();
        //}

        //Below method is use to click on DashBoard button.
        public static void DashBoardMenuButton(IWebDriver driver)
        {
            driver.FindElement(dashBoardMenu).Click();
        }

        //Below method is use select an Exchange.
        public static void SelectAnExchange(IWebDriver driver)
        {
            driver.FindElement(selectExchangeLink).Click();
        }

        //This method Navigates to Exchange selects the Instrument
        public static void SelectInstrumentFromExchange(string instrument, IWebDriver driver)
        {
            driver.FindElement(selectExchangeLink).Click();
            driver.FindElement(clinkOnInstrument).Click();
            if (instrument.Equals("DASCUSD"))
            {
                try
                {
                    driver.FindElement(selectInstrumentDASCUSD).Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    driver.FindElement(selectInstrumentDASCUSD).Click();
                    Console.WriteLine(ex.InnerException);
                }
            }
            else if (instrument.Equals("BTCUSD"))
            {
                try
                {
                    driver.FindElement(selectInstrumentBTCUSD).Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    driver.FindElement(selectInstrumentBTCUSD).Click();
                    Console.WriteLine(ex.InnerException);
                }
            }
            else if (instrument.Equals("ETHCUSD"))
            {
                try
                {
                    driver.FindElement(selectInstrumentETHCUSD).Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    driver.FindElement(selectInstrumentETHCUSD).Click();
                    Console.WriteLine(ex.InnerException);
                }

            }
            else if (instrument.Equals("LTCUSD"))
            {
                try
                {
                    driver.FindElement(selectInstrumentLTCUSD).Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    driver.FindElement(selectInstrumentLTCUSD).Click();
                    Console.WriteLine(ex.InnerException);
                }
            }
            else if (instrument.Equals("LTCBTC"))
            {
                try
                {
                    driver.FindElement(selectInstrumentLTCBTC).Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    driver.FindElement(selectInstrumentLTCBTC).Click();
                    Console.WriteLine(ex.InnerException);
                }
            }
            else if (instrument.Equals("BTCEUR"))
            {
                try
                {
                    driver.FindElement(selectInstrumentBTCEUR).Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    driver.FindElement(selectInstrumentBTCEUR).Click();
                    Console.WriteLine(ex.InnerException);
                }
            }
            else if (instrument.Equals("FUELBTC"))
            {
                try
                {
                    driver.FindElement(selectInstrumentFUELBTC).Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    driver.FindElement(selectInstrumentFUELBTC).Click();
                    Console.WriteLine(ex.InnerException);
                }
            }
            else if (instrument.Equals("ETHBTC"))
            {
                try
                {
                    driver.FindElement(selectInstrumentETHBTC).Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    driver.FindElement(selectInstrumentETHBTC).Click();
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        


        //Below method will click on "Buy & Sell" from Dashboard menu
        public static void NavigateBuySell(IWebDriver driver)
        {
            driver.FindElement(buyAndSell).Click();
        }

        //Below method will click on "User Settings" from Dashboard menu
        public static void NavigateUserSetting(IWebDriver driver)
        {
            driver.FindElement(userSetting).Click();
        }

        //Below method will click on "Wallets" from Dashboard menu
        public static void ClickWallets(IWebDriver driver)
        {
            driver.FindElement(wallets).Click();
        }

        //Below method will click on "LogOut" in the page
        public static void LogOut(IWebDriver driver)
        {
            driver.FindElement(userLogoButton).Click();
            driver.FindElement(signOutButton).Click();
        }

        //Below method will click on "Order Entry" button under Buy option in the page
        public static void SelectAnOrder(IWebDriver driver)
        {
            driver.FindElement(selectingAnOrder).Click();
        }

        //Below method will click on "Advance Order" button under Buy option in the page
        public static void AdvanceOrder(IWebDriver driver)
        {
            driver.FindElement(advanceOrderButton).Click();
        }

        //Below method will click on "Sell" button under "Order Entry" option in the page
        public static void ExchangeOrderSell(IWebDriver driver)
        {
            driver.FindElement(sellSideButtonUnderOrderEntry).Click();
        }

        //Below method will click on "Buy" button under "Order Entry" option in the page
        public static void ExchangeOrderBuy(IWebDriver driver)
        {
            driver.FindElement(buySideButtonUnderOrderEntry).Click();
        }

        //Below method will click on "Stop" button under "Order Entry" option in the page
        public static void SelectAnStopUnderOrderEntry(IWebDriver driver)
        {
            driver.FindElement(stopButtonUnderOrderEntry).Click();
        }
        //Below method will close the Browser
        public static void CloseBrowser(IWebDriver driver)
        {
            driver.Close();
        }

        public static void ClickOnLimitOrderTypeUnderBuy(IWebDriver driver)
        {
            driver.FindElement(limitOrderTypeButton).Click();
        }

        //Below method is use to Admin Login
        //public static void AdminLogin(IWebDriver driver)
        //{
        //    driver = new ChromeDriver("E:\\Software\\Webdriver\\New Version");
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl(adminURL);
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        //    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        //    driver.FindElement(adminUsername).SendKeys(_userName);
        //    driver.FindElement(adminPassword).SendKeys(_passWord);
        //    driver.FindElement(adminLoginButton).Click();
        //}

        //Below method is used to logout from the Admin Portal
        public static void AdminLogOut(IWebDriver driver)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.FindElement(openUserMenu).Click();
            Thread.Sleep(3000);
            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            //wait.Until(ExpectedConditions.ElementIsVisible(AdminSignOut));
            Thread.Sleep(3000);
            driver.FindElement(adminSignOut).Click();
            Thread.Sleep(3000);
        }

        public static Dictionary<string, string> StoreMarketAmountBalances(IWebDriver driver)
        {
            string marketPrice = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[1]/span")).Text;
            string fees = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[2]/span")).Text;

            string orderTotal = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[3]/span")).Text;

            string net = driver.FindElement(By.XPath("//*[@id='root']/div[1]/div[2]/div[2]/div[4]/div/div[2]/div/form/div[2]/div[3]/div[4]/span")).Text;

            Dictionary<string, string> amountDetailsList = new Dictionary<string, string>();
            amountDetailsList.Add("Market Price", marketPrice);
            amountDetailsList.Add("Fees", fees);
            amountDetailsList.Add("Order Total", orderTotal);
            amountDetailsList.Add("Net", net);

            /*
            foreach (KeyValuePair<string, string> amount in amountDetailsList)
            {
                output.WriteLine("Key: {0}, Value: {1}", amount.Key, amount.Value);
            }
            */
            return amountDetailsList;
        }
    }
}

