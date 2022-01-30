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

        public By LblInvalidoLoginOuSenha { get; private set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            BtnLogin = By.XPath("//button[@id='login']");
            TxtUser = By.XPath("//input[@id='userName']");
            TxtSenha = By.XPath("//input[@id='password']");
            BtnLogOut = By.XPath("//button[contains(text(), 'Log out')]");
            LblInvalidoLoginOuSenha = By.XPath("//p[contains(text(),'Invalid username or password!')]");
        }
    }
}
