using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace September2020.StepDefinitions
{
    [Binding]
    public sealed class TMStepDefinitions
    {
        IWebDriver driver;

        [BeforeScenario]
        public void LoginTurnUp()
        {
            //Initiate and define webdriver
            driver = new ChromeDriver();
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);
        }

        [AfterScenario]
        public void Dispose()
        {
            driver.Dispose();
        }


        [Given(@"I navigate to the TM")]
        public void GivenINavigateToTheTM()
        {
            var homePage = new HomePage();
            homePage.NavigateToTM(driver);
        }


    }
}
