using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowDemoQA.Helpers;

namespace SpecFlowDemoQA.Fixture
{
    public class TestFixture : IDisposable
    {
        public IWebDriver driver { get; private set; }
        public ExtentReports extent;

        public TestFixture()
        {
            driver = new ChromeDriver(LocalDriver.PastaDoExecutavel);
            extent = new ExtentReports();        
        }
        public void Dispose()
        {
            driver.Quit();
        }

    }
}
