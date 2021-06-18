using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TestAutomationSpecFlow.Pages.Components;

namespace TestAutomationSpecFlow.Pages
{
    public class HomePage : MenuBar
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Open(string baseUrl)
        {

            LoadPage(baseUrl);
        }
    }
}
