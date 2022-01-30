using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
        private ScreenShotUtil screenShotUtil;

        public LoginLogic(TestFixture fixture)
        {
            driver = fixture.driver;
            loginPage = new LoginPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            csvHelper = new CSVHelper();
            js = (IJavaScriptExecutor)driver;
            screenShotUtil = new ScreenShotUtil();
        }

        public void ClicarBtnLogin()
        {
            IWebElement BtnLogin = wait.Until(d => d.FindElement(loginPage.BtnLogin));
            screenShotUtil.TakesScreenshot(driver,BtnLogin);
            BtnLogin.Click();
        }

        public void PreencherUsuarioValidoDeLogin()
        {
            var nome = csvHelper.GetValueByRowAndColumn("login.csv", 1, "First_name");
            var UserName = wait.Until(e => e.FindElement(loginPage.TxtUser));            
            UserName.SendKeys(nome);
            screenShotUtil.TakesScreenshot(driver,UserName);
        }
        
        public void PreencherSenhaValidaDeLogin()
        {
            var senha = csvHelper.GetValueByRowAndColumn("login.csv", 1, "Password");
            var Password = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            Password.SendKeys(senha);
            screenShotUtil.TakesScreenshot(driver,Password);
        }

        public void ValidarLoginEfetuado()
        {
            IWebElement btnLogOut = wait.Until(e => e.FindElement(loginPage.BtnLogOut));
            bool Logado = btnLogOut.Displayed;
            screenShotUtil.TakesScreenshot(driver,btnLogOut); 
            Assert.True(Logado);
        }

        public void ValidoLoginSenhaOuUsuarioInvalido()
        {
            var lblLoginInvalido = wait.Until(e => e.FindElement(loginPage.LblInvalidoLoginOuSenha));           
            js.ExecuteScript("arguments[0].scrollIntoView(true);", lblLoginInvalido);
            bool loginErro = lblLoginInvalido.Displayed;
            screenShotUtil.TakesScreenshot(driver,lblLoginInvalido);
            Assert.True(loginErro);
        }

        public void PreencherUsuarioInvalidoDeLogin()
        {
            var nome = csvHelper.GetValueByRowAndColumn("login.csv", 2, "First_name");
            var UserName = wait.Until(e => e.FindElement(loginPage.TxtUser));
            UserName.SendKeys(nome);
            screenShotUtil.TakesScreenshot(driver,UserName);
        }

        public void PreencherSenhaInvalidaDeLogin()
        {
            var senha = csvHelper.GetValueByRowAndColumn("login.csv", 2, "Password");
            var Password = wait.Until(e => e.FindElement(loginPage.TxtSenha));
            Password.SendKeys(senha);
            screenShotUtil.TakesScreenshot(driver,Password);
        }
    }  
}
