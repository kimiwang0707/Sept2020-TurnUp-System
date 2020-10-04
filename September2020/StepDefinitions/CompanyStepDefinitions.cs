using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Helpers;
using September2020.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace September2020.StepDefinitions
{
    [Binding]
    public sealed class CompanyStepDefinitions
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



        [Given(@"I navigate to company page")]
        public void GivenINavigateToCompanyPage()
        {
            HomePage homePage = new HomePage();
            homePage.NavigateToCompany(driver);

        }


        [Given(@"I navigate to create company")]
        public void GivenINavigateToCreateCompany()
        {
            CompanyPage companyPage = new CompanyPage();
            companyPage.CreateCompany(driver);
        }


        [When(@"I input data using Company Name: (.*) and Contact: (.*) (.*) (.*) (.*) (.*)")]
        public void WhenIInputDataUsingCompanyNameAndContact(string companyName, string firstName, string lastName, int phone, int mobile, string email)
        {
            CompanyPage companyPage = new CompanyPage();
            companyPage.CreateCompanyWithName(driver, companyName, firstName, lastName, phone, mobile, email);
        }



        [Then(@"I am able to verify data with Company Name: (.*)")]
        public void ThenIAmAbleToVerifyDataWithCompanyName(string companyName)
        {

            CompanyPage companyPage = new CompanyPage();
            companyPage.VarifyByCompanyName(driver, companyName);
        }



        [When(@"I create company record using data table:")]
        public void WhenICreateCompanyRecordUsingDataTable(Table table)
        {
            var data = table;
            string companyName = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            var phone = string.Empty;
            var mobile = string.Empty;
            string email = string.Empty;

            CompanyPage companyPage = new CompanyPage();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                companyName = data.Rows[i]["companyName"];
                firstName = data.Rows[i]["firstName"];
                lastName = data.Rows[i]["lastName"];
                phone = data.Rows[i]["phone"];
                mobile = data.Rows[i]["mobile"];
                email = data.Rows[i]["email"];
                companyPage.CreateCompanyWithName(driver, companyName, firstName, lastName, int.Parse(phone), int.Parse(mobile), email);
                companyPage.VarifyByCompanyName(driver, companyName);
            
            }

        }






    }
}
