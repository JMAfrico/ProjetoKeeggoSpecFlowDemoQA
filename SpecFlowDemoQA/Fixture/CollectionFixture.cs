namespace SpecFlowDemoQA.Fixture
{
    /// <summary>
    /// Classe responsável por Implementar a interface ICollectionFixture
    /// Essa classe compartilha o driver da classe passada como objeto na interface, fazendo com que o drive seja passado para todas as execuções dos testes
    /// </summary>
    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture : ICollectionFixture<TestFixture>
    {

    }
}
