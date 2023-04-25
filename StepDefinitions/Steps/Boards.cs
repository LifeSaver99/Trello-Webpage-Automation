using ROQ.GRADUATE.FRAMEWORK.Applications;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using TechTalk.SpecFlow;

namespace ROQ.GRADUATE.FRAMEWORK.StepDefinitions.Steps
{
    [Binding]
    public class Boards
    {
        internal DriverManager Driver;
        internal Trello _trello;
        public Boards(Trello trello, DriverManager driver)
        {
            _trello = trello;
            Driver = driver;
        }

        [StepDefinition(@"the Health Corner Boards is Displayed")]
        public void ThenTheBoardsIsDisplayed()
        {
            _trello.Boards.HealthCornerBoardTitle.WaitUntilVisible();
        }
    }
}
