using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using ROQ.GRADUATE.FRAMEWORK.Applications.Pages;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;

namespace ROQ.GRADUATE.FRAMEWORK.Applications
{
    public class Trello
    {
        
        DriverManager _driverManager;
        public Trello(DriverManager driverManager)
        {   
            _driverManager =driverManager;
        }

        public LoginPage LoginPage => new LoginPage(_driverManager);
        public HomePage HomePage => new HomePage(_driverManager);
        public Boards Boards => new Boards(_driverManager);

    }
}
