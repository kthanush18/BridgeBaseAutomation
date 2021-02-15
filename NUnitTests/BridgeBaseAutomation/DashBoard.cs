using Com.Common.Web;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.BridgeBaseAutomation
{
    public class DashBoard : WebBrowser
    {
        private readonly By username_Text_Locator = By.XPath("//button [@class = 'nameTagClass mat-raised-button']/span");
        private readonly By logOff_Button_Locator = By.XPath("//span [text() = ' Log off ']/..");
        private readonly By practice_Button_Locator = By.XPath("//div [text() = 'Practice']/..");
        private readonly By start_Bid_Table_Button_Locator = By.XPath("//div [text() = 'Start a Bidding table']/..");
        private readonly By start_Teach_Table_Button_Locator = By.XPath("//div [text() = 'Start a Teaching table']/..");
        private readonly By bridge_Master_Button_Locator = By.XPath("//div [text() = 'Bridge Master1']/..");

        public string GetUsername()
        {
            return GetText(username_Text_Locator);
        }

        public bool IsLogOffButtonVisible()
        {
            return IsElementVisible(logOff_Button_Locator);
        }

        public void NavigateToPractice()
        {
            ClickOn(practice_Button_Locator);
        }

        public bool IsStartBiddingTableVisible()
        {
            return IsElementVisible(start_Bid_Table_Button_Locator);
        }

        public bool IsTeachBiddingTableVisible()
        {
            return IsElementVisible(start_Teach_Table_Button_Locator);
        }

        public bool IsBridgeMasterVisible()
        {
            return IsElementVisible(bridge_Master_Button_Locator);
        }

        public void LogOff()
        {
            ClickOn(logOff_Button_Locator);
        }
    }
}
