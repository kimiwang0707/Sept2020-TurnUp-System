using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace September2020.Helpers
{
    class Wait
    {
        // Write wait syntax for Element EXIST condition.
        public static void WaitForElement(IWebDriver driver, string key, string value)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

                if (key == "XPath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(value)));
                }
                if (key == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(value)));
                }
                if (key == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(value)));
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to wait for the element", ex.Message);
            }
        }



        // Write wait syntax for Element VISIBLE condition (Can set waiting time in this constructor)
        public static void WaitForElementVisibility(IWebDriver driver, string key, string value, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

                if (key == "XPath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(value)));
                }

                if (key == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(value)));
                }

                if (key == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(value)));
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Element failed to be visible.", ex.Message);
            }

        }


        // Write wait syntax for Element CLICKABLE condition
        public static void WaitForElementClickable(IWebDriver driver, string key, string value)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            try
            {
                if (key == "XPath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(value)));
                }
                if (key == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(value)));
                }
                if (key == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(value)));
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Element failed to be clickable!", ex.Message);
            }
        }

    }
}
