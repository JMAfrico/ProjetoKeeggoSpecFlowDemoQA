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
        private LoginPage loginPage;
        WebDriverWait wait;

        public LoginStepDefinitions(TestFixture fixture)
        {
            driver = fixture.driver;
            loginPage = new LoginPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Given(@"que estou no site")]
        public void GivenQueNaoEstouLogadoNoSite()
        {
            loginPage.AbrirSite();
        }

        [When(@"clico em login")]
        public void WhenClicoEmLogin()
        {
            IWebElement BtnLogin = wait.Until(d => d.FindElement(loginPage.btnLogin));
            BtnLogin.Click();
        }

        [When(@"preencho usuario de login")]
        public void WhenPreenchoUsuarioDeLogin()
        {
            var UserName = wait.Until(e => e.FindElement(loginPage.txtUser));            
            UserName.SendKeys("JOAOQA22");
            
        }

        [When(@"preencho senha de login")]
        public void WhenPreenchoSenhaDeLogin()
        {
            var Password = wait.Until(e => e.FindElement(loginPage.txtSenha));
            Password.SendKeys("Senha@123456");
        }

        [Then(@"valido que estou logado no site")]
        public void ThenValidoQueEstouLogadoNoSite()
        {
            bool Logado = wait.Until(e => e.FindElement(loginPage.BtnLogOut).Displayed);
            Assert.True(Logado);
        }
    }
}
