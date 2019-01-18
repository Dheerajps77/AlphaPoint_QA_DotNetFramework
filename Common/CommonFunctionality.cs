using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AlphaPoint_QA.Common
{
    class CommonFunctionality
    {
        //public static WebDriverWait wait;

        // public static IWebDriver driver;
        //public static string siteURL = "https://apexwebqa.azurewebsites.net/login";
        //public static string adminURL = "https://apexqa2.azurewebsites.net/admin/";
        //public static string _userName = "dhirender";
        //public static string _passWord = "1234";
        //public static Actions action;


        static IJavaScriptExecutor js;

        
        static By dashBoardMenu = By.XPath("//div[@class='page-header-nav__menu-toggle']");
        static By selectExchangeLink = By.XPath("//a[@href='/exchange']");
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

        static By signOutButton = By.XPath("//a[contains(@class,'popover-menu__item user-summary')]");
        static By userLogoButton = By.XPath("//button[contains(@class,'user-summary__popover-menu-trigger')]");
        static By balanceAmountInWallet = By.XPath("//div[@class='wallet-card__amount']//span");
        static By dashBoardMenuListItems = By.XPath("//a[contains(@class,'page-header-nav__item page-header-nav__item--hoverable')]");
     

        static By openOrder = By.XPath("//div[@class='ap-tab__menu order-history__menu']//div[@data-test='Open Orders']");
        static By filledOrder = By.XPath("//div[@class='ap-tab__menu order-history__menu']//div[@data-test='Filled Orders']");
        static By inactiveOrder = By.XPath("//div[@class='ap-tab__menu order-history__menu']//div[@data-test='Inactive Orders']");
        static By tradeOrder = By.XPath("//div[@class='ap-tab__menu order-history__menu']//div[@data-test='Trade Orders']");
        static By depositOrder = By.XPath("//div[@class='ap-tab__menu order-history__menu']//div[@data-test='Deposit Orders']");
        static By withdrawOrder = By.XPath("//div[@class='ap-tab__menu order-history__menu']//div[@data-test='Withdraw Orders']");

        //This method will click on Open Order Tab
        public static void OpenOrderTab(IWebDriver driver)
        {
            driver.FindElement(openOrder).Click();
        }

        //This method will click on filled Order Tab
        public static void FilledOrderTab(IWebDriver driver)
        {
            driver.FindElement(filledOrder).Click();
        }

        //This method will click on inactive Order Tab
        public static void inactiveTab(IWebDriver driver)
        {
            driver.FindElement(inactiveOrder).Click();
        }

        //This method will click on trade Order Tab
        public static void tradeTab(IWebDriver driver)
        {
            driver.FindElement(tradeOrder).Click();
        }

        //This method will click on deposit Order Tab
        public static void DepositTab(IWebDriver driver)
        {
            driver.FindElement(depositOrder).Click();
        }

        //This method will click on withdraw Order Tab
        public static void WithdrawTab(IWebDriver driver)
        {
            driver.FindElement(withdrawOrder).Click();
        }

      

        //Below method will scroll to down till pixel defined by user
        public static void ScrollingDownVertical(IWebDriver driver)
        {
            js=(IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 300)");
        }

        //Below method scroll to up till pixel defined by user
        public static void ScrollingUpVertical(IWebDriver driver)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, -600)");
        }

        public static void ScrollingRightHorizontally(IWebDriver driver)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(500, 0)");
        }

        //Below method scroll to up till pixel defined by user
        public static void ScrollingLeftHorizontally(IWebDriver driver)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(-500, 0)");
        }

        //Below method scroll to particular webElement
        public static void ScrollingToParticularElement(IWebDriver driver, IWebElement iwebElement)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", iwebElement);
        }

        //Below method scroll till Particular Coordinates
        public static void ScrollingToParticularCoordinates(IWebDriver driver)
        {
            js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(200,300)");
        }

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

     
      
        //Below method will close the Browser
        public static void CloseBrowser(IWebDriver driver)
        {
            driver.Close();
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

            /*
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
        */
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

