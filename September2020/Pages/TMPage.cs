using System;
using System.Threading;
using com.sun.org.apache.bcel.@internal.classfile;
using NUnit.Framework;
using OpenQA.Selenium;
using September2020.Helpers;

namespace September2020.Pages
{
    class TMPage
    {

        //***Test Create Time Record***

        public void CreateTM(IWebDriver driver)
        {
            try
            {
                // Click Create New
                Wait.WaitForElementClickable(driver, "XPath", "//*[@id='container']/p/a");
                IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                CreateNew.Click();

                // Click Time in dropdown menu
                Wait.WaitForElement(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]");
                IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
                TypeCode.Click();
                IWebElement Time = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
                Time.Click();

                // Write valid value in Code
                driver.FindElement(By.Id("Code")).SendKeys("12:30");

                // Write valid value in Description
                driver.FindElement(By.Id("Description")).SendKeys("You have assignment due.");

                //(*) Write valid value in Price per unit 
                driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("100");

                // Click Save 
                IWebElement Save = driver.FindElement(By.Id("SaveButton"));
                Save.Click();

                // Go to the last page
                // Because the data grid load more slowly than page switch bar, so use the data grid as the benchmark.
                Wait.WaitForElementVisibility(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 5);
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

                // Validate if the result is as expected
                Wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
                IWebElement expectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                IWebElement expectedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

                // Use assert to judge fail or pass in tests
                Assert.That(expectedCode.Text, Is.EqualTo("12:30"));
                Assert.That(expectedDescription.Text, Is.EqualTo("You have assignment due."));

            } catch (Exception ex)
            {
                Assert.Fail("Fail to create time & material", ex.Message);
            }
        }



        internal void VarifyRecordCreated(IWebDriver driver, string code)
        {
            try
            {
                // Go to the last page
                // Because the data grid load more slowly than page switch bar, so use the data grid as the benchmark.
                Wait.WaitForElementVisibility(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 5);
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();
            }
            catch (Exception e)
            {
                Assert.Fail("Fail to go to last page", e.Message);
            }

            // Validate if the result is as expected
            Wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
            IWebElement expectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement expectedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            // Use assert to judge fail or pass in tests
            Assert.That(expectedCode.Text, Is.EqualTo(code));

        }

 

        internal void CreateTMWithValues(IWebDriver driver, string code, string desc)
        {
            try
            {
                // Click Create New
                Wait.WaitForElementClickable(driver, "XPath", "//*[@id='container']/p/a");
                IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                CreateNew.Click();

                // Click Time in dropdown menu
                Wait.WaitForElement(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]");
                IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
                TypeCode.Click();
                IWebElement Time = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
                Time.Click();

                // Write valid value in Code
                driver.FindElement(By.Id("Code")).SendKeys(code);

                // Write valid value in Description
                driver.FindElement(By.Id("Description")).SendKeys(desc);

                //(*) Write valid value in Price per unit 
                driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("100");

                // Click Save 
                IWebElement Save = driver.FindElement(By.Id("SaveButton"));
                Save.Click();       

            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to create time & material", ex.Message);
            }

        }






        //***Test Edit Time Record***

        public void EditTM(IWebDriver driver)
        {
            try
            {
                // Choose one item to click edit
                Wait.WaitForElementClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]");
                IWebElement Edit1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
                Edit1.Click();

                // Modify the info
                Wait.WaitForElementVisibility(driver, "Id", "Code", 5);
                driver.FindElement(By.Id("Code")).Clear();
                driver.FindElement(By.Id("Code")).SendKeys("Eskimo 12:20");
                driver.FindElement(By.Id("Description")).Clear();
                driver.FindElement(By.Id("Description")).SendKeys("Eskimo is coming on Sept!");

                // Click Save
                driver.FindElement(By.Id("SaveButton")).Click();

                // Validate if the value is changed
                Wait.WaitForElementVisibility(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 8);
                IWebElement UpdatedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Use assert syntax to judge fail or pass in tests
                Assert.That(UpdatedCode.Text, Is.EqualTo("Eskimo 12:20"));
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to edit time & material", ex.Message);
            }

        }



