using ROQ.GRADUATE.FRAMEWORK.Applications;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using TechTalk.SpecFlow;

namespace ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Steps
{
    [Binding]
    public class Dashboard
    {
        internal DriverManager Driver;
        internal Trello _trello;
        public Dashboard(Trello trello, DriverManager driver)
        {
            _trello = trello;
            Driver = driver;
        }

        [StepDefinition(@"I search for ""([^""]*)"" in the search bar")]
        public void ThenISearchForInTheSearchBar(string boardsname)
        {
            _trello.Dashboard.SearchBoardItem(boardsname);
        }

        [StepDefinition(@"I select ""([^""]*)"" from the workspace tab")]
        public void ThenISelectFromTheWorkspaceTab(string item)
        {
            _trello.Dashboard.WorkSpaceDropDownITemSelection(item);
        }

        [StepDefinition(@"I click the create new worrkspace button")]
        public void ThenIClickTheCreateNewWorrkspaceButton()
        {
            _trello.Dashboard.WorkSpaceCreateButton.Click();
        }

        [StepDefinition(@"Input ""([^""]*)"" as the workspace name")]
        public void ThenInputAsTheWorkspaceName(string workSpaceName)
        {
            _trello.Dashboard.WorkSpaceCreateNewNameInput.SendKeys(workSpaceName);
        }

        [StepDefinition(@"I Input the WorkSPace type")]
        public void ThenIInputTheWorkSPaceType()
        {
            _trello.Dashboard.WorkSpaceCreateTypeDropDrownArrow.Click();
            _trello.Dashboard.WorkSpaceCreateType.Click();
        }

        [StepDefinition(@"I submit the new Workspace created")]
        public void ThenISubmitTheNewWorkspaceCreated()
        {
            _trello.Dashboard.WorkSpaceCreateSumbit.Click();
            _trello.Dashboard.TryLaterButton.Click();
        }

        [StepDefinition(@"I verify ""([^""]*)"" is displayed in workspaces")]
        public void ThenIVerifyIsDisplayedInWorkspaces(string name)
        {
            _trello.Dashboard.NewWorkSpaceHeaderName(name).WaitUntilVisible();
        }
    }
}
