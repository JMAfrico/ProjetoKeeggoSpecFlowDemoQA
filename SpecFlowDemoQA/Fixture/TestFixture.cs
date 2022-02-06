using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowDemoQA.Helpers;

namespace SpecFlowDemoQA.Fixture
{
    public class TestFixture : IDisposable
    {
        public IWebDriver driver;

        public TestFixture()
        {
            driver = new ChromeDriver(LocalDriver.GetPastaDoExecutavel());     
        }
        public void Dispose()
        {
            driver.Quit();
        }

    }
}
