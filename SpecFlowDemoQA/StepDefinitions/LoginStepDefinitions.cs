using OpenQA.Selenium;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Logic;

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
