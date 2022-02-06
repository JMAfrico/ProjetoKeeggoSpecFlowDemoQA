using iText.Layout;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using Image = iText.Layout.Element.Image;
using iText.IO.Image;
using SpecFlowDemoQA.Helpers;

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
            string arguments = DataHelper.GetDataAtual() + "-" + DataHelper.GetHoraAtual() + "-" + cenario.ScenarioInfo.Title ;
            string fileEvidences = FileEvidences(cenario);
            

            using (PdfWriter pdfw = new PdfWriter(fileEvidences + arguments + ".pdf", new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfdocument = new PdfDocument(pdfw);
                var document = new Document(pdfdocument, PageSize.A4);
                Dictionary<Image, string> images = AddImagensPDF();

                document.Add(cabecalho());
                document.Add(automatizador());
                document.Add(DataHora());
                document.Add(new LineSeparator(new SolidLine()));
                document.Add(nomeCenario(cenario));
                document.Add(statusCenario(cenario));
                document.Add(new LineSeparator(new SolidLine()));
                document.Add(new AreaBreak());
                foreach (KeyValuePair<Image, string> item in images)
                {
                  //item.Key.ScaleToFit(600f, 330f);
                    document.Add(item.Key.ScaleToFit(600f, 300f));
                    document.Add(new Paragraph());
                    document.Add(new Paragraph(item.Value).SetFontColor(ColorConstants.RED));
                    document.Add(new AreaBreak());
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

        private string FileEvidences(ScenarioContext cenario)
        {           
            
            if (!Directory.Exists(DataHelper.GetCaminhoEvidencias()))
            {
                Directory.CreateDirectory(DataHelper.GetCaminhoEvidencias());
            }

            if (cenario.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                if (!Directory.Exists(DataHelper.GetCaminhoStatusPassed()))
                {
                    Directory.CreateDirectory(DataHelper.GetCaminhoStatusPassed());
                }
                return DataHelper.GetCaminhoStatusPassed();
            }
            else
            {
                if (!Directory.Exists(DataHelper.GetCaminhoStatusFailed()))
                {
                    Directory.CreateDirectory(DataHelper.GetCaminhoStatusFailed());
                }
                return DataHelper.GetCaminhoStatusFailed();
            }
        }

        public void deletarPasta()
        {
            Directory.Delete(DataHelper.GetCaminhoScreenshot(), true);
        }

        public Dictionary<Image, string> AddImagensPDF()
        {
            try
            {
                Dictionary<Image, string> listaDeImagens = new Dictionary<Image, string>();

                string[] itens = Directory.GetFiles(DataHelper.GetCaminhoScreenshot());
                string[] Steps = Directory.GetFileSystemEntries(DataHelper.GetCaminhoScreenshot());


                for (int i = 0; i < itens.Length; i++)
                {
                    
                    int posicaoIndice = Steps[i].IndexOf('_');
                    int posicaoFinal = Steps[i].IndexOf(".jpg");
                    string posicaoStep = Steps[i].Substring(posicaoIndice + 1);


                    listaDeImagens.Add(new Image(ImageDataFactory.Create(itens[i])), posicaoStep);
                }
                return listaDeImagens;

            }catch (InvalidOperationException ex)
            {
                throw new Exception("Não foi possível adicionar Imagens no PDF. "+ex.Message);
            }
        }

    }  
}
