using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace TestAutomationSpecFlow.Steps
{
    public class BaseSteps
    {
        protected ScenarioContext _scenarioContext;
        protected FeatureContext _featureContext;
        protected IWebDriver driver { get; }

        public BaseSteps(IWebDriver driver, ScenarioContext scenarioContext,FeatureContext featureContext)
        {
            this.driver = driver;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }
    }
}
