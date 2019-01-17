using AlphaPoint_QA.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AlphaPoint_QA.Test
{
    public class BaseTest
    {
        private static IWebDriver driver;

        public static void BeforeSuite()
        {
            var os = Environment.OSVersion;
            var env = ConfigManager.GetAppSetting("PRODUCT_URL");

            string path = @"C:\Users\akash.goel\source\repos\AlphaPoint_QA\AlphaPoint_QA\bin\Debug\netcoreapp2.0";
            driver = new ChromeDriver(path);
            driver.Url = env.ToString();

            //if (os.ToString().ToLower().Contains("linux"))
            //{
            //    driver = GetLinuxDriver();
            //}
            //else if (os.ToString().ToLower().Contains("window"))
            //{
            //    driver = GetWindowDriver();
            //}
            //else
            //{
            //    Console.WriteLine("Invalid OS");
            //}

            //RemoteWebDriver rs = new RemoteWebDriver()

            //if (Environment.OSVersion.Platform)
            //{
            //    driver = getLinuxDriver();
            //}
            //else if (System.getProperty("os.name").contains("Windows"))
            //{
            //    driver = getWindowsDriver();
            //}
            //else
            //{
            //    Console.WriteLine("Invalid OS");
            //}

                //cap = ((RemoteWebDriver)driver).Capabilities;

                //driver.Manage().Window.Maximize();
                //driver.Manage().Timeouts().ImplicitWait(WAIT_SECONDS, TimeUnit.SECONDS);
                //driver.get(ENVIRONMENT);
        }

        public static void AfterSuite()
        {

        }   

        private IWebDriver GetDriver(string platformType)
        {

            return driver;
        }

        
    }

    
}
