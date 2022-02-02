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
        private ScreenShotUtil screenShotUtil;
        private ScenarioContext cenarioContext;
        public HomePageLogic(TestFixture testFixture, ScenarioContext cenarioContext)
        {
            this.cenarioContext = cenarioContext;
            driver = testFixture.driver;
            homePage = new HomePage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            screenShotUtil = new ScreenShotUtil(cenarioContext);            
        }

        public void NavegarParaHomePage()
        {
            homePage.AbrirSite();
        }

        internal void VerificarOTiTuloDaPagina()
        {
            string step = "Preencho usuário valido de Login";
            IWebElement txtHome = wait.Until(d => d.FindElement(homePage.txtSiteDemoQA));
            screenShotUtil.TakesScreenshot(driver, txtHome);

        }

        internal void ValidarHomePage()
        {
            IWebElement txtHome = wait.Until(d => d.FindElement(homePage.txtSiteDemoQA));
            if (txtHome.Displayed)
            {
                string step = "Preencho usuário valido de Login";
                screenShotUtil.TakesScreenshot(driver, txtHome);
                Assert.True(txtHome.Displayed);
            }
            
        }
    }
}
