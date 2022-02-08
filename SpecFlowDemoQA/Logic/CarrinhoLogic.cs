using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Pages;
using SpecFlowDemoQA.Utils;


namespace SpecFlowDemoQA.Logic
{
    [Collection("Chrome Driver")]
    public class CarrinhoLogic
    {
        private CarrinhoPage carrinhoPage;
        private IWebDriver driver;
        private WebDriverWait wait;
        private IJavaScriptExecutor js;

        public CarrinhoLogic(TestFixture fixture)
        {
            driver = fixture.driver;
            carrinhoPage = new CarrinhoPage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            js = (IJavaScriptExecutor)driver;
        }

        public void DigitoONomeDoLivro()
        {
            string step = "digito o nome do livro";
            IWebElement txtPesquisa = wait.Until(d => d.FindElement(carrinhoPage.TxtPesquisa));
            string livro = "Speaking JavaScript";
            driver.TakesScreenshot(step);
            txtPesquisa.SendKeys(livro);
        }

        public void ClicoNoLivro()
        {
            string step = "clico no livro";
            IWebElement Nomelivro = wait.Until(d => d.FindElement(carrinhoPage.BtnSelecionarLivro));
            driver.TakesScreenshot(step);
            Nomelivro.Click();
        }

        public void ClicoEmAdicionarAMinhaColecao()
        {
            string step = "clico em 'adicionar a minha colecao'";
            IWebElement btnAdicionar = wait.Until(d => d.FindElement(carrinhoPage.BtnAdicionarAColecao));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", btnAdicionar);
            driver.TakesScreenshot(step);
            btnAdicionar.Click();
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

        public void validoLivroAdicionadoAoCarrinho()
        {
            string step = "Valido a mensagem de 'livro adicionado ao carrinho'";

            if (isAlertPresent())
            {
                var TextoEsperadoDoAlerta = "Book added to your collection.";
                IAlert alerta = driver.SwitchTo().Alert();
                string textoDoAlerta = alerta.Text;
                Assert.Equal(TextoEsperadoDoAlerta, textoDoAlerta);
                alerta.Accept();
            }
            driver.TakesScreenshot(step);
        }

        public void ClicarBtnProfile()
        {
            string step = "clico no botão 'Profile'";
            IWebElement btnProfile = wait.Until(d => d.FindElement(carrinhoPage.BtnProfile));
            Thread.Sleep(3000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", btnProfile);
            driver.TakesScreenshot(step);
            btnProfile.Click();
        }

        public void ValidarLivroRemovidoDoCarrinho()
        {
            string step = "Valido a mensagem de 'livro removido do carrinho'";
            if (isAlertPresent())
            {
                var TextoEsperadoDoAlerta = "Book deleted.";
                IAlert alerta = driver.SwitchTo().Alert();
                string textoDoAlerta = alerta.Text;
                Assert.Equal(TextoEsperadoDoAlerta, textoDoAlerta);
                alerta.Accept();
            } 
            driver.TakesScreenshot(step);
        }

        public void ClicarRemoverLivroDoCarrinho()
        {
            string step = "clico no botão 'remover livro'";
            IWebElement btnRemover = wait.Until(d => d.FindElement(carrinhoPage.BtnRemoverDoCarrinho));
            driver.TakesScreenshot(step);
            btnRemover.Click();
        }

        public void ConfirmarDeRemoverLivro()
        {
            string step = "clico em 'OK' de remover livro";
            IWebElement btnRemover = wait.Until(d => d.FindElement(carrinhoPage.BtnConfirmarRemoverDoCarrinho));
            Thread.Sleep(3000);
            driver.TakesScreenshot(step);
            btnRemover.Click();
        }
    }
}
