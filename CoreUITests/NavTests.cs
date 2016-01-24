using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CoreUITests
{
    [TestClass]
    public class CoreUI
    {
        public static string baseUrl = "http://localhost:10101/";

        [TestMethod]
        public void DashboardTitle()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl(baseUrl);
                wdriver.Manage().Window.Maximize();
                Assert.AreEqual(wdriver.Title, "ui.core: dashboard");
                wdriver.Quit();
            }
        }

        [TestMethod]
        public void PeopleTitle()
        {
            using (IWebDriver wdriver = new ChromeDriver(@"dependencies"))
            {
                wdriver.Navigate().GoToUrl(baseUrl + "people");
                wdriver.Manage().Window.Maximize();
                Assert.AreEqual(wdriver.Title, "ui.core: people");
                wdriver.Quit();
            }
        }
    }
}