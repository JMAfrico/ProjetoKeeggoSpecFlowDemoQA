using OpenQA.Selenium;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Logic;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDemoQA.StepDefinitions
{
    [Binding]
    public class HomePageStepDefinitions
    {
        private IWebDriver driver;
        private HomePageLogic homePageLogic;
        private ScenarioContext scenarioContext;

        public HomePageStepDefinitions(TestFixture fixture, ScenarioContext cenarioContext)
        {   
            this.scenarioContext = cenarioContext;
            driver = fixture.driver;
            homePageLogic = new HomePageLogic(fixture,cenarioContext);
        }

        [Given(@"que navego para pagina inicial")]
        public void GivenQueNavegoParaPaginaInicial()
        {
            homePageLogic.NavegarParaHomePage();
        }

        [When(@"verifico o titulo da pagina")]
        public void WhenVerificoOTituloDaPagina()
        {
            homePageLogic.VerificarOTiTuloDaPagina();
        }

        [Then(@"valido que estou na home page")]
        public void ThenValidoQueEstouNaHomePage()
        {
            homePageLogic.ValidarHomePage();
        }
    }
}
