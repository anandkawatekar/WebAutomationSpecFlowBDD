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
    public sealed class AuthenticationSteps:BaseSteps
    {
        public AuthenticationSteps(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext):base(driver,scenarioContext,featureContext)
        {
        }

        [Given(@"A user is on authentication page")]
        public void GivenAUserIsOnAuthenticationPage()
        {
            _featureContext.TryGetValue("BaseUrl", out string baseUrl);

            AuthenticationPage authPage = new AuthenticationPage(driver);
            authPage.Open(baseUrl);
        }
        

        [When(@"User logs in with (.*) and (.*)")]
        [Given(@"User logs in with (.*) and (.*)")]
        [When(@"Login again with (.*) and (.*)")]
        public void WhenTheUserLogsInWithUserNameAndPassword(string userName, string password)
        {
            AuthenticationPage authPage = new AuthenticationPage(driver);
            authPage.EnterUserName(userName);
            authPage.EnterPassword(password);
            authPage.ClickSignIn();
        }

        [Then(@"User should log in successfully")]
        public void ThenTheUserIsLoggedSuccessfully()
        {
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.WaitUntilLoaded();
            Assert.IsTrue(myAccountPage.IsViwMyAccountMenuDisplayed(),"User login failed");
        }

        [When(@"User logs out")]
        public void WhenUserLogsOut()
        {
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.ClickSignOut();
        }

        [Then(@"I validate on the landing screen - correct (.*) and (.*) is displayed")]
        public void ThenValidateOnTheLandingScreen_CorrectNameAndSurnameIsDisplayed(string name,string surname)
        {
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.WaitUntilLoaded();
            var userFullNameExpected = name + " " + surname;
            var userFullNameActual = myAccountPage.GetLoggedInUserFullName();
            Assert.AreEqual(userFullNameExpected, userFullNameActual, $"correct name and surname not displayed, expected value:{userFullNameExpected} actual value:{userFullNameActual}");
        }

        [Then(@"I logout and login again")]
        public void ThenILogoutAndLoginAgain()
        {
            User userData = (User)_scenarioContext["NewUserData"];
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            myAccountPage.ClickSignOut();

            AuthenticationPage authPage = new AuthenticationPage(driver);
            authPage.WaitForLoginForToDisplay();
            authPage.EnterUserName(userData.Email);
            authPage.EnterPassword(userData.Password);
            authPage.ClickSignIn();
            Assert.IsTrue(myAccountPage.IsViwMyAccountMenuDisplayed(), "logout and login failed");
        }

    }
}
