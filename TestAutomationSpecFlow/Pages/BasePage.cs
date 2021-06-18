using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationSpecFlow.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        protected readonly TimeSpan defaultTimeSpan = TimeSpan.FromSeconds(20);

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LoadPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool WaitForElementIsVisible(By id)
        {
            WebDriverWait wait = new WebDriverWait(driver, defaultTimeSpan);

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(id));

            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
            return true;

        }
    }
}
