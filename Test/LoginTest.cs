using AlphaPoint_QA.Pages;
using AlphaPoint_QA.Utils;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AlphaPoint_QA.Test
{
    public class LoginTest
    {
        static string username;
        static string password;
        static ILog logger;
        private readonly ITestOutputHelper output;
        static Config data;
        public static IWebDriver driver;


        public LoginTest(ITestOutputHelper output)
        {
            this.output = output;
            logger = APLogger.GetLog();
            logger.Info("Test Started");


            data = ConfigManager.Instance;
            driver = AlphaPointWebDriver.driver;
        }

        [Fact]
        //[Trait("Category", "C1")]
        public void loginTest()
        {
            output.WriteLine("hIIIIIIIIIIIIII");
            driver.Navigate().GoToUrl("https://apexwebqa.azurewebsites.net/exchange");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            username = data.UserPortal.Users["User1"].UserName;
            password = data.UserPortal.Users["User1"].Password;

            LoginPage loginPage = new LoginPage(driver, output);
            loginPage.Login(username, password);




            //Logout();
        }


        public void Logout()
        {
            UserHomePage userHome = new UserHomePage(driver);
            userHome.Logout();
            driver.Close();
        }

    }
}
