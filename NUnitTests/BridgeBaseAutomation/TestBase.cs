using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Com.Common.Web;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace com.BridgeBaseAutomation
{
    public class TestBase : WebBrowser
    {
        protected Home _home;
        protected Login _login;
        protected DashBoard _dashboard;
        private ExtentReports _extent;
        private ExtentTest _test;

        protected string username = "bridge8259";
        protected string password = "bridge8259";

        protected void SetUpExtentReports()
        {
            try
            {
                //To create report directory and add HTML report into it
                _extent = new ExtentReports();
                string dateTimeNow = DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss");
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\netcoreapp2.1","");
                DirectoryInfo createReportDirectory = Directory.CreateDirectory(currentDirectory + "\\Test_Execution_Reports");
                ExtentV3HtmlReporter htmlReporter = new ExtentV3HtmlReporter($"{currentDirectory}\\Test_Execution_Reports\\report-{dateTimeNow}.html");
                htmlReporter.Config.Theme = Theme.Dark;
                _extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        protected void CreateTestInExtentReport()
        {
            try
            {
                _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        protected void LogTestStatus()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        string screenShotPath = TakeScreenShot(TestContext.CurrentContext.Test.Name);
                        _test.Log(logstatus, "Test ended with " +logstatus + " – " +errorMessage);
                        _test.Log(logstatus, "Snapshot below: " +_test.AddScreenCaptureFromPath(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                    default:
                        logstatus = Status.Pass;
                        _test.Log(logstatus, "Test ended with " + logstatus);
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        protected void PublishExtentReports()
        {
            try
            {
                _extent.Flush();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
