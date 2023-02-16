using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Elements;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;

namespace ROQ.GRADUATE.FRAMEWORK.Applications.Pages
{
    public class Boards
    {
        DriverManager _driverManager;

        #region"Constructor"
        public Boards(DriverManager driverManager)
        {
            _driverManager = driverManager;
        }
        #endregion

        #region"Elements"
        public BaseElement HealthCornerBoardTitle => new BaseElement(_driverManager, By.XPath("//a[@title='HEALTH CORNER (currently active)']"));
        #endregion

    }
}
