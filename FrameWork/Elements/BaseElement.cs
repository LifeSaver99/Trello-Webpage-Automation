﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ROQ.GRADUATE.FRAMEWORK.FrameWork.Helpers;
using System;

namespace ROQ.GRADUATE.FRAMEWORK.FrameWork.Elements
{
    public class BaseElement
    {
        private DriverManager _driverManager;
        internal By _elementLocator;

        #region"Constructor"
        public BaseElement(DriverManager driverManager, By elementLocator)
        {
            _driverManager = driverManager;
            _elementLocator = elementLocator;
        }
        #endregion

        #region"Methods"
        public IWebElement GetElement()
        {
            return _driverManager.Driver.FindElement(_elementLocator);
        }

        public void MouseOver()
        {
            Actions action = new Actions(_driverManager.Driver);
            action.MoveToElement(GetElement()).Build().Perform();
        }
        public bool Exists(TimeSpan timeout)
        {
            bool exists = true;
            try
            {
                GetElement();
            }

            catch
            {
                exists = false;
            }
            return exists;
        }

        public void AssertTextContains(string expected)
        {
            WaitUntilExist(30);
            string elementText = GetElement().Text;
            Assert.That(elementText.Contains(expected));
        }

        public void Click()
        {
            _driverManager.Driver.FindElement(_elementLocator).Click();
        }

        public void SendKeys(string text)
        {
            _driverManager.Driver.FindElement(_elementLocator).SendKeys(text);
        }

        public void WaitUntilExist(int timeInSeconds)
        {
            Exists(TimeSpan.FromSeconds(timeInSeconds));
        }

        public void WaitUntilVisible()
        {
            _driverManager.WaitUntil(_driverManager => GetElement().Displayed);
        }
        #endregion
    }
}
