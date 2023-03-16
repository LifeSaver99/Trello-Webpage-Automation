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
        public class Dashboard
        {

            DriverManager _driverManager;

            #region"Constructor"
            public Dashboard(DriverManager driverManager)
            {
                _driverManager = driverManager;
            }
            #endregion

            #region"Elements"
            public BaseElement SearchInput => new BaseElement(_driverManager,By.XPath("//input[@placeholder='Search']"));
            public BaseElement SearchInputHealthCornerValue => new BaseElement(_driverManager,By.XPath("//span[@title='HEALTH CORNER']"));
            public BaseElement WorkspaceDropDownArrow => new BaseElement(_driverManager,By.XPath("//button[@data-testid='workspace-switcher']//span[contains(@aria-label,'DownIcon')]"));
            public BaseElement HealthCornerBoardTitle => new BaseElement(_driverManager, By.XPath("//a[@title='HEALTH CORNER (currently active)']"));
            public BaseElement WorkSpaceCreateButton => new BaseElement(_driverManager, By.XPath("//button[@aria-label='Create a Workspace']"));
            public BaseElement WorkSpaceCreateNewNameInput => new BaseElement(_driverManager, By.XPath("//input[@data-testid='header-create-team-name-input']"));
            public BaseElement WorkSpaceCreateNDescriptiosInput => new BaseElement(_driverManager, By.XPath("//textarea[@id='1678106071190-create-team-org-description']"));
            public BaseElement WorkSpaceCreateType => new BaseElement(_driverManager, By.XPath("//div[@data-testid='header-create-team-type-input-engineering-it']//li[contains(text,Engineering-IT)]"));
            public BaseElement WorkSpaceCreateTypeDropDrownArrow => new BaseElement(_driverManager, By.XPath("//div[@data-testid='header-create-team-type-input']"));
            public BaseElement WorkSpaceCreateSumbit => new BaseElement(_driverManager, By.XPath("//button[@type='submit'][contains(text(),'Continue')]"));
            public BaseElement TryLaterButton => new BaseElement(_driverManager, By.XPath("//a[@data-testid='show-later-button']"));
            #endregion

            #region"DynamicElement"
            public BaseElement WorkspaceListItemGhaneva(string item) => new BaseElement(_driverManager, By.XPath($"//div[@data-testid='workspace-list']//p[contains(text(),'{item}')]"));
            public BaseElement NewWorkSpaceHeaderName(string name) => new BaseElement(_driverManager, By.XPath($"//div//h2[@class='SiP6d2d_8FAAkC'][contains(text(),'{name}')]"));
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
