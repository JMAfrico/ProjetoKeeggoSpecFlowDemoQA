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
        public By btnLogin { get; private set; }
        public By txtUser { get; private set; }
        public By txtSenha { get; private set; }
        public By BtnLogOut { get; private set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            btnLogin = By.XPath("//button[@id='login']");
            txtUser = By.XPath("//input[@id='userName']");
            txtSenha = By.XPath("//input[@id='password']");
            BtnLogOut = By.XPath("//button[contains(text(), 'Log out')]");
        }
        public void AbrirSite()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/books");
            driver.Manage().Window.Maximize();
        }
    }
}
