using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAutomationSpecFlow.Pages.Components
{
    public class Product : BasePage
    {
        private By productRootId = By.XPath("//tr[contains(@id,'product_')]");
        private By productNameElementId = By.XPath(".//p[@class='product-name']");
        private By productUnitPriceElementId = By.XPath(".//td[@class='cart_unit']/span/span");
        

        private IWebElement Root { get; }
        public IWebElement ProductName => Root.FindElement(productNameElementId);
        public IWebElement ProductUnitPrice => Root.FindElement(productUnitPriceElementId);

        public Product(IWebDriver driver,string productId) : base(driver)
        {
            By productRootId = By.XPath($"//tr[contains(@id,'product_{productId}')]");

            Root = driver.FindElement(productRootId);
        }

        public string GetProductName()
        {
            return ProductName.Text.Trim();
        }

        public decimal GetProductUnitPrice()
        {
            return Convert.ToDecimal(ProductUnitPrice.Text.Replace('$',' ').Trim());
        }
    }
}
