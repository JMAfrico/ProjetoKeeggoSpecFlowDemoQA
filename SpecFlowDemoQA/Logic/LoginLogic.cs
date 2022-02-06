﻿using OpenQA.Selenium;
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
            ScreenShotUtil.TakesScreenshot(driver,step) ;
            BtnLogin.Click();
        }

        public void PreencherUsuarioValidoDeLogin()
        {
            string step = "Preencho usuário 'valido' de Login";
            var nome = csvHelper.GetValueByRowAndColumn("login.csv", 1, "First_name");
            var UserName = wait.Until(e => e.FindElement(loginPage.TxtUser));            
            UserName.SendKeys(nome);
            ScreenShotUtil.TakesScreenshot(driver, step);
        }
        
        public void PreencherSenhaValidaDeLogin()
        {
            string step = "Preencho senha 'valida' de Login";
            var senha = csvHelper.GetValueByRowAndColumn("login.csv", 1, "Password");
            var Password = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            Password.SendKeys(senha);
            ScreenShotUtil.TakesScreenshot(driver, step);
        }

        public void ValidarLoginEfetuado()
        {
            string step = "Valido 'login efetuado'";
            IWebElement btnLogOut = wait.Until(e => e.FindElement(loginPage.BtnLogOut));
            bool Logado = btnLogOut.Displayed;
            ScreenShotUtil.TakesScreenshot(driver, step); 
            Assert.True(Logado);
        }

        public void ValidoLoginSenhaOuUsuarioInvalido()
        {
            string step = "Valido mensagem de 'senha ou usuário invalido'";
            var lblLoginInvalido = wait.Until(e => e.FindElement(loginPage.LblInvalidoLoginOuSenha));           
            js.ExecuteScript("arguments[0].scrollIntoView(true);", lblLoginInvalido);
            bool loginErro = lblLoginInvalido.Displayed;
            ScreenShotUtil.TakesScreenshot(driver, step);
            Assert.True(loginErro);
        }

        public void PreencherUsuarioInvalidoDeLogin()
        {
            string step = "Preencho usuário 'invalido' de login";
            var nome = csvHelper.GetValueByRowAndColumn("login.csv", 2, "First_name");
            var UserName = wait.Until(e => e.FindElement(loginPage.TxtUser));
            UserName.SendKeys(nome);
            ScreenShotUtil.TakesScreenshot(driver, step);
        }

        public void PreencherSenhaInvalidaDeLogin()
        {
            string step = "Preencho senha 'inválida' de login";
            var senha = csvHelper.GetValueByRowAndColumn("login.csv", 2, "Password");
            var Password = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            Password.SendKeys(senha);
            ScreenShotUtil.TakesScreenshot(driver, step);
        }

        public void ClicoEmNovoUsuarioDeLogin()
        {
            string step = "Clico em 'novo Usuario'";
            var btnNovoUsuario = wait.Until(e =>e.FindElement(loginPage.BtnNewUser));
            ScreenShotUtil.TakesScreenshot(driver, step);
            btnNovoUsuario.Click();
        }

        public void PreenchoOPrimeiroNomeDeNovoUsuario()
        {
            string step = "Preencho o 'primeiro nome' do novo usuario";
            var firstname = csvHelper.GetValueByRowAndColumn("novoUsuario.csv", 12, "first_name");
            var txtNomeUsuario = wait.Until(e => e.FindElement(loginPage.TxtFirstName));
            txtNomeUsuario.SendKeys(firstname);
            ScreenShotUtil.TakesScreenshot(driver, step);
        }

        public void PreenchoUltimoNomeDeNovoUsuario()
        {
            string step = "Preencho o 'ultimo nome' do novo usuario";
            var lastname = csvHelper.GetValueByRowAndColumn("novoUsuario.csv", 12, "last_name");
            var txtSobrenomeUsuario = wait.Until(e => e.FindElement(loginPage.TxtLastName));
            txtSobrenomeUsuario.SendKeys(lastname);
            ScreenShotUtil.TakesScreenshot(driver, step);
        }

        public void PreenchoOCampoUserNameDeNovoUsuario()
        {
            string step = "Preencho o 'User Name' do novo usuario";
            var username = csvHelper.GetValueByRowAndColumn("novoUsuario.csv", 12, "usuario");
            var txtLastName = wait.Until(e => e.FindElement(loginPage.TxtUser));
            txtLastName.SendKeys(username);
            ScreenShotUtil.TakesScreenshot(driver, step);
        }

        public void PreenchoOCampoSenhaDeNovoUsuario()
        {
            string step = "Preencho a 'Senha' do novo usuario";
            var senha = csvHelper.GetValueByRowAndColumn("novoUsuario.csv", 12, "senha");
            var txtSenha = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            txtSenha.SendKeys(senha);
            ScreenShotUtil.TakesScreenshot(driver, step);
        }

        public void ClicoNaOpcaoNaoSouUmRobo()
        {
            string step = "Clico na opcao 'nao sou um robo' de ReCAPCHA";
            var BtnNaoSouRobo = wait.Until(e => e.FindElement(loginPage.BtnRecapcha));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", BtnNaoSouRobo);
            ScreenShotUtil.TakesScreenshot(driver, step);     
            BtnNaoSouRobo.Click();
            Thread.Sleep(10000);
        }

        public void ClicoBtnRegistrarNovoUsuario()
        {
            string step = "Clico em 'Registrar' de novo usuario";
            var BtnRegistrar = wait.Until(e => e.FindElement(loginPage.BtnRegister));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", BtnRegistrar);
            ScreenShotUtil.TakesScreenshot(driver,step);
            BtnRegistrar.Click();
        }
        public void ValidoMensagemNovoUsuarioCadastrado()
        {
            if (isAlertPresent()) { 
                string step = "Valido a mensagem de 'usuario cadastro com sucesso'";              
                var TextoEsperadoDoAlerta = "User Register Successfully.";
                IAlert alerta = driver.SwitchTo().Alert();
                alerta.Accept();
                string textoDoAlerta = alerta.Text;
                ScreenShotUtil.TakesScreenshot(driver, step);
                Assert.Equal(TextoEsperadoDoAlerta,textoDoAlerta);
                alerta.Accept();
            }
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
            ScreenShotUtil.TakesScreenshot(driver, step);
            Assert.True(MsgErro.Displayed);
        }

        public void ValidoMensagemDeErroAoEfetuarNovoCadastroUsuarioJaExiste()
        {
            string step = "Valido mensagem de erro 'usuario ja existe''";
            var MsgErro = wait.Until(e => e.FindElement(loginPage.lblMensagemErroUsuarioJaExiste));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", MsgErro);
            ScreenShotUtil.TakesScreenshot(driver, step);
            Assert.True(MsgErro.Displayed);
        }
    }
}
