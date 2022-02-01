using iText.Layout;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using Image = iText.Layout.Element.Image;
using iText.IO.Image;

namespace SpecFlowDemoQA.Utils
{
    public class PDFUtil
    {
        private ScenarioContext cenario;
       
        
        public PDFUtil(ScenarioContext cenario)
        {
            this.cenario = cenario;

        }

        public Document exportarPDF()
        {
            string data = DateTime.Now.ToString("dd-MM-yy");
            string hora = DateTime.Now.ToString("HH-mm-ss");
            string argumentosNomePDF = data + "-" + hora + "-" + cenario.ScenarioInfo.Title;
            string caminho = nomeadorCenario(cenario);

            using (PdfWriter pdfw = new PdfWriter(caminho + argumentosNomePDF + ".pdf", new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                Image[] imagem = adicionarImagensNoPDF();             
                var pdfdocument = new PdfDocument(pdfw);             
                var document = new Document(pdfdocument, PageSize.A4);
                document.Add(cabecalho());
                document.Add(automatizador());
                document.Add(DataHora());
                document.Add(new LineSeparator(new SolidLine()));
                document.Add(nomeCenario(cenario));
                document.Add(statusCenario(cenario));
                document.Add(new LineSeparator(new SolidLine()));
                for (int i = 0; i < imagem.Length; i++)
                {                 
                    document.Add(imagem[i]);                    
                }
                document.Close();
                pdfdocument.Close();
                return document;
            }         
        }

        private Paragraph cabecalho()
        {
            Paragraph header = new Paragraph("Evidencias DemoQA").SetTextAlignment(TextAlignment.CENTER).SetFontSize(17);
            return header;
        }

        private Paragraph automatizador()
        {
            Paragraph nome = new Paragraph("Automatizador : João Marcos").SetTextAlignment(TextAlignment.LEFT).SetFontSize(15).SetOpacity(50);
            return nome;
        }

        private Paragraph DataHora()
        {
            string data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Paragraph datahora = new Paragraph("Data: "+data).SetTextAlignment(TextAlignment.LEFT).SetFontSize(14).SetOpacity(50);
            return datahora;
        }
        
        private Paragraph nomeCenario(ScenarioContext cenario)
        {         
            Paragraph nomeCenario = new Paragraph("CENÁRIO : " +(cenario.ScenarioInfo.Title).ToUpper()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(16);
            return nomeCenario;
        }

        private Paragraph statusCenario(ScenarioContext cenario)
        {
            Paragraph status = new Paragraph();
            if (cenario.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                status = new Paragraph("STATUS:" + cenario.ScenarioExecutionStatus).SetTextAlignment(TextAlignment.CENTER).SetFontSize(16)
                    .SetBackgroundColor(ColorConstants.GREEN);
                return status;
            }

            if (cenario.ScenarioExecutionStatus == ScenarioExecutionStatus.UndefinedStep)
            {
                status = new Paragraph("Status:" + cenario.ScenarioExecutionStatus).SetTextAlignment(TextAlignment.CENTER).SetFontSize(16)
                    .SetBackgroundColor(ColorConstants.YELLOW);
                return status;
            }
            else
            {
                status = new Paragraph("Status:" + cenario.ScenarioExecutionStatus).SetTextAlignment(TextAlignment.CENTER).SetFontSize(16)
                    .SetBackgroundColor(ColorConstants.RED);
                return status;
            }
        }

        private string nomeadorCenario(ScenarioContext cenario)
        {
            string data = DateTime.Now.ToString("dd-MM-yy");
            string hora = DateTime.Now.ToString("HH-mm-ss");
            
            string caminhoPadrao = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Evidences\\" + data + "\\";

            if (!Directory.Exists(caminhoPadrao))
            {
                Directory.CreateDirectory(caminhoPadrao);
            }

            string caminhoStatusPassed = caminhoPadrao + "Passed\\";
            string caminhoStatusFailed = caminhoPadrao + "Failed\\";
            if (cenario.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                if (!Directory.Exists(caminhoStatusPassed))
                {
                    Directory.CreateDirectory(caminhoStatusPassed);
                }
                return caminhoStatusPassed;
            }
            else
            {
                if (!Directory.Exists(caminhoStatusFailed))
                {
                    Directory.CreateDirectory(caminhoStatusFailed);
                }
                return caminhoStatusFailed;
            }

        }

        private Image[] adicionarImagensNoPDF()
        {

            string data = DateTime.Now.ToString("yyyy-MM-dd");

            string nomePasta = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Screenshoots\\" + data + "\\";
            string[] itens = Directory.GetFiles(nomePasta);
            Image[] images = new Image[itens.Length];
            
            for (int i = 0; i < itens.Length;i++)
            {
                images[i] = new Image(ImageDataFactory.Create(itens[i])).SetTextAlignment(TextAlignment.CENTER);         
            }
            for (int i = 0; i < itens.Length;)
            {
                return images;
            }
            return null;
        }

        public void deletarPasta()
        {
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            Directory.Delete(@"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Screenshoots\\" + data + "\\", true);
        }


    }
    
}
