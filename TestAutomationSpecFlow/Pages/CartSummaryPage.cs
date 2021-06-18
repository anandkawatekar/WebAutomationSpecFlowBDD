using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TestAutomationSpecFlow.Pages.Components;

namespace TestAutomationSpecFlow.Pages
{
    public class CartSummaryPage : BasePage
    {
        private By proceedToCheckoutButonElementId = By.XPath("//a[contains(@class,'standard-checkout')]");

        public IWebElement ProceedToCheckoutButton => driver.FindElement(proceedToCheckoutButonElementId);

        public CartSummaryPage(IWebDriver driver) : base(driver)
        {
        }

        public void ProceedToSignIn()
        {
            ProceedToCheckoutButton.Click();
        }
    }
}
