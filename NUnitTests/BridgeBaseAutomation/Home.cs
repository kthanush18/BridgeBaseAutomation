using Com.Common.Web;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.BridgeBaseAutomation
{
    public class Home : WebBrowser
    {
        private readonly By login_Register_Button_Selector  = By.CssSelector(".register-button");

        public void GoToLoginPage()
        {
            ClickOn(login_Register_Button_Selector);
        }
    }
}
