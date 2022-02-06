    using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoQA.Pages
{
    public class LoginPage
    {      
        private IWebDriver driver;
        public By BtnLogin { get; private set; }
        public By TxtUser { get; private set; }
        public By TxtSenha { get; private set; }
        public By BtnLogOut { get; private set; }
        public By BtnNewUser { get; private set; }
        public By LblInvalidoLoginOuSenha { get; private set; }
        public By TxtFirstName { get; private set; }
        public By TxtLastName { get; private set; }
        public By TxtUserName { get; private set; }
        public By BtnRecapcha { get; private set; }
        public By BtnRegister { get; private set; }
        public By lblMensagemErroCadastro { get; private set; }
        public By lblMensagemErroUsuarioJaExiste { get; private set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            BtnLogin = By.XPath("//button[@id='login']");
            TxtUser = By.XPath("//input[@id='userName']");
            TxtSenha = By.XPath("//input[@id='password']");
            BtnLogOut = By.XPath("//button[contains(text(), 'Log out')]");
            LblInvalidoLoginOuSenha = By.XPath("//p[contains(text(),'Invalid username or password!')]");
            BtnNewUser = By.XPath("//button[@id = 'newUser']");
            TxtFirstName = By.XPath("//input[@id = 'firstname']");
            TxtLastName = By.XPath("//input[@id = 'lastname']");
            TxtUserName = By.XPath("//input[@id = 'userName']");
            BtnRecapcha = By.XPath("//iframe[@title='reCAPTCHA']");
            BtnRegister = By.XPath("//button[@id = 'register']");
            lblMensagemErroCadastro = By.XPath("//p[contains(text(),'Passwords must have at least')]");
            lblMensagemErroUsuarioJaExiste = By.XPath("//p[contains(text(),'User exists!')]");
        }
    }
}
