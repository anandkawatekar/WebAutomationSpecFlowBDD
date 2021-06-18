using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomationSpecFlow.Pages.Components;

namespace TestAutomationSpecFlow.Pages
{
    class MyAccountPage : MenuBar
    {
        public MyAccountPage(IWebDriver driver) : base(driver){  }

        public void WaitUntilLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, defaultTimeSpan);
            wait.Message = "My Account page not loaded";
            wait.Until((d) =>
            {
                return driver.Url.Contains("controller=my-account");
            });
        }

        public bool IsViwMyAccountMenuDisplayed()
        {
            return ViewMyAccountMenu.Displayed;
        }
    }
}
