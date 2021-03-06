﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using WebDriverManager.DriverConfigs.Impl;

namespace Com.Common.Web
{
    public class WebBrowser
    {
        private static IWebDriver _driver;
        private static WebDriverWait _wait;

        public enum BrowserType
        {
            CHROME,FIREFOX,IE,EDGE
        }

        public void LaunchBrowser(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.CHROME:
                    _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case BrowserType.FIREFOX:
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver();
                    break;
            }
        }

        public void NavigateToURL(string URL)
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public void ClickOn(By selector)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(selector));
            element.Click();
        }

        public void EnterText (By selector,string text)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(selector));
            element.SendKeys(text);
        }

        public string GetText(By selector)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(selector));
            return element.Text.Trim();
        }

        public bool IsElementVisible(By selector)
        {
            IWebElement element = _wait.Until(ExpectedConditions.ElementIsVisible(selector));
            return element.Displayed;
        }

        public void CloseBrowser()
        {
            _driver.Close();
            _driver.Quit();
        }

        protected string TakeScreenShot(string screenShotName)
        {
            string localpath = "";
            string dateTimeNow = DateTime.Now.ToString("dd-'MM'-'yyyy");
            try
            {
                ITakesScreenshot takeScreenShot = (ITakesScreenshot)_driver;
                Screenshot screenshot = takeScreenShot.GetScreenshot();
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp2.1", "");
                DirectoryInfo createReportDirectory = Directory.CreateDirectory($"{currentDirectory}\\Test_Execution_Reports_{dateTimeNow}");
                localpath = $"{currentDirectory}\\Test_Execution_Reports_{dateTimeNow}\\{screenShotName}.{ImageFormat.Jpeg}";
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }
    }
}