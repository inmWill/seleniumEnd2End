using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using Protractor;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CoreUITests
{
    [TestFixture]
    public class CoreUI
    {
        // public static string baseUrl = "http://localhost:10101/";
        private const string BaseUrl = "http://coreui.azurewebsites.net/";
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            // Using NuGet Package 'PhantomJS'
            //_driver = new NgWebDriver(new PhantomJSDriver(@"dependencies"));

            // Using NuGet Package 'WebDriver.ChromeDriver.win32'
            _driver = new NgWebDriver(new ChromeDriver(@"dependencies"));

            // Using NuGet Package 'WebDriver.IEDriverServer.win32'
            //var options = new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
            //driver = new InternetExplorerDriver(options);

            _driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test(Description = "Dashboard should have title of ui.core: dashboard")]
        public void DashboardTitle()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(BaseUrl);
                Assert.AreEqual(_driver.Title, "ui.core: dashboard");
            }
        }

        [Test(Description = "People should have title of ui.core: people")]
        public void PeopleTitle()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(BaseUrl + "people");
                Assert.AreEqual(_driver.Title, "ui.core: people");
            }
        }
    }
}