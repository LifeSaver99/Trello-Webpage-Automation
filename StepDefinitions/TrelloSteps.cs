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
            _trello.GoToLoginPAge();
        }

        [StepDefinition(@"I login as user")]
        public void IloginAsUser()
        {
            _trello.LoginPage.Login("dapsymigo001@gmail.com", "Oreoluwa1$");
        }

        [StepDefinition(@"the trello hompage is displayed")]
        public void ThenTheTrelloHompageIsDisplayed()
            
        {
            _trello.LoginPage.BoardsTxt.WaitUntilExist(30);
        }
        [Then(@"I search for ""([^""]*)"" in the search bar")]
        public void ThenISearchForInTheSearchBar(string boardsname)
        {
            _trello.HomePage.SearchBoardItem(boardsname);
        }

        [Then(@"I select ""([^""]*)"" from the workspace tab")]
        public void ThenISelectFromTheWorkspaceTab(string item)
        {
            _trello.HomePage.WorkSpaceDropDownITemSelection(item);
        }

        [Then(@"the Health Corner Boards is Displayed")]
        public void ThenTheBoardsIsDisplayed()
        {
            _trello.Boards.HealthCornerBoardTitle.WaitUntilVisible();
        }


    }
}
