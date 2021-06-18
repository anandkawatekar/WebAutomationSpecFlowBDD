using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAutomationSpecFlow.Pages
{
    public class AddressPage : BasePage
    {
        private By proceedToCheckoutButonElementId = By.Name("processAddress");

        public IWebElement ProceedToCheckoutButton => driver.FindElement(proceedToCheckoutButonElementId);

        public AddressPage(IWebDriver driver) : base(driver)
        {
        }

        public void ProceedToShippingPage()
        {
            ProceedToCheckoutButton.Click();
        }
    }
}
