using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAutomationSpecFlow.Pages
{
    public class ShippingPage : BasePage
    {
        private By proceedToCheckoutButonElementId = By.Name("processCarrier");
        private By termsOfServiceCheckBoxElementId = By.Id("cgv");

        public IWebElement ProceedToCheckoutButton => driver.FindElement(proceedToCheckoutButonElementId);
        public IWebElement TermsOfSeviceCheckBox => driver.FindElement(termsOfServiceCheckBoxElementId);

        public ShippingPage(IWebDriver driver) : base(driver)
        {
        }

        public void ProceedToPaymentPage()
        {
            ProceedToCheckoutButton.Click();
        }

        public void ClickTermsOfService()
        {
            TermsOfSeviceCheckBox.Click();
        }
    }
}
