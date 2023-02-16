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
        public class HomePage
        {

            DriverManager _driverManager;

            #region"Constructor"
            public HomePage(DriverManager driverManager)
            {
                _driverManager = driverManager;
            }
            #endregion

            #region"Elements"
            public BaseElement SearchInput => new BaseElement(_driverManager,By.XPath("//input[@placeholder='Search']"));
            public BaseElement SearchInputHealthCornerValue => new BaseElement(_driverManager,By.XPath("//span[@title='HEALTH CORNER']"));
            public BaseElement WorkspaceDropDownArrow => new BaseElement(_driverManager,By.XPath("//button[@data-testid='workspace-switcher']//span[contains(@aria-label,'DownIcon')]"));
            public BaseElement HealthCornerBoardTitle => new BaseElement(_driverManager, By.XPath("//a[@title='HEALTH CORNER (currently active)']"));

            #endregion

            #region"DynamicElement"
            public BaseElement WorkspaceListItemGhaneva(string item) => new BaseElement(_driverManager, By.XPath($"//div[@data-testid='workspace-list']//p[contains(text(),'{item}')]"));
            #endregion

            #region"Methods"
            public void SearchBoardItem(string boardname)
            {
               SearchInput.SendKeys(boardname);
               SearchInputHealthCornerValue.Click();
            }
            
            public void WorkSpaceDropDownITemSelection(string item)
            {
              WorkspaceDropDownArrow.WaitUntilVisible();
              WorkspaceDropDownArrow.Click();
              WorkspaceListItemGhaneva(item).Click();
        }
            #endregion 

        }

}
