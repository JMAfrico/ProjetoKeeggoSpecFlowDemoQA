using OpenQA.Selenium;
using SpecFlowDemoQA.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoQA.Pages
{
    public class CarrinhoPage
    {
        private IWebDriver driver;

        public By TxtPesquisa { get; private set; }
        public By BtnSelecionarLivro { get; private set; }
        public By BtnAdicionarAColecao { get; private set; }
        public By BtnProfile { get; private set; }
        public By BtnRemoverDoCarrinho { get; private set; }
        public By BtnConfirmarRemoverDoCarrinho { get; private set; }


        public CarrinhoPage(IWebDriver driver)
        {
            this.driver = driver;
            TxtPesquisa = By.XPath("//input[@id='searchBox']");           
            BtnSelecionarLivro = By.XPath("(//div[@class='rt-tr-group']//following::a)[1]");
            BtnAdicionarAColecao = By.XPath("//button[contains(text(),'Add To Your Collection')]");
            BtnProfile = By.XPath("//span[@class='text' and contains(text(),'Profile')]");
            BtnRemoverDoCarrinho = By.XPath("(//span[@id='delete-record-undefined'])[1]");
            BtnConfirmarRemoverDoCarrinho = By.XPath("//button[@id='closeSmallModal-ok' and (contains(text(),'OK'))]");
        }      
    }
}
