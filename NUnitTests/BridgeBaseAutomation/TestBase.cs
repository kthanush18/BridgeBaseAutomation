using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.BridgeBaseAutomation
{
    public class TestBase
    {
        protected Home _home;
        protected Login _login;
        protected DashBoard _dashboard;
        protected ExtentReports _extent;
        protected ExtentTest _test;

        protected string username = "bridge8259";
        protected string password = "bridge8259";

        protected void SetUpExtentReports()
        {
            try
            {
                //To create report directory and add HTML report into it
                _extent = new ExtentReports();
                string dateTimeNow = DateTime.Now.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss");
                ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter($@"D:\Professional\C#Projects\NUnitTests\TestReports\report{dateTimeNow}.html");
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
                        _test.Log(logstatus, "Test ended with " + logstatus + " – " + errorMessage);
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
