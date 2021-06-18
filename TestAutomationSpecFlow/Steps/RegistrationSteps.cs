using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestAutomationSpecFlow.Data;
using TestAutomationSpecFlow.Pages;

namespace TestAutomationSpecFlow.Steps
{
    [Binding]
    public sealed class RegistrationSteps: BaseSteps
    {
        private User userData = null;
        public RegistrationSteps(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext) : base(driver, scenarioContext, featureContext)
        {
        }

        [Given(@"A user is on landing page")]
        public void GivenAUserIsOnLandingPage()
        {
            _featureContext.TryGetValue("BaseUrl", out string baseUrl);
            HomePage homePage = new HomePage(driver);
            homePage.Open(baseUrl);
        }

        [When(@"User clicks Sign in on landing page")]
        public void WhenUserClicksSignInOnLandingPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickSignIn();
        }

        [Then(@"I validate user account is created successfully")]
        public void ThenIValidateUserAccountIsCreatedSuccessfully()
        {
            userData = (User)_scenarioContext["NewUserData"];
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.WaitUntilLoaded();
            // var userFullName = userData.FirstName + " " + userData.LastName;
            // Assert.AreEqual(userFullName, myAccountPage.GetLoggedInUserFullName());
            Assert.IsTrue(myAccountPage.IsViwMyAccountMenuDisplayed(), "User registration failed.");
        }


        [When(@"User begins to create account by entering email address")]
        public void WhenTheUserBeginsToCreateAccountByEnteringEmailAddress()
        {
            userData = User.GetNewUserData();
            _scenarioContext.Add("NewUserData", userData);
            AuthenticationPage loginPage = new AuthenticationPage(driver);
            loginPage.EnterEmailAddress(userData.Email);
            loginPage.ClickOnCreateAnAccount();
        }

        [When(@"User enters personal information on create account page")]
        public void WhenTheUserEntersPersonalInformationOnCreateAccountPage()
        {
            userData = (User)_scenarioContext["NewUserData"];
            AccountCreationPage createAccountPage = new AccountCreationPage(driver);
            createAccountPage.EnterUserInformation(userData);
        }

        [When(@"clicks on Register button")]
        public void WhenClicksOnRegisterButton()
        {
            AccountCreationPage createAccountPage = new AccountCreationPage(driver);
            createAccountPage.ClickRegister();
        }

        [Then(@"I validate on the landing screen - correct user name is displayed")]
        public void ThenValidateOnTheLandingScreen_CorrectNameAndSurnameIsDisplayed()
        {
            userData = (User)_scenarioContext["NewUserData"];
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.WaitUntilLoaded();
            var userFullNameExpected = userData.FirstName + " " + userData.LastName;
            var userFullNameActual = myAccountPage.GetLoggedInUserFullName();
            Assert.AreEqual(userFullNameExpected, userFullNameActual,$"correct name and surname not displayed, expected value:{userFullNameExpected} actual value:{userFullNameActual}");
        }

        [Then(@"Should redirect to Authentication Page")]
        public void ThenShouldRedirectToAuthenticationPage()
        {
            AuthenticationPage authPage = new AuthenticationPage(driver);
            Assert.IsTrue(authPage.IsLoginFormDisplayed(), "User not redirected to Authentication page.");
        }

        [Then(@"User should redirect to create account page")]
        public void ThenUserShouldRedirectToCreateAccountPage()
        {
            AccountCreationPage createAccountPage = new AccountCreationPage(driver);
            Assert.IsTrue(createAccountPage.IsAccountCreationFormDisplayed(), "User not redirected to create account page.");
            
        }

    }
}
