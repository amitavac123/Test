using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using ClassLibrary_Service1.Steps;
using Gherkin.Ast;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;


namespace ClassLibrary_Service1
{

    [Binding]
    public static class Hook
    {

        private static ScenarioContext _scenarioContext;
        //private static FeatureContext _featureContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;

        public static string CreateNode { get; private set; }
        public static string ServiceDetailsForReport { get; private set; }

        public static string environment = ConfigurationManager.AppSettings["environment"];
        public static string default_browser = ConfigurationManager.AppSettings["default_browser"];

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _extentHtmlReporter = new ExtentHtmlReporter(@"C:\\Newfolder\\aaa.html");
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_extentHtmlReporter);
        }


        [BeforeFeature]
        public static void BEFOREFEATURESTART(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                _feature = _extentReports.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);
            }
        }

        [BeforeScenario]

        public static void BEFOREFEATURESTART(ScenarioContext scenarioContext)
        {

            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(scenarioContext.ScenarioInfo.Title,
               scenarioContext.ScenarioInfo.Description);

            }
        }

        [AfterStep]
           
            public static void AfterEachStep()
            {
         
                ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
               
            switch (scenarioBlock)
                {
                case ScenarioBlock.Given:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" +
                          _scenarioContext.TestError.StackTrace);

                    }
                    else
                    {
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                        break;
                case ScenarioBlock.When:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" +
                          _scenarioContext.TestError.StackTrace);

                    }
                    else
                    {
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.StepContext.StepInfo.Table.ToString() + "\r\n" + SpecFlowFeature1.ServiceDetailsForReport);
                    }
                    break;
                case ScenarioBlock.Then:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" +
                         _scenarioContext.TestError.StackTrace);
                    }
                    else
                    {
                         _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.StepContext.StepInfo.Table.ToString() + "<br>" +  SpecFlowFeature1.ServiceDetailsForReport);

        
                    }
                    break;
                default:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" +
                          _scenarioContext.TestError.StackTrace);

                    }
                    else
                    {
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.StepContext.StepInfo.Table.ToString() + "\r\n" + SpecFlowFeature1.ServiceDetailsForReport);
                    }
                    break;


            }

            }

            [AfterTestRun]
            public static void AFTERTESTRUN()
            {
                _extentReports.Flush();
            }


        }
    }


