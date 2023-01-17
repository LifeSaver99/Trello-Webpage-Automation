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
            public HomePage(DriverManager driverManager)
            {
                _driverManager = driverManager;
            }

        public BaseElement LoginButton => new BaseElement(_driverManager,By.XPath("//div[@class='Buttonsstyles__ButtonGroup-sc-1jwidxo-3 jnMZCI']//a[contains(text(),'Log in')]"));
        public BaseElement SearchInput => new BaseElement(_driverManager,By.XPath("//input[@placeholder='Search']"));
        public BaseElement SearchInputHealthCornerValue => new BaseElement(_driverManager,By.XPath("//span[@title='HEALTH CORNER']"));
        public BaseElement WorkspaceDropDownArrow => new BaseElement(_driverManager,By.XPath("//button[@data-testid='workspace-switcher']//span[contains(@aria-label,'DownIcon')]"));
        public BaseElement WorkspaceListItemGhaneva(string item) => new BaseElement(_driverManager,By.XPath($"//div[@data-testid='workspace-list']//p[contains(text(),'{item}')]"));




        }


}