        internal void NavigateToEdit(IWebDriver driver)
        {
            try
            {
                // Choose one item to click edit
                Wait.WaitForElementClickable(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]");
                IWebElement Edit1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
                Edit1.Click();

            }catch (Exception ex)
            {
                Assert.Fail("Fail to click Edit into Edit page", ex.Message);
            }

        }


        internal void EditTmWithCodeAndDesc(IWebDriver driver, string code, string desc)
        {
            try
            {
                // Modify the info
                Wait.WaitForElementVisibility(driver, "Id", "Code", 5);
                driver.FindElement(By.Id("Code")).Clear();
                driver.FindElement(By.Id("Code")).SendKeys(code);
                driver.FindElement(By.Id("Description")).Clear();
                driver.FindElement(By.Id("Description")).SendKeys(desc);

                // Click Save
                driver.FindElement(By.Id("SaveButton")).Click();

            }catch(Exception ex)
            {
                Assert.Fail("Fail to input the new data to edit", ex.Message);
            }
        }


        internal void VerifyRecordEdited(IWebDriver driver, string code)
        {
            try
            {
                // Validate if the value is edited
                Wait.WaitForElementVisibility(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 8);
                IWebElement UpdatedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Use assert syntax to judge fail or pass in tests
                Assert.That(UpdatedCode.Text, Is.EqualTo(code));

            }catch (Exception ex)
            {
                Assert.Fail("Fail to varify company is edited", ex.Message);
            }
        }



        //***Test Delete Time Record***

        public void DeleteTM(IWebDriver driver)
        {
            try
            {
                // Click one item to Delete
                Wait.WaitForElementVisibility(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 5);
                var CodeDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();

                // * Click Cancel to cancel Delete *
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Dismiss();

                // Validate if the record has been deleted
                Wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]");
                IWebElement ExpectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Use assert syntax to judge fail or pass in tests
                Assert.That(ExpectedCode.Text, Is.EqualTo(CodeDelete));



                // * Click OK to confirm to delete *

                // Check the next record below the target delete item
                Wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[2]/td[1]");
                var CodeDeleteNextRow = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[2]/td[1]")).Text;

                // Click Delete to delete the 1st record
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Accept();

                // Validate if ther record has been deleted
                // ***Cannot use wait after alert message
                Thread.Sleep(1500);
                IWebElement ExpectedFirstRowCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Use assert syntax to judge fail or pass in tests
                Assert.That(ExpectedFirstRowCode.Text, Is.EqualTo(CodeDeleteNextRow));

            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to delete Time & Material", ex.Message);
            }
        }



        internal void NavigateToDelete(IWebDriver driver)
        {
            try
            {
                // Click one item to Delete
                Wait.WaitForElementVisibility(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 5);
                string CodeDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;
                string CodeDeleteNextRow = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[2]/td[1]")).Text;
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();

            }catch (Exception ex)
            {
                Assert.Fail("Fail to click Delete", ex.Message);
            }

        }


        internal void CancelToDelete(IWebDriver driver)
        {
            try
            {
                // * Click Cancel to cancel Delete *
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to jump to pop up page to cancel", ex.Message);
            }
        }

        internal void VerifyCompanyNotDeleted(IWebDriver driver, string CodeDelete)
        {
            try
            {
                // Validate if the record has been deleted
                Wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]");
                IWebElement ExpectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Use assert syntax to judge fail or pass in tests
                Assert.That(ExpectedCode.Text, Is.EqualTo(CodeDelete));
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to verify company not deleted", ex.Message);
            }
        }


        internal void ConfirmToDelete(IWebDriver driver)
        {
            try
            {
                Wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[2]/td[1]");

                // Click Delete to delete the 1st record
                driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
                Thread.Sleep(500);
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to jump to pop up page to confirm", ex.Message);
            }
        }



        internal void VerifyCompanyIsDeleted(IWebDriver driver, string CodeDeleteNextRow)
        {
            try
            {
                // Validate if ther record has been deleted
                Thread.Sleep(1500);
                IWebElement ExpectedFirstRowCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Use assert syntax to judge fail or pass in tests
                Assert.That(ExpectedFirstRowCode.Text, Is.EqualTo(CodeDeleteNextRow));
            } catch (Exception ex)
            {
                Assert.Fail("Fail to verify company deleted", ex.Message);
            }
        }







    }
}
