using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumEnd2End
{
    class CoreTests
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://coreui.azurewebsites.net/";

            var pageTitle = driver.Title;
            Assert.AreEqual("Google", selenium.GetTitle());
        }

        
    }
}
