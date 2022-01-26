using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowDemoQA.Helpers;

namespace SpecFlowDemoQA.Fixture
{
    public class TestFixture : IDisposable
    {
        public IWebDriver driver { get; private set; }

        public TestFixture()
        {
            driver = new ChromeDriver(LocalDriver.PastaDoExecutavel);
        }
        public void Dispose()
        {
            driver.Quit();
        }
    }
}
