using ROQ.GRADUATE.FRAMEWORK.Applications;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Steps
{
    [Binding]
    public class LoginPage
    {
        internal DriverManager Driver;
        internal Trello _trello;
        public LoginPage(Trello trello, DriverManager driver)
        {
            _trello = trello;
            Driver = driver;
        }

        [StepDefinition(@"I login as user")]
        public void IloginAsUser()
        {
            _trello.LoginPage.Login(Runner.config.Username, Runner.config.Password);
            _trello.LoginPage.BoardsTxt.WaitUntilExist(30);
        }


    }
}
