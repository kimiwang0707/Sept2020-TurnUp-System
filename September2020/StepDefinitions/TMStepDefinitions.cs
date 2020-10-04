using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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



        [Given(@"I navigate to create new function")]
        public void GivenINavigateToCreateNewFunction()
        {
            TMPage tmPage = new TMPage();
            tmPage.CreateTM(driver);
        }



        [When(@"I input data using code: (.*) and description: (.*)")]
        public void WhenIInputDataUsingCodeAndDesc(string code, string desc)
        {
            TMPage tmPage = new TMPage();
            tmPage.CreateTMWithValues(driver, code, desc);

        }


        [Then(@"I am able to verify data with code: (.*)")]
        public void ThenIAmAbleToVerifyDataWithCode(string code)
        {
            TMPage tmPage = new TMPage();
            tmPage.VarifyRecordCreated(driver, code);
        
        }



        [When(@"I input data using values from table:")]
        public void WhenIInputDataUsingValuesFromTable(Table table)
        {
            var code = string.Empty;
            var desc = string.Empty;
            var data = table;
            TMPage tmPage = new TMPage();

            for (var i = 0; i < data.Rows.Count; i++)
            {
                code = data.Rows[i]["code"];
                desc = data.Rows[i]["desc"];
                tmPage.CreateTMWithValues(driver, code, desc);
                tmPage.VarifyRecordCreated(driver, code);
            }

            //data.Rows[0].items[0];    // code
            //data.Rows[0].items[1];    // desc

        }




// ******* EDIT COMPANY*******
        [Given(@"I navigate to edit")]
        public void GivenINavigateToEdit()
        {
            TMPage tmPage = new TMPage();
            tmPage.NavigateToEdit(driver);

        }


        [When(@"I input new data with code: (.*) and desc:(.*)")]
        public void WhenIInputNewDataWithCodeAndDesc(string code, string desc)
        {
            TMPage tmPage = new TMPage();
            tmPage.EditTmWithCodeAndDesc(driver, code, desc);
        }


    
        [Then(@"I am able to verify the edited record with code: (.*)")]
        public void ThenIAmAbleToVerifyTheEditedRecordWithCode(string code)
        {
            TMPage tmPage = new TMPage();
            tmPage.VerifyRecordEdited(driver, code);
        }





 // ******* DELETE COMPANY*******

        [Given(@"I navigate to delete TM")]
        public void GivenINavigateToDeleteTM()
        {
            TMPage tmPage = new TMPage();
            tmPage.NavigateToDelete(driver);
        }

        [When(@"I cancel to delete TM")]
        public void WhenICancelToDeleteTM()
        {
            TMPage tmPage = new TMPage();
            tmPage.CancelToDelete(driver);
        }



        [Then(@"I am able to verify the data is not deleted")]
        public void ThenIAmAbleToVerifyTheDataIsNotDeleted(string CodeDelete)
        {
            TMPage tmPage = new TMPage();
            tmPage.VerifyCompanyNotDeleted(driver, CodeDelete);
        }



        [When(@"I confirm to delete TM")]
        public void WhenIConfirmToDeleteTM()
        {
            TMPage tmPage = new TMPage();
            tmPage.ConfirmToDelete(driver);
        }


        [Then(@"I am able to verify the data is deleted")]
        public void ThenIAmAbleToVerifyTheDataIsDeleted(string CodeDeleteNextRow)
        {
            TMPage tmPage = new TMPage();
            tmPage.VerifyCompanyIsDeleted(driver, CodeDeleteNextRow);
        }






    }

}
