using OpenQA.Selenium;
using SpecFlowDemoQA.Fixture;
using SpecFlowDemoQA.Logic;

namespace SpecFlowDemoQA.StepDefinitions
{
    [Binding]
    [Collection("Chrome Driver")]
    public class CarrinhoStepDefinitions
    {
        private IWebDriver driver;
        private CarrinhoLogic carrinhoLogic;
        public CarrinhoStepDefinitions(TestFixture fixture)
        {
            driver = fixture.driver;
            carrinhoLogic = new CarrinhoLogic(fixture);
        }

        [When(@"digito o nome do livro Speaking JavaScript")]
        public void WhenDigitoONomeDoLivroSpeakingJavaScript()
        {
            carrinhoLogic.DigitoONomeDoLivro();
        }

        [When(@"clico no livro")]
        public void WhenClicoNoLivro()
        {
            carrinhoLogic.ClicoNoLivro();
        }

        [When(@"clico em adicionar a minha colecao")]
        public void WhenClicoEmAdicionarAMinhaColecao()
        {
            carrinhoLogic.ClicoEmAdicionarAMinhaColecao();
        }

        [Then(@"valido livro adicionado ao carrinho")]
        public void validoLivroAdicionadoAoCarrinho()
        {
            carrinhoLogic.validoLivroAdicionadoAoCarrinho();
        }

        [When(@"clico em remover livro")]
        public void WhenClicoEmRemoverLivro()
        {
            carrinhoLogic.ClicarRemoverLivroDoCarrinho();
        }

        [Then(@"valido livro removido do carrinho")]
        public void ThenValidoLivroRemovidoDoCarrinho()
        {
            carrinhoLogic.ValidarLivroRemovidoDoCarrinho();
        }

        [When(@"clico em confirmar de remover livro")]
        public void WhenClicoEmConfirmarDeRemoverLivro()
        {
            carrinhoLogic.ConfirmarDeRemoverLivro();
        }

        [When(@"clico em Profile")]
        public void WhenClicoEmProfile()
        {
            carrinhoLogic.ClicarBtnProfile();
        }
    }
}
