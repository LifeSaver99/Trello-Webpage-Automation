using OpenQA.Selenium;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Elements;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROQ.GRADUATE.FRAMEWORK.Applications.Pages;

namespace ROQ.GRADUATE.FRAMEWORK.Applications.Pages
{
    public class HomePage
    {
        DriverManager _driverManager;

        #region Constructor
        public HomePage(DriverManager driverManager)
        { 
            _driverManager = driverManager;
        }
        #endregion

        #region"Elements"
        public BaseElement LoginButton => new BaseElement(_driverManager, By.XPath("//div[@class='Buttonsstyles__ButtonGroup-sc-1jwidxo-3 jnMZCI']//a[contains(text(),'Log in')]"));
        public BaseElement LoginToTrelloHeaderText => new BaseElement(_driverManager, By.XPath("//h1[contains(text(),'Log in to Trello')]"));

        #endregion

        #region"Methods"
        public void GoToLoginPAge()
        {
            LoginButton.Click();
            LoginToTrelloHeaderText.AssertTextContains("Log in to Trello");
        }

        #endregion
    }
}
