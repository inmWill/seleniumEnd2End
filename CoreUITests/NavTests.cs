using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CoreUITests
{
    [TestClass]
    public class CoreUI
    {
       // public static string baseUrl = "http://localhost:10101/";
        public static string baseUrl = "http://coreui.azurewebsites.net/";

        [TestMethod]
        public void DashboardTitle()
        {
            using (IWebDriver wdriver = new NgWebDriver(new ChromeDriver(@"dependencies")))
            {
                wdriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(5));
                wdriver.Navigate().GoToUrl(baseUrl);
                Assert.AreEqual(wdriver.Title, "ui.core: dashboard");
                wdriver.Quit();
            }
        }

        [TestMethod]
        public void PeopleTitle()
        {
            using (IWebDriver wdriver = new NgWebDriver(new ChromeDriver(@"dependencies")))
            {
                wdriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(5));
                wdriver.Navigate().GoToUrl(baseUrl + "people");
                Assert.AreEqual(wdriver.Title, "ui.core: people");
                wdriver.Quit();
            }
        }
    }
}