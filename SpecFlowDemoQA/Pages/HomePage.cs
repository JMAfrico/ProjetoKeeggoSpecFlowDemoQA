using OpenQA.Selenium;

namespace SpecFlowDemoQA.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        public By txtSiteDemoQA { get; private set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            txtSiteDemoQA = By.XPath("//a[contains(@href,'demoqa')]");
        }
        public void AbrirSite()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/books");
            driver.Manage().Window.Maximize();
        }
    }
}
