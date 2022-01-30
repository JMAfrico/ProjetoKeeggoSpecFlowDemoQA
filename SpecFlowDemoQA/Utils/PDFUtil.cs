using System;
using System.Collections.Generic;
using System.Linq;
using iText.Layout;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Layout.Element;
using System.Drawing;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Canvas.Draw;

namespace SpecFlowDemoQA.Utils
{
    public class PDFUtil
    {
        ScenarioContext cenario;
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

            using (PdfWriter pdfw = new PdfWriter(caminho+argumentosNomePDF+".pdf", new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {              
                var pdfdocument = new PdfDocument(pdfw);
                var document = new iText.Layout.Document(pdfdocument, PageSize.A4);
         
                document.Add(cabecalho());
                document.Add(automatizador());
                document.Add(DataHora());
                document.Add(new LineSeparator(new SolidLine()));
                document.Add(nomeCenario(cenario));
                document.Add(statusCenario(cenario));
                document.Add(new LineSeparator(new SolidLine()));

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
                status = new Paragraph("STATUS:" + cenario.ScenarioExecutionStatus).SetTextAlignment(TextAlignment.LEFT).SetFontSize(16)
                    .SetBackgroundColor(ColorConstants.GREEN);
                return status;
            }

            if (cenario.ScenarioExecutionStatus == ScenarioExecutionStatus.UndefinedStep)
            {
                status = new Paragraph("Status:" + cenario.ScenarioExecutionStatus).SetTextAlignment(TextAlignment.LEFT).SetFontSize(16)
                    .SetBackgroundColor(ColorConstants.YELLOW);
                return status;
            }
            else
            {
                status = new Paragraph("Status:" + cenario.ScenarioExecutionStatus).SetTextAlignment(TextAlignment.LEFT).SetFontSize(16)
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
    }
    
}
