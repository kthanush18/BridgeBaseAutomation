using Com.Common.Web;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace com.BridgeBaseAutomation
{
    public class Login : WebBrowser
    {
        private readonly By username_Textbox_Selector = By.Id("mat-input-0");
        private readonly By password_Textbox_Selector = By.Id("mat-input-1");
        private readonly By login_Button_Selector = By.XPath("//span [text() = ' Log in ']/..");

        public void EnterCredentialsAndLogin(string username,string password)
        {
            EnterText(username_Textbox_Selector, username);
            EnterText(password_Textbox_Selector, password);
            ClickOn(login_Button_Selector);
        }
    }
}
