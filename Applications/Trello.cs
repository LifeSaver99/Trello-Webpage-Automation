using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using ROQ.GRADUATE.FRAMEWORK.Applications.Pages;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Elements;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;

namespace ROQ.GRADUATE.FRAMEWORK.Applications
{
    public class Trello
    {
        public LoginPage LoginPage => new LoginPage(_driverManager);
        public HomePage HomePage => new HomePage(_driverManager);
        public Boards Boards => new Boards(_driverManager);

        DriverManager _driverManager;

        #region"Constructor"
        public Trello(DriverManager driverManager)
        {   
            _driverManager =driverManager;
        }
        #endregion

        #region"Elements"
        public BaseElement LoginButton => new BaseElement(_driverManager,By.XPath("//div[@class='Buttonsstyles__ButtonGroup-sc-1jwidxo-3 jnMZCI']//a[contains(text(),'Log in')]"));
        #endregion

        #region"Methods"
        public void GoToLoginPAge()
        {
            LoginButton.Click();
            LoginPage.LoginToTrelloHeaderText.AssertTextContains("Log in to Trello");
        }

        #endregion

    }
}
