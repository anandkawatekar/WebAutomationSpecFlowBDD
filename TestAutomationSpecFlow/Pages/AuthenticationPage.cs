using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationSpecFlow.Pages
{
    public class AuthenticationPage :BasePage
    {
        private By userNameElementId = By.Id("email");
        private By passwordElementId = By.Id("passwd");
        private By signInButtonElementId = By.Id("SubmitLogin");
        private By createAccountEmailElementId = By.Id("email_create");
        private By createAccountButtonElementId = By.Id("SubmitCreate");
        private By createAccountFormElementId = By.Id("create-account_form");
        private By loginFormElementId = By.Id("login_form");

        public IWebElement UserName => driver.FindElement(userNameElementId);
        public IWebElement Password => driver.FindElement(passwordElementId);
        public IWebElement SignInButton => driver.FindElement(signInButtonElementId);
        public IWebElement CreateAccountEmail => driver.FindElement(createAccountEmailElementId);
        public IWebElement CreateAccountButton => driver.FindElement(createAccountButtonElementId);
        public IWebElement CreateAccountForm => driver.FindElement(createAccountFormElementId);
        public IWebElement LoginForm => driver.FindElement(loginFormElementId);

        public AuthenticationPage(IWebDriver driver) : base(driver) { }

        public void Open(string baseUrl)
        {

            LoadPage(baseUrl + "?controller=authentication&back=my-account");
        }

        public void EnterUserName(string userName)
        {
            UserName.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void ClickSignIn()
        {
            SignInButton.Click();
        }

        public void EnterEmailAddress(string email)
        {
            CreateAccountEmail.SendKeys(email);
        }

        public void ClickOnCreateAnAccount()
        {
            CreateAccountButton.Click();
        }

        public void WaitForLoginForToDisplay()
        {
            WaitForElementIsVisible(loginFormElementId);
        }

        public bool IsLoginFormDisplayed()
        {
            return LoginForm.Displayed;
        }
    }
}
