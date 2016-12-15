using System;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using Protractor;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CoreUITests
{
    [TestFixture]
    public class TestOtherSites
    {
        // public static string baseUrl = "http://localhost:10101/";
        private const string BaseUrl = "https://trashmail.com/";
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

        [Test(Description = "Trashmail should have title of TrashMail - Disposable email addresses")]
        public void TrashMailTitle()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(BaseUrl);
                Assert.AreEqual(_driver.Title, "TrashMail - Disposable email addresses");
            }
        }


        [Test(Description = "Trashmail should have domain of @Trashmail.com")]
        public void DefaultDomain()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(BaseUrl);
                var domain = _driver.FindElement(NgBy.Model("selectedDomain"));

                Assert.AreEqual(domain.Text, "@trashmail.com ");
            }
        }

        [Test(Description = "CAPTCHA should be set to Disable")]
        public void DefaultCAPTCHA()
        {
            using (_driver)
            {
                _driver.Navigate().GoToUrl(BaseUrl);
                var checkboxes = _driver.FindElements(By.XPath("//input[@name='form_whitelisting']"));

                foreach (var checkbox in checkboxes)
                {
                    if (checkbox.Selected && checkbox.Displayed)
                    {
                        var label = checkbox.FindElement(By.XPath(".."));

                        Assert.AreEqual(label.Text, "Disable CAPTCHA system");
                    }
                }

            }
        }







    }
}
