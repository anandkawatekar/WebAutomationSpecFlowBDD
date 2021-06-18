using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using TestAutomationSpecFlow.Pages.Components;

namespace TestAutomationSpecFlow.Pages
{
    public class ProductDetailsPage : BasePage
    {
        private By addToCartButtonElementId = By.Name("Submit");

        public IWebElement AddToCartButton => driver.FindElement(addToCartButtonElementId);

        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public void Open(string baseUrl,string productId)
        {

            LoadPage(baseUrl+ $"?id_product={productId}&controller=product");
        }

        public void AddProductToCart()
        {
            AddToCartButton.Click();
        }

        public void ProceedToCheckout()
        {
            ConfirmationPanel confirmationPanel = new ConfirmationPanel(driver);
            confirmationPanel.WaitForPanelToDisplay();
            confirmationPanel.ClickProceedToCheckout();
        }

        public bool IsConfirmationPanelDisplayed()
        {
            ConfirmationPanel confirmationPanel = new ConfirmationPanel(driver);
            return confirmationPanel.IsDisplayed();
        }
    }
}
