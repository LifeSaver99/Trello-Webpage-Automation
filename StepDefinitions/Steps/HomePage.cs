using NUnit.Framework;
using ROQ.GRADUATE.FRAMEWORK.Applications;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Steps
{
    [Binding]
    public class HomePage
    {
        internal DriverManager Driver;
        internal Trello _trello;
        public HomePage(Trello trello, DriverManager driver)
        {
            _trello = trello;
            Driver = driver;
        }

        [StepDefinition(@"I click the login button on the homepage to navigate to the login page")]
        public void GivenIClickTheAcceptCookiesButton()
        {
            _trello.HomePage.GoToLoginPAge();
        }

        [StepDefinition(@"I click the login button")]
        public void GivenIClickTheLoginButton()
        {
            _trello.HomePage.LoginButton.Click();
        }


    }
}
