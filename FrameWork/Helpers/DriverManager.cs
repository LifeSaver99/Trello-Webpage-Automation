using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Hooks;

namespace ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers
{
    public class DriverManager
    {
       
       
        
        public WebDriver Driver;

        #region"Constructor"
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DriverManager() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion

        #region"Methods"
        public void TimeOut(TimeSpan timeout)
        {
            Driver.Manage().Timeouts().ImplicitWait = timeout;
        }

        public void BrowserTypeSwitch (bool remoteExecution)
        {
            if (remoteExecution == true)
            {
               
               
                if (Runner.config.BrowserType == "chromeDriver")
                {
                    ChromeOptions options = new ChromeOptions();
                    Driver = new RemoteWebDriver(options);
                    options.AddArgument("incognito");
                }

                else if (Runner.config.BrowserType == "firefox")
                {
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArgument("incognito");
                    Driver = new RemoteWebDriver(options);
                }
                else if (Runner.config.BrowserType == "edge")
                {
                    EdgeOptions options = new EdgeOptions();
                    options.AddArgument("inPrivate");
                    Driver = new RemoteWebDriver(options);
                }

            }
            else
            {
                if (Runner.config.BrowserType == "chromeDriver")
                {
                    //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "C://Selenium-java browserstack//chromedriver_win32//chromedriver.exe");
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("incognito");
                    Driver = new ChromeDriver(options);                    
                }
                else if (Runner.config.BrowserType == "firefox")
                {
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArgument("incognito");
                    Driver = new FirefoxDriver(options);
                }

                else if (Runner.config.BrowserType == "edge")
                {
                    EdgeOptions options = new EdgeOptions();
                    options.AddArgument("inPrivate");
                    Driver = new EdgeDriver(options);
                }
            }
           
            
        }

        public void WaitUntil(Func<IWebDriver, bool> function)
        {
            GetWebDriverWait().Until(function);
        }

        public void Init()
        {
            Driver.Navigate().GoToUrl(Runner.config.AppUrl);
        }

        
        public void Quit()
        {
          Driver.Quit();
        }

        public void WaitForPageToLoad()
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
            try
            {
                wait.Until(Driver =>
                    ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception pageLoadWaitError)
            {
                throw new TimeoutException("Timeout during page load", pageLoadWaitError);
            }
        }

        public WebDriverWait GetWebDriverWait()
        {
            return new WebDriverWait(Driver,TimeSpan.FromSeconds(30));

        }

        public void TakeScreenshot(string name)
        {
            var screenshot = Driver.TakeScreenshot();
            var filePathToSave = $"C:\\Users\\Adedapo.Adeseye\\source\\repos\\ROQ.GRADUATE.FRAMEWORK\\Screenshot\\{name}.png";
            screenshot.SaveAsFile(filePathToSave, ScreenshotImageFormat.Png);
        }

        #endregion
    }
}
