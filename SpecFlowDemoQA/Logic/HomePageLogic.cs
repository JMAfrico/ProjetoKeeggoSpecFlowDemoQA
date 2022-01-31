using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Pages;
using SpecFlowDemoQA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IWebElement txtHome = wait.Until(d => d.FindElement(homePage.txtSiteDemoQA));
            screenShotUtil.TakesScreenshot(driver, txtHome);

        }

        internal void ValidarHomePage()
        {
            IWebElement txtHome = wait.Until(d => d.FindElement(homePage.txtSiteDemoQA));
            if (txtHome.Displayed)
            {
                screenShotUtil.TakesScreenshot(driver, txtHome);
                Assert.True(txtHome.Displayed);
            }
            
        }
    }
}
