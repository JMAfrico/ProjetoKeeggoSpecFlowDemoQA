using AventStack.ExtentReports;
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
            string step = "Clico em login";
            IWebElement BtnLogin = wait.Until(d => d.FindElement(loginPage.BtnLogin));
            ScreenShotUtil.TakesScreenshot(driver,BtnLogin,step);
            BtnLogin.Click();
        }

        public void PreencherUsuarioValidoDeLogin()
        {
            string step = "Preencho usuário valido de Login";
            var nome = csvHelper.GetValueByRowAndColumn("login.csv", 1, "First_name");
            var UserName = wait.Until(e => e.FindElement(loginPage.TxtUser));            
            UserName.SendKeys(nome);
            ScreenShotUtil.TakesScreenshot(driver, UserName,step);
        }
        
        public void PreencherSenhaValidaDeLogin()
        {
            string step = "Preencho senha valida de Login";
            var senha = csvHelper.GetValueByRowAndColumn("login.csv", 1, "Password");
            var Password = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            Password.SendKeys(senha);
            ScreenShotUtil.TakesScreenshot(driver, Password, step);
        }

        public void ValidarLoginEfetuado()
        {
            string step = "Valido Login Efetuado";
            IWebElement btnLogOut = wait.Until(e => e.FindElement(loginPage.BtnLogOut));
            bool Logado = btnLogOut.Displayed;
            ScreenShotUtil.TakesScreenshot(driver, btnLogOut, step); 
            Assert.True(Logado);
        }

        public void ValidoLoginSenhaOuUsuarioInvalido()
        {
            string step = "Valido senha ou usuário invalido";
            var lblLoginInvalido = wait.Until(e => e.FindElement(loginPage.LblInvalidoLoginOuSenha));           
            js.ExecuteScript("arguments[0].scrollIntoView(true);", lblLoginInvalido);
            bool loginErro = lblLoginInvalido.Displayed;
            ScreenShotUtil.TakesScreenshot(driver, lblLoginInvalido, step);
            Assert.True(loginErro);
        }

        public void PreencherUsuarioInvalidoDeLogin()
        {
            string step = "Preencho usuário invalido de Login";
            var nome = csvHelper.GetValueByRowAndColumn("login.csv", 2, "First_name");
            var UserName = wait.Until(e => e.FindElement(loginPage.TxtUser));
            UserName.SendKeys(nome);
            ScreenShotUtil.TakesScreenshot(driver, UserName, step);
        }

        public void PreencherSenhaInvalidaDeLogin()
        {
            string step = "Preencho senha inválida de Login";
            var senha = csvHelper.GetValueByRowAndColumn("login.csv", 2, "Password");
            var Password = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            Password.SendKeys(senha);
            ScreenShotUtil.TakesScreenshot(driver, Password, step);
        }
    }  
}
