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

        [When(@"clico em novo usuario de login")]
        public void WhenClicoEmNovoUsuarioDeLogin()
        {
            loginLogic.ClicoEmNovoUsuarioDeLogin();
        }

        [When(@"preencho o campo primeiro nome de novo usuario")]
        public void WhenPreenchoOCampoPrimeiroNomeDeNovoUsuario()
        {
            loginLogic.PreenchoOPrimeiroNomeDeNovoUsuario();
        }

        [When(@"preencho o campo ultimo nome de novo usuario")]
        public void WhenPreenchoOCampoUltimoNomeDeNovoUsuario()
        {
            loginLogic.PreenchoUltimoNomeDeNovoUsuario();
        }

        [When(@"preencho o campo usuario de novo usuario")]
        public void WhenPreenchoOCampoUsuarioDeNovoUsuario()
        {
            loginLogic.PreenchoOCampoUserNameDeNovoUsuario();
        }

        [When(@"preencho o campo senha de novo usuario")]
        public void WhenPreenchoOCampoSenhaDeNovoUsuario()
        {
            loginLogic.PreenchoOCampoSenhaDeNovoUsuario();
        }

        [When(@"clico na opcao nao sou um robo")]
        public void WhenClicoNaOpcaoNaoSouUmRobo()
        {
            loginLogic.ClicoNaOpcaoNaoSouUmRobo();
        }

        [When(@"clico em registrar")]
        public void WhenClicoEmRegistrar()
        {
            loginLogic.ClicoBtnRegistrarNovoUsuario();
        }

        [Then(@"valido a mensagem de usuario cadastrado")]
        public void ThenValidoAMensagemDeUsuarioCadastrado()
        {
            loginLogic.ValidoMensagemNovoUsuarioCadastrado();
        }

        [Then(@"valido a mensagem de erro ao efetuar cadastro")]
        public void ThenValidoAMensagemDeErroAoEfetuarCadastro()
        {
            loginLogic.ValidoMensagemDeErroAoEfetuarNovoCadastro();
        }

        [Then(@"valido a mensagem de usuario existente")]
        public void ThenValidoAMensagemDeUsuarioExistente()
        {
            loginLogic.ValidoMensagemDeErroAoEfetuarNovoCadastroUsuarioJaExiste();
        }
    }
}
