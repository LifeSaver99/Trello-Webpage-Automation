using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Microsoft.Extensions.Configuration;
using ROQ.GRADUATE.FRAMEWORK.Applications;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Variables;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Hooks
{
    [Binding]
    public class Runner
    {
        IObjectContainer _objectContainer;
        DriverManager _driverManager;
        static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName
             + Path.DirectorySeparatorChar + "Report"
             + Path.DirectorySeparatorChar + "Report" + DateTime.Now.ToString("ddMMyyyy HHmmss");
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, steps;
        public static ConfigSettings config;
        static string configSettingsPath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "FrameWork/Configuration/appsettings.json";

        #region"Constructor" 
        public Runner(IObjectContainer objectContainer, DriverManager driverManager)
        {
            this._objectContainer = objectContainer;
            this._driverManager = driverManager;
        }
        #endregion

        #region"Hooks"

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            config = new ConfigSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configSettingsPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);

            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }


        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }



        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = extent.CreateTest(context.ScenarioInfo.Title);

            _driverManager.BrowserTypeSwitch(false);
            _driverManager.TimeOut(TimeSpan.FromSeconds(15));
            _driverManager.Init();
            //_objectContainer.RegisterInstanceAs<DriverManager>(_driverManager);
            _objectContainer.RegisterInstanceAs<Trello>(new Trello(_driverManager));
        }


        [BeforeStep]
        public void BeforeTest()
        {
            steps = scenario;
        }


        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {

            if (context.TestError == null)
            {
                steps.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }
            else if (context.TestError != null)
            {
                steps.Log(Status.Fail, context.StepContext.StepInfo.Text);

                string screenShot = _driverManager.Driver.GetScreenshot().AsBase64EncodedString;
                steps.AddScreenCaptureFromBase64String(screenShot);

                string escapedStepName = Uri.EscapeDataString(context.StepContext.StepInfo.Text + DateTime.Now.ToString("dd MM HH mm ss ff"));
                _driverManager.TakeScreenshot(escapedStepName);

            }

        }


        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _objectContainer.Resolve<DriverManager>().Driver.Quit();
        }

        #endregion

    }

}
