using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutomationSpecFlow.Pages.Components
{
    public abstract class MenuBar:BasePage
    {
        private By signInMenuElementId = By.ClassName("login");
        private By signOutMenuElementId = By.ClassName("logout");
        private By viewMyAccountMenuElementId = By.ClassName("account");
        private By userFullNameElementId = By.XPath("//a[@class='account']/span");

        public IWebElement SignInMenu => driver.FindElement(signInMenuElementId);
        public IWebElement SignOutMenu => driver.FindElement(signOutMenuElementId);
        
        public IWebElement ViewMyAccountMenu => driver.FindElement(viewMyAccountMenuElementId);

        public IWebElement UserFullName => driver.FindElement(userFullNameElementId);

        public MenuBar(IWebDriver driver) : base(driver)
        {
        }

        public void ClickSignIn()
        {
            SignInMenu.Click();
        }

        public void ClickSignOut()
        {
            SignOutMenu.Click();
        }

        public string GetLoggedInUserFullName()
        {

            return UserFullName.Text.Trim();
        }
    }
}
