using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Helpers;
using SpecFlowDemoQA.Pages;
using SpecFlowDemoQA.Utils;

namespace SpecFlowDemoQA.Logic
{
    [Collection("Chrome Driver")]
    public class LoginLogic
    {
        private LoginPage loginPage;
        private IWebDriver driver;
        private WebDriverWait wait;
        private CSVHelper csvHelper;
        private IJavaScriptExecutor js;

        public LoginLogic(TestFixture fixture)
        {
            driver = fixture.driver;
            loginPage = new LoginPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            csvHelper = new CSVHelper();
            js = (IJavaScriptExecutor)driver;
        }

        public void ClicarBtnLogin()
        {
            string step = "Clico no botão 'Login'";
            IWebElement BtnLogin = wait.Until(d => d.FindElement(loginPage.BtnLogin));
            driver.TakesScreenshot(step) ;
            BtnLogin.Click();
        }

        public void PreencherUsuarioValidoDeLogin()
        {
            
            string step = "Preencho usuário 'valido' de Login";
            var nome = csvHelper.GetValueByRowAndColumn(DataHelper.GetFileCSVLogin(), 1, "First_name");
            var UserName = wait.Until(e => e.FindElement(loginPage.TxtUser));            
            UserName.SendKeys(nome);
            driver.TakesScreenshot(step);
        }
        
        public void PreencherSenhaValidaDeLogin()
        {
            string step = "Preencho senha 'valida' de Login";
            var senha = csvHelper.GetValueByRowAndColumn(DataHelper.GetFileCSVLogin(), 1, "Password");
            var Password = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            Password.SendKeys(senha);
            driver.TakesScreenshot(step);
        }

        public void ValidarLoginEfetuado()
        {
            string step = "Valido 'login efetuado'";
            IWebElement btnLogOut = wait.Until(e => e.FindElement(loginPage.BtnLogOut));
            bool Logado = btnLogOut.Displayed;
            driver.TakesScreenshot(step);         
            Assert.True(Logado);
        }

        public void ValidoLoginSenhaOuUsuarioInvalido()
        {
            string step = "Valido mensagem de 'senha ou usuário invalido'";
            var lblLoginInvalido = wait.Until(e => e.FindElement(loginPage.LblInvalidoLoginOuSenha));           
            js.ExecuteScript("arguments[0].scrollIntoView(true);", lblLoginInvalido);
            bool loginErro = lblLoginInvalido.Displayed;
            driver.TakesScreenshot(step);          
            Assert.True(loginErro);
        }

        public void PreencherUsuarioInvalidoDeLogin()
        {
            string step = "Preencho usuário 'invalido' de login";
            var nome = csvHelper.GetValueByRowAndColumn(DataHelper.GetFileCSVLogin(), 2, "First_name");
            var UserName = wait.Until(e => e.FindElement(loginPage.TxtUser));
            UserName.SendKeys(nome);
            driver.TakesScreenshot(step);
            
        }

        public void PreencherSenhaInvalidaDeLogin()
        {
            string step = "Preencho senha 'inválida' de login";
            var senha = csvHelper.GetValueByRowAndColumn(DataHelper.GetFileCSVLogin(), 2, "Password");
            var Password = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            Password.SendKeys(senha);
            driver.TakesScreenshot(step);
           
        }

        public void ClicoEmNovoUsuarioDeLogin()
        {
            string step = "Clico em 'novo Usuario'";
            var btnNovoUsuario = wait.Until(e =>e.FindElement(loginPage.BtnNewUser));
            driver.TakesScreenshot(step);
            btnNovoUsuario.Click();
        }

        public void PreenchoOPrimeiroNomeDeNovoUsuario()
        {
            string step = "Preencho o 'primeiro nome' do novo usuario";
            var firstname = csvHelper.GetValueByRowAndColumn(DataHelper.GetFileCSVCadastro(), 13, "first_name");
            var txtNomeUsuario = wait.Until(e => e.FindElement(loginPage.TxtFirstName));
            txtNomeUsuario.SendKeys(firstname);
            driver.TakesScreenshot(step);
            
        }

        public void PreenchoUltimoNomeDeNovoUsuario()
        {
            string step = "Preencho o 'ultimo nome' do novo usuario";
            var lastname = csvHelper.GetValueByRowAndColumn(DataHelper.GetFileCSVCadastro(), 13, "last_name");
            var txtSobrenomeUsuario = wait.Until(e => e.FindElement(loginPage.TxtLastName));
            txtSobrenomeUsuario.SendKeys(lastname);
            driver.TakesScreenshot(step);
            
        }

        public void PreenchoOCampoUserNameDeNovoUsuario()
        {
            string step = "Preencho o 'User Name' do novo usuario";
            var username = csvHelper.GetValueByRowAndColumn(DataHelper.GetFileCSVCadastro(), 13, "usuario");//6 cadastro de usuario invalido //14 novo cadastro
            var txtLastName = wait.Until(e => e.FindElement(loginPage.TxtUser));
            txtLastName.SendKeys(username);
            driver.TakesScreenshot(step);

        }

        public void PreenchoOCampoSenhaDeNovoUsuario()
        {
            string step = "Preencho a 'Senha' do novo usuario";
            var senha = csvHelper.GetValueByRowAndColumn(DataHelper.GetFileCSVCadastro(), 13, "senha");
            var txtSenha = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            txtSenha.SendKeys(senha);
            driver.TakesScreenshot(step);
        }

        public void ClicoNaOpcaoNaoSouUmRobo()
        {
            string step = "Clico na opcao 'nao sou um robo' de ReCAPCHA";
            var BtnNaoSouRobo = wait.Until(e => e.FindElement(loginPage.BtnRecapcha));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", BtnNaoSouRobo);
            driver.TakesScreenshot(step);     
            BtnNaoSouRobo.Click();
            Thread.Sleep(10000);
        }

        public void ClicoBtnRegistrarNovoUsuario()
        {
            string step = "Clico em 'Registrar' de novo usuario";
            var BtnRegistrar = wait.Until(e => e.FindElement(loginPage.BtnRegister));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", BtnRegistrar);
            driver.TakesScreenshot(step);
            BtnRegistrar.Click();
        }
        public void ValidoMensagemNovoUsuarioCadastrado()
        {
            string step = "Valido a mensagem de 'usuario cadastro com sucesso'";

            if (isAlertPresent()) {                         
                var TextoEsperadoDoAlerta = "User Register Successfully.";
                IAlert alerta = driver.SwitchTo().Alert();
                string textoDoAlerta = alerta.Text;
                driver.TakesScreenshot(step);
                Assert.Equal(TextoEsperadoDoAlerta,textoDoAlerta);
                alerta.Accept();
            }
            driver.TakesScreenshot(step);
        }

        public bool isAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;             
            } 
        }

        public void ValidoMensagemDeErroAoEfetuarNovoCadastro()
        {
            string step = "Valido mensagem de 'erro ao efetuar novo cadastro'";
            var MsgErro = wait.Until(e => e.FindElement(loginPage.lblMensagemErroCadastro));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", MsgErro);
            driver.TakesScreenshot(step);
            Assert.True(MsgErro.Displayed);
        }

        public void ValidoMensagemDeErroAoEfetuarNovoCadastroUsuarioJaExiste()
        {
            string step = "Valido mensagem de erro 'usuario ja existe''";
            var MsgErro = wait.Until(e => e.FindElement(loginPage.lblMensagemErroUsuarioJaExiste));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", MsgErro);
            driver.TakesScreenshot(step);
            Assert.True(MsgErro.Displayed);
        }
    }
}
