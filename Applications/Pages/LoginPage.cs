using BoDi;
using OpenQA.Selenium;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Elements;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


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
       public BaseElement LoginToTrelloHeaderText => new BaseElement(_driverManager, By.XPath("//h1[contains(text(),'Log in to Trello')]"));
       public BaseElement UsernameNameInput => new BaseElement(_driverManager, By.XPath("//input[@id='user']"));
       public BaseElement UsernameLoginButton => new BaseElement(_driverManager, By.XPath("//input[@id='login']"));
       public BaseElement PasswordLoginButton => new BaseElement(_driverManager, By.XPath("//button[@id='login-submit']"));
       public BaseElement PasswordInput => new BaseElement(_driverManager, By.XPath("//input[@id='password']"));
       public BaseElement BoardsTxt => new BaseElement (_driverManager,By.XPath("//span[contains(text(),'Boards')]"));

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

        #endregion

    }

}
