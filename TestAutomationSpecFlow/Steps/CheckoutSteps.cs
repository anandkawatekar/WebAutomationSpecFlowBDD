using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestAutomationSpecFlow.Pages;

namespace TestAutomationSpecFlow.Steps
{
    [Binding]
    public sealed class CheckoutSteps:BaseSteps
    {
        public CheckoutSteps(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext) : base(driver, scenarioContext, featureContext)
        {
        }

        [Given(@"The user has opened product with (.*) on product details page")]
        public void GivenTheUserHasOpenedProductWithOnProductDetailsPage(string productId)
        {
            _featureContext.TryGetValue("BaseUrl", out string baseUrl);
            ProductDetailsPage pdp = new ProductDetailsPage(driver);
            pdp.Open(baseUrl, productId);

            _scenarioContext.Add("productId",productId);
        }

        [When(@"User adds product to the cart")]
        public void GivenAddProductToTheCart()
        {
            ProductDetailsPage pdp = new ProductDetailsPage(driver);
            pdp.AddProductToCart();
        }

        [When(@"User adds product to the cart and proceed to checkout")]
        public void GivenUserAddsProductToTheCart()
        {
            ProductDetailsPage pdp = new ProductDetailsPage(driver);
            pdp.AddProductToCart();
            pdp.ProceedToCheckout();

        }

        [When(@"Continue to sign in")]
        public void WhenIContinueToSignIn()
        {
            CartSummaryPage cartSummaryPage = new CartSummaryPage(driver);
            cartSummaryPage.ProceedToSignIn();
        }

        [When(@"Continue to shipping page")]
        public void WhenContinueToShippingPage()
        {
            AddressPage addressPage = new AddressPage(driver);
            addressPage.ProceedToShippingPage();
        }

        [When(@"User clicks terms of ervices")]
        public void WhenUserClicks_TermsOfErvices()
        {
            ShippingPage shippingPage = new ShippingPage(driver);
            shippingPage.ClickTermsOfService();
        }

        [When(@"Continue to payment page")]
        public void WhenIContinueToPaymentPage()
        {
            ShippingPage shippingPage = new ShippingPage(driver);
            shippingPage.ProceedToPaymentPage();
        }

        [Then(@"I validate product details (.*) and (.*) are correct")]
        public void ThenIValidateProductDetailsAreCorrect(string productName, decimal productPrice)
        {
            _scenarioContext.TryGetValue("productId", out string productId);
            PaymentPage paymentPage = new PaymentPage(driver);
            Assert.IsTrue(paymentPage.ValidateProductDetails(productId, productName,productPrice),"Product details are not correct");
        }

        [Then(@"the user sees a confirmation panel that the product has been added")]
        public void ThenTheUserSeesAConfirmationPanelThatTheProductHasBeenAdded()
        {
            ProductDetailsPage pdp = new ProductDetailsPage(driver);
            pdp.IsConfirmationPanelDisplayed();
        }


    }
}
