using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace September2020.Pages
{
    class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            // GitHub Test!
            //Lauch browser and enter the URL
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");


            //Maximize web browser (This step bases on actual situation)
            driver.Manage().Window.Maximize();

            // Identify username textbox and enter username
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            // Identify password textbox and enter password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            // Identify login button and click login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            try
            {
                // Validate if the user is logged in succesfully
                IWebElement hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

                // Use assert syntax to judge if the program fail or pass
                Assert.That(hellohari.Text, Is.EqualTo("Hello hari!"));
            }
            catch(Exception ex)
            {
                Assert.Fail("Test failed at login step!", ex.Message);
            }
        }
    }
}
