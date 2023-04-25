using OpenQA.Selenium;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Elements;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Hooks;
using System.Threading;


namespace ROQ.GRADUATE.FRAMEWORK.Applications.Pages
{
    public class LoginPage
    {

        DriverManager _driverManager;

        #region "Constructor" 
        public LoginPage(DriverManager driverManager)
        {
            _driverManager = driverManager;
        }
        #endregion

        #region "Elements"

        public BaseElement UsernameNameInput => new BaseElement(_driverManager, By.XPath("//input[@id='user']"));
        public BaseElement UsernameLoginButton => new BaseElement(_driverManager, By.XPath("//input[@id='login']"));
        public BaseElement PasswordLoginButton => new BaseElement(_driverManager, By.XPath("//button[@id='login-submit']"));
        public BaseElement PasswordInput => new BaseElement(_driverManager, By.XPath("//input[@id='password']"));
        public BaseElement BoardsTxt => new BaseElement(_driverManager, By.XPath("//span[contains(text(),'Boards')]"));

        #endregion

        #region "Methods"
        public void Login(string username, string password)
        {
            UsernameNameInput.SendKeys(username);
            UsernameLoginButton.Click();
            Thread.Sleep(2000);
            PasswordInput.SendKeys(password);
            PasswordLoginButton.Click();
            BoardsTxt.WaitUntilExist(30);

        }

        public void LoginAsInvalidUser()
        {
            UsernameNameInput.SendKeys(Runner.config.Username);
            UsernameLoginButton.Click();
            Thread.Sleep(2000);
            PasswordInput.SendKeys("hgtyres");
            PasswordLoginButton.Click();

        }

        #endregion

    }

}
