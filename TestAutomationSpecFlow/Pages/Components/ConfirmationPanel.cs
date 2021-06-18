using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAutomationSpecFlow.Pages.Components
{
    public class ConfirmationPanel : BasePage
    {
        private By confirmationPanelElementId = By.Id("layer_cart");
        private By proceedToCheckoutButonElementId = By.XPath("//div[@class='button-container']/a");
        private By productNameElementId = By.Id("layer_cart_product_title");

        public IWebElement Panel => driver.FindElement(confirmationPanelElementId);
        public IWebElement ProceedToCheckoutButton => driver.FindElement(proceedToCheckoutButonElementId);
        public IWebElement ProductName => driver.FindElement(productNameElementId);

        public ConfirmationPanel(IWebDriver driver) : base(driver)
        {
        }

        public bool IsDisplayed()
        {
            return Panel.Displayed;
        }

        public string GetProductName()
        {
            return ProductName.Text.Trim();
        }

        public void WaitForPanelToDisplay()
        {
            WaitForElementIsVisible(confirmationPanelElementId);
        }

        public void ClickProceedToCheckout()
        {
            ProceedToCheckoutButton.Click();
        }
    }
}
