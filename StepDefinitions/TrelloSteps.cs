using NUnit.Framework;
using ROQ.GRADUATE.FRAMEWORK.Applications;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ROQ.GRADUATE.FRAMEWORK.StepDefinitions
{
    [Binding]
    public class TrelloSteps
    {
       private DriverManager Driver;
        private Trello _trello; 
        public TrelloSteps(Trello trello, DriverManager driver)
        {
            _trello = trello;
             Driver = driver;
        }
        [StepDefinition(@"I click the login button on the homepage to navigate to the login page")]
        public void GivenIClickTheAcceptCookiesButton()
        {
            
            _trello.HomePage.LoginButton.Click();
            Thread.Sleep(2000);
            _trello.LoginPage.TrelloHeaderText.AssertTextContains("Log in to Trello");
            
        }

        [StepDefinition(@"I input the username and password to login to trello")]
        public void WhenIInputTheUsernameAndPasswordToLoginToTrello()
        {
            _trello.LoginPage.UsernameNameInput.SendKeys("dapsymigo001@gmail.com");
            _trello.LoginPage.UsernameLoginButton.Click();
            Thread.Sleep(2000);
            _trello.LoginPage.PasswordInput.SendKeys("Oreoluwa1$");
            _trello.LoginPage.PasswordLoginButton.Click();
            
        }

        [StepDefinition(@"the trello hompage is displayed")]
        public void ThenTheTrelloHompageIsDisplayed()
            
        {
            _trello.LoginPage.BoardsTxt.WaitUntilExist(30);
        }
        [Then(@"I search for ""([^""]*)"" in the search bar")]
        public void ThenISearchForInTheSearchBar(string boardsname)
        {
            _trello.HomePage.SearchInput.SendKeys(boardsname);
            _trello.HomePage.SearchInputHealthCornerValue.Click();
            Thread.Sleep(2000);
        }

        [Then(@"I select ""([^""]*)"" from the workspace tab")]
        public void ThenISelectFromTheWorkspaceTab(string item)
        {
            _trello.HomePage.WorkspaceDropDownArrow.WaitUntilVisible();
            _trello.HomePage.WorkspaceDropDownArrow.Click();
            _trello.HomePage.WorkspaceListItemGhaneva(item).Click();
        }

        [Then(@"the Health Corner Boards is Displayed")]
        public void ThenTheBoardsIsDisplayed()
        {
            _trello.Boards.HealthCornerBoardTitle.WaitUntilVisible();
        }


    }
}
