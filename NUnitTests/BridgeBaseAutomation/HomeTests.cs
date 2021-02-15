using NUnit.Framework;
using static Com.Common.Web.WebBrowser;

namespace com.BridgeBaseAutomation
{
    [TestFixture]
    public class HomeTests : TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            SetUpExtentReports();
            _home = new Home();
            _home.LaunchBrowser(BrowserType.CHROME);
            _home.NavigateToURL("https://www.bridgebase.com/");
        }

        [SetUp]
        public void SetUp()
        {
            CreateTestInExtentReport();
            _login = new Login();
            _dashboard = new DashBoard();
        }

        [Test,Order(1)]
        public void LoginToBridgeBase_VerifyUserName()
        {
            _home.GoToLoginPage();
            _login.EnterCredentialsAndLogin(username,password);
            string usernameFromDashBoard = _dashboard.GetUsername();

            Assert.AreEqual(usernameFromDashBoard, username);
        }

        [Test,Order(2)]
        public void LoginToBridgeBase_IsLogOffButtonVisible()
        {
            bool isLogOffButtonVisible = _dashboard.IsLogOffButtonVisible();

            Assert.IsTrue(isLogOffButtonVisible);
        }

        [Test, Order(3)]
        public void NavigateToPractice_IsStartBiddingTableVisible()
        {
            _dashboard.NavigateToPractice();
            bool isStartBiddingTableVisible = _dashboard.IsStartBiddingTableVisible();

            Assert.IsTrue(isStartBiddingTableVisible);
        }

        [Test, Order(4)]
        public void NavigateToPractice_IsStartTeachingTableVisible()
        {
            bool isTeachBiddingTableVisible = _dashboard.IsStartBiddingTableVisible();

            Assert.IsTrue(isTeachBiddingTableVisible);
        }

        [Test, Order(5)]
        public void NavigateToPractice_IsBridgeMasterVisible()
        {
            bool isBridgeMasterVisible = _dashboard.IsBridgeMasterVisible();

            Assert.IsTrue(isBridgeMasterVisible);
        }

        [TearDown]
        public void TearDown()
        {
            LogTestStatus();  
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _home.CloseBrowser();
            PublishExtentReports();
        }
    }
}
