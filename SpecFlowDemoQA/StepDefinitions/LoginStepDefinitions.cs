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

        public LoginStepDefinitions(TestFixture fixture)
        {
            driver = fixture.driver;
            loginLogic = new LoginLogic(fixture);
        }

        [Given(@"que estou no site")]
        public void GivenQueEstouNoSite()
        {
            loginLogic.EntrarNoSite();
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
    }
}
