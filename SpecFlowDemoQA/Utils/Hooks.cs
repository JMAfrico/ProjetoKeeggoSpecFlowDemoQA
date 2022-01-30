using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace SpecFlowDemoQA.Utils
{
    [Binding]
    public sealed class Hooks
    {
        private ITestOutputHelper terminal { get; set; }
        PDFUtil pdfUtil;
        ScenarioContext cenario;
        public Hooks(ITestOutputHelper terminal, ScenarioContext cenario)
        {
            this.terminal = terminal;   
            this.cenario = cenario;
            pdfUtil = new PDFUtil(cenario);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            terminal.WriteLine("--Iniciando automação--");
            terminal.WriteLine($"--Cenário:{cenario.ScenarioInfo.Title}--");
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            terminal.WriteLine("--Finalizando automação--");
            terminal.WriteLine($"--Status:{cenario.ScenarioExecutionStatus}");        
            pdfUtil.exportarPDF();
            
        }

    }
}