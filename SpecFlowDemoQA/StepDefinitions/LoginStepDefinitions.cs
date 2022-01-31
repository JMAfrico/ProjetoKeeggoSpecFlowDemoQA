using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Logic;
using SpecFlowDemoQA.Pages;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowDemoQA.StepDefinitions
{
    [Binding]
    [Collection("Chrome Driver")]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        private LoginLogic loginLogic;
        private ScenarioContext cenarioContext;

        public LoginStepDefinitions(TestFixture fixture, ScenarioContext cenarioContext)
        {
            this.cenarioContext = cenarioContext;
            driver = fixture.driver;
            loginLogic = new LoginLogic(fixture,cenarioContext);       
        }      
        
        [When(@"clico em login")]
        public void WhenClicoEmLogin()
        {
            loginLogic.ClicarBtnLogin();
        }

        [When(@"preencho usuario valido de login")]
        public void WhenPreenchoUsuarioValidoDeLogin()
        {
            loginLogic.PreencherUsuarioValidoDeLogin();
        }

        [When(@"preencho senha valida de login")]
        public void WhenPreenchoSenhaValidaDeLogin()
        {
            loginLogic.PreencherSenhaValidaDeLogin();
        }

        [Then(@"valido que estou logado no site")]
        public void ThenValidoQueEstouLogadoNoSite()
        {
            loginLogic.ValidarLoginEfetuado();
        }

        [When(@"preencho usuario invalido de login")]
        public void WhenPreenchoUsuarioInvalidoDeLogin()
        {
            loginLogic.PreencherUsuarioInvalidoDeLogin();
        }

        [When(@"preencho senha invalida de login")]
        public void WhenPreenchoSenhaInvalidaDeLogin()
        {
            loginLogic.PreencherSenhaInvalidaDeLogin();
        }

        [Then(@"valido que nao estou logado no site")]
        public void ThenValidoQueNaoEstouLogadoNoSite()
        {
            loginLogic.ValidoLoginSenhaOuUsuarioInvalido();
        }
    }
}
