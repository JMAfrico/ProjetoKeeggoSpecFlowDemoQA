using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Pages;
using SpecFlowDemoQA.Utils;

namespace SpecFlowDemoQA.Logic
{
    public class HomePageLogic
    {
        private HomePage homePage;
        private IWebDriver driver;
        private WebDriverWait wait;
        public HomePageLogic(TestFixture testFixture)
        {
            
            driver = testFixture.driver;
            homePage = new HomePage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));           
        }

        public void NavegarParaHomePage()
        {
            homePage.AbrirSite();
        }

        internal void VerificarOTiTuloDaPagina()
        {
            string step = "Verifico o título da pagina";
            IWebElement txtHome = wait.Until(d => d.FindElement(homePage.txtSiteDemoQA));
            driver.TakesScreenshot(step);

        }

        internal void ValidarHomePage()
        {
            IWebElement txtHome = wait.Until(d => d.FindElement(homePage.txtSiteDemoQA));
            if (txtHome.Displayed)
            {
                string step = "Valido a home Page";
                driver.TakesScreenshot(step);
                Assert.True(txtHome.Displayed);
            }
            
        }
    }
}
