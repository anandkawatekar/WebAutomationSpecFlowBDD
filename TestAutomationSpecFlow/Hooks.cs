using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestAutomationSpecFlow.Data;

namespace TestAutomationSpecFlow
{
    [Binding]
    public class Hooks
    {
        private readonly BoDi.IObjectContainer objectContainer;
        private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        public Hooks(BoDi.IObjectContainer objectContainer,FeatureContext featureContext,ScenarioContext scenarioContext)
        {
            this.objectContainer = objectContainer;
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(Directory.GetCurrentDirectory() + @"\TestReport.html");
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }

        [BeforeFeature(Order = 0)]
        public static void InitializeFeature(FeatureContext featureContext)
        {
            TestConfig config = TestConfig.GetConfigData();
            featureContext.Add("BaseUrl", config.BaseURL);
            featureContext.Add("Browser",config.Browser);

            if (!(featureContext is null))
            {

                _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public static void BeforeScenarioStart(ScenarioContext scenarioConext)
        {

            if (!(scenarioConext is null))
            {
                _scenario = _feature.CreateNode<Scenario>(scenarioConext.ScenarioInfo.Title, scenarioConext.ScenarioInfo.Description);
            }
        }

        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {

                case ScenarioBlock.Given:
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(scenarioContext.TestError.Message).Fail("\n" + scenarioContext.TestError.StackTrace);

                    }
                    else
                    {
                        _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                    }

                    break;
                case ScenarioBlock.When:
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(scenarioContext.TestError.Message).Fail("\n" + scenarioContext.TestError.StackTrace);

                    }
                    else
                    {
                        _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                    }

                    break;
                case ScenarioBlock.Then:
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(scenarioContext.TestError.Message).Fail("\n" + scenarioContext.TestError.StackTrace);

                    }
                    else
                    {
                        _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                    }

                    break;
                default:
                    if (scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(scenarioContext.TestError.Message).Fail("\n" + scenarioContext.TestError.StackTrace);

                    }
                    else
                    {
                        _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
                    }

                    break;




            }
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();

        }

        [BeforeScenario(Order = 1)]
        public void InitializeWebDriver()
        {
            string browser;
            this.featureContext.TryGetValue("Browser", out browser);

            IWebDriver driver;
            switch (browser)
            {
                default:
                case "CHROME":
                    driver = new ChromeDriver();
                    break;
                case "FIREFOX":
                    driver = new FirefoxDriver();
                    break;
            }
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
        }

        [AfterScenario(Order =1)]
        public void AfterScenario()
        {
            IWebDriver driver = objectContainer.Resolve<IWebDriver>();
            driver.Close();
            driver.Quit();
        }
    }
}
