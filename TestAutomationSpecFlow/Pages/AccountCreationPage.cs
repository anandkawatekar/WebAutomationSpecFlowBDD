using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationSpecFlow.Data;

namespace TestAutomationSpecFlow.Pages
{
    public class AccountCreationPage:BasePage
    {
        private By firstNameElementId = By.Id("customer_firstname");
        private By lastNameElementId = By.Id("customer_lastname");
        private By emailElementId = By.Id("email");
        private By passwordElementId = By.Id("passwd");
        private By daysDOBElementId = By.Id("days");
        private By monthsDOBElementId = By.Id("months");
        private By yearsDOBElementId = By.Id("years");
        private By addressFirstNameElementId = By.Id("firstname");
        private By addressLastNameElementId = By.Id("lastname");
        private By addressLine1ElementId = By.Id("address1");
        private By addressLine2ElementId = By.Id("address2");
        private By cityElementId = By.Id("city");
        private By stateElementId = By.Id("id_state");
        private By postalCodeElementId = By.Id("postcode");
        private By countryElementId = By.Id("id_country");
        private By mobilePhoneElementId = By.Id("phone_mobile");
        private By addressAliasElementId = By.Id("alias");
        private By registerButtonElementId = By.Id("submitAccount");
        private By accountCreationFormElementId = By.Id("account-creation_form");
        

        public IWebElement FirstName => driver.FindElement(firstNameElementId);
        public IWebElement LastName => driver.FindElement(lastNameElementId);
        public IWebElement Email => driver.FindElement(emailElementId);
        public IWebElement Password => driver.FindElement(passwordElementId);
        public SelectElement DaysDOB => new SelectElement(driver.FindElement(daysDOBElementId));
        public SelectElement MonthsDOB => new SelectElement(driver.FindElement(monthsDOBElementId));
        public SelectElement YearsDOB => new SelectElement(driver.FindElement(yearsDOBElementId));
        public IWebElement AddressFirstName => driver.FindElement(addressFirstNameElementId);
        public IWebElement AddressLastName => driver.FindElement(addressLastNameElementId);
        public IWebElement AddressLine1 => driver.FindElement(addressLine1ElementId);
        public IWebElement AddressLine2 => driver.FindElement(addressLine2ElementId);
        public IWebElement City => driver.FindElement(cityElementId);
        public SelectElement State => new SelectElement(driver.FindElement(stateElementId));
        public IWebElement PostalCode => driver.FindElement(postalCodeElementId);
        public SelectElement Country => new SelectElement(driver.FindElement(countryElementId));
        public IWebElement MobilePhone => driver.FindElement(mobilePhoneElementId);
        public IWebElement AddressAlias => driver.FindElement(addressAliasElementId);
        public IWebElement RegisterButton => driver.FindElement(registerButtonElementId);
        public IWebElement AccountCreationForm => driver.FindElement(accountCreationFormElementId);

        public AccountCreationPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterUserInformation(User userInfo)
        {
            FirstName.SendKeys(userInfo.FirstName);
            LastName.SendKeys(userInfo.LastName);
            Password.SendKeys(userInfo.Password);
            DaysDOB.SelectByValue(userInfo.DOB.Day.ToString());
            MonthsDOB.SelectByValue(userInfo.DOB.Month.ToString());
            YearsDOB.SelectByValue(userInfo.DOB.Year.ToString());
            //AddressFirstName.SendKeys(userInfo.FirstName);
            //AddressLastName.SendKeys(userInfo.LastName);
            AddressLine1.SendKeys(userInfo.AddressLine1);
            AddressLine2.SendKeys(userInfo.AddressLine2);
            City.SendKeys(userInfo.City);
            State.SelectByText(userInfo.State);
            PostalCode.SendKeys(userInfo.PostalCode);
            Country.SelectByText(userInfo.Country);
            MobilePhone.SendKeys(userInfo.Phone);
            AddressAlias.Clear();
            AddressAlias.SendKeys(userInfo.AddressAlias);

        }

        public void ClickRegister()
        {
            RegisterButton.Click();
        }

        public bool IsAccountCreationFormDisplayed()
        {
            return AccountCreationForm.Displayed;
        }
    }
}
