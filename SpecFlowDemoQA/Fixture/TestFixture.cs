using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowDemoQA.Helpers;

namespace SpecFlowDemoQA.Fixture
{
    /// <summary>
    /// Classe responsável por criar o drive da interface IwebDriver e inicializar a aplicação
    /// </summary>
    public class TestFixture : IDisposable
    {
        /// <summary>
        /// O objeto <see cref="driver" /> é instanciado, mas seu valor deve ser representado no construtor. 
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        /// Construtor sem parametro responsável por aplicar o valor do objeto <see cref="driver"/>
        /// O valor do objeto <see cref="driver"/> deve ser o local onde o arquivo executável do browser se encontra
        /// </summary>
        public TestFixture()
        {
            driver = new ChromeDriver(LocalDriver.GetPastaDoExecutavel());     
        }
        public void Dispose()
        {
            driver.Quit();
        }

    }
}
