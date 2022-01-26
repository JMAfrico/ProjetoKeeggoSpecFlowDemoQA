using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Pages;
using SpecFlowDemoQA.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoQA.Logic
{
    [Collection("Chrome Driver")]
    public class LoginLogic
    {   
        private LoginPage loginPage;
        private IWebDriver driver;
        WebDriverWait wait;

        public LoginLogic(TestFixture fixture)
        {
            driver = fixture.driver;
            loginPage = new LoginPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        internal void EntrarNoSite()
        {
            loginPage.AbrirSite();
        }

        internal void ClicarBtnLogin()
        {
            IWebElement BtnLogin = wait.Until(d => d.FindElement(loginPage.btnLogin));
            BtnLogin.Click();
        }

        internal void PreencherUsuarioValidoDeLogin()
        {
            var UserName = wait.Until(e => e.FindElement(loginPage.txtUser));
            UserName.SendKeys("JOAOQA22");
        }

        internal void PreencherSenhaValidaDeLogin()
        {
            var Password = wait.Until(e => e.FindElement(loginPage.txtSenha));
            Password.SendKeys("Senha@123456");
        }

        internal void ValidarLoginEfetuado()
        {
            bool Logado = wait.Until(e => e.FindElement(loginPage.BtnLogOut).Displayed);
            Assert.True(Logado);
        }
    }  
}
