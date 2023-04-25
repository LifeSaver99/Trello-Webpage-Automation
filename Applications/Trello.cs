using ROQ.GRADUATE.FRAMEWORK.Applications.Pages;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;

namespace ROQ.GRADUATE.FRAMEWORK.Applications
{
    public class Trello
    {
        public LoginPage LoginPage => new LoginPage(_driverManager);
        public Dashboard Dashboard => new Dashboard(_driverManager);
        public Boards Boards => new Boards(_driverManager);
        public HomePage HomePage => new HomePage(_driverManager);

        DriverManager _driverManager;

        #region"Constructor"
        public Trello(DriverManager driverManager)
        {
            _driverManager = driverManager;
        }
        #endregion

    }
}
