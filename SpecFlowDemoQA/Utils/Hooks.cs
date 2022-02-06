using Xunit.Abstractions;

namespace SpecFlowDemoQA.Utils
{
    [Binding]
    public sealed class Hooks
    {
        private ITestOutputHelper terminal { get; set; }
        private PDFUtil pdfUtil;
        private ScenarioContext cenario;

        public Hooks(ITestOutputHelper terminal, ScenarioContext cenario)
        {           
            this.terminal = terminal;   
            this.cenario = cenario;     
            pdfUtil = new PDFUtil(cenario);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                terminal.WriteLine("--Iniciando automação--");
                terminal.WriteLine($"--Cenário:{cenario.ScenarioInfo.Title}--");
            }catch (Exception ex)
            {
                throw new Exception("Erro"+ex.Message);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                terminal.WriteLine("--Finalizando automação--");
                terminal.WriteLine($"--Status:{cenario.ScenarioExecutionStatus}");
                pdfUtil.exportarPDF();       
            }
            catch (Exception ex)
            {
                throw new Exception("Erro"+ex.Message);
            }
            finally
            {
                pdfUtil.deletarPasta();
            }
        }
    }
}