using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Pages;

namespace September2020.Helpers
{
    public class CommonDriver
    {
        // Then other class can call the element directly
        public static IWebDriver driver;

        // Set OneTimeSetUp to allow login operation only once
        [OneTimeSetUp]
        public void LoginTurnUp()
        {
            //Initiate and define webdriver
            driver = new ChromeDriver();
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);
        }

        // Set OneTimeTearDown to allow quit operation only once
        [OneTimeTearDown]
        public void TestClosure()
        {
            //close instance of open chrome driver
            driver.Quit();

        }




    }
}
