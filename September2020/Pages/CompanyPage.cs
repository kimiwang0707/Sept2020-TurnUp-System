using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using September2020.Helpers;

namespace September2020.Pages
{
    class CompanyPage
    {

        // *** Create  company record ***
        public void CreateCompany(IWebDriver driver)
        {
            try
            {
                //Click Create New
                Wait.WaitForElement(driver, "XPath", "//*[@id='container']/p/a");
                driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

                //Input name
                Wait.WaitForElement(driver, "Id", "Name");
                IWebElement Name = driver.FindElement(By.Id("Name"));
                Name.SendKeys("Super Star Company");

                // Click Edit to input contact
                driver.FindElement(By.Id("EditContactButton")).Click();
                Thread.Sleep(500);

                // Switch to popup window
                IWebElement iframe = driver.FindElement(By.ClassName("k-content-frame"));
                driver.SwitchTo().Frame(iframe);

                // Input data
                Wait.WaitForElement(driver, "Id", "FirstName");
                driver.FindElement(By.Id("FirstName")).SendKeys("Taylor");
                driver.FindElement(By.Id("LastName")).SendKeys("Swift");
                driver.FindElement(By.Id("PreferedName")).SendKeys("Taytay");
                driver.FindElement(By.Id("Phone")).SendKeys("911");
                driver.FindElement(By.Id("Mobile")).SendKeys("110");
                driver.FindElement(By.Id("email")).SendKeys("taylorswift@gmail.com");
                driver.FindElement(By.Id("autocomplete")).SendKeys("test address");
                driver.FindElement(By.Id("Street")).SendKeys("Taiping Street");
                driver.FindElement(By.Id("City")).SendKeys("Auckland");
                driver.FindElement(By.Id("Postcode")).SendKeys("1055");
                driver.FindElement(By.Id("Country")).SendKeys("New Zealand");

                // Click Save Contact to create new record
                driver.FindElement(By.Id("submitButton")).Click();

                // Return default main window
                driver.SwitchTo().DefaultContent();

                // Save button
                Wait.WaitForElement(driver, "Id", "SaveButton");
                driver.FindElement(By.Id("SaveButton")).Click();

                //Scroll to bottom

                // Go to last page
                Wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[4]/a[4]/span");
                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]/span")).Click();

                // validate if the company record is added to the list
                Wait.WaitForElementVisibility(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);
                IWebElement lastItem = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

                //Use Assert syntax to judge fail or pass
                Assert.That(lastItem.Text, Is.EqualTo("Super Star Company"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to create company", ex.Message);
            }
        }



        internal void VarifyByCompanyName(IWebDriver driver, string companyName)
        {
            try { 

            // Go to last page
            Wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[4]/a[4]/span");
            driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]/span")).Click();

            // validate if the company record is added to the list
            Wait.WaitForElementVisibility(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);
            IWebElement lastItem = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //Use Assert syntax to judge fail or pass
            Assert.That(lastItem.Text, Is.EqualTo(companyName));
        }
            catch (Exception ex)
            {
                Assert.Fail("Fail to create company", ex.Message);
            }

        }




        internal void CreateCompanyWithName(IWebDriver driver, string companyName, string firstName, string lastName, int phone, int mobile, string email)
        {
            try
            {
                //Click Create New
                Wait.WaitForElement(driver, "XPath", "//*[@id='container']/p/a");
                driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

                //Input name
                Wait.WaitForElement(driver, "Id", "Name");
                IWebElement Name = driver.FindElement(By.Id("Name"));
                Name.SendKeys(companyName);

                // Click Edit to input contact
                driver.FindElement(By.Id("EditContactButton")).Click();
                Thread.Sleep(500);

                // Switch to popup window
                IWebElement iframe = driver.FindElement(By.ClassName("k-content-frame"));
                driver.SwitchTo().Frame(iframe);

                // Input data
                Wait.WaitForElement(driver, "Id", "FirstName");
                driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
                driver.FindElement(By.Id("LastName")).SendKeys(lastName);
                driver.FindElement(By.Id("Phone")).SendKeys(phone.ToString());
                driver.FindElement(By.Id("Mobile")).SendKeys(mobile.ToString());
                driver.FindElement(By.Id("email")).SendKeys(email);

                // Click Save Contact to create new record
                driver.FindElement(By.Id("submitButton")).Click();

                // Return default main window
                driver.SwitchTo().DefaultContent();

                // Save button
                Wait.WaitForElement(driver, "Id", "SaveButton");
                driver.FindElement(By.Id("SaveButton")).Click();
            }
            catch (Exception exc)
            { Assert.Fail("Fail to create new company", exc.Message); }

        }




        // *** Edit company record ***
        public void EditCompany(IWebDriver driver)
        {
            try
            {
                // Click the 1st row item to edit
                Wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[1]");
                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[1]")).Click();

                // Input new data
                Wait.WaitForElement(driver, "Id", "Name");
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys("Donald Trump");

                // Click Save Company
                Wait.WaitForElement(driver, "Id", "SaveButton");
                driver.FindElement(By.Id("SaveButton")).Click();

                // Validate if the item was updated
                Wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]");
                IWebElement FirstRowName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                //Use Assert syntax to judge fail or pass
                Assert.That(FirstRowName.Text, Is.EqualTo("Donald Trump"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to edit company", ex.Message);
            }
        }



        // *** Delete company record ***
        public void DeleteCompany(IWebDriver driver)
        {
            try
            {
                // * Validate the alert window with cancel operation *
                // Record the 1st row item
                Wait.WaitForElementClickable(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[2]");
                IWebElement FirstItemName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Click the 1st item to delete
                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[2]")).Click();

                // Click cancel
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Dismiss();

                // Locate the item deleted
                Thread.Sleep(1500);
                IWebElement deleteItem = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Use assert syntax to judge if pass of fail
                Assert.That(deleteItem.Text, Is.EqualTo(FirstItemName.Text));


                // * Validate the alert window with OK to delete *

                // Recond second row data
                Wait.WaitForElementClickable(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[2]");
                var SecondItemName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[2]/td[1]")).Text;

                // click delete again
                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[2]")).Click();

                // click OK to delete
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Accept();

                // Validate if the second row was moved to first row
                // Should use sleep here, because after popup close, the instant of the page is still previous which item hasn't been deleted.
                Thread.Sleep(1500);
                var FirstItemName1 = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;

                Assert.That(FirstItemName1, Is.EqualTo(SecondItemName));             

            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to delete company", ex.Message);
            }

        }


    }
}
