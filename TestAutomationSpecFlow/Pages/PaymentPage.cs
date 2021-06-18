using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TestAutomationSpecFlow.Pages.Components;

namespace TestAutomationSpecFlow.Pages
{
    public class PaymentPage : BasePage
    {
        private By proceedToCheckoutButonElementId = By.Name("processCarrier");
        private By termsOfServiceCheckBoxElementId = By.Id("cgv");

        public IWebElement ProceedToCheckoutButton => driver.FindElement(proceedToCheckoutButonElementId);
        public IWebElement TermsOfSeviceCheckBox => driver.FindElement(termsOfServiceCheckBoxElementId);

        public PaymentPage(IWebDriver driver) : base(driver)
        {
        }

        public bool ValidateProductDetails(string productId, string productName, decimal productPrice)
        {
            Product product = new Product(driver, productId);
            return (product.GetProductName().Equals(productName) && product.GetProductUnitPrice().Equals(productPrice));
        }
    }
}
