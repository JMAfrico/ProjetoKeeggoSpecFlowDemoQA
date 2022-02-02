using iText.Layout;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using Image = iText.Layout.Element.Image;
using iText.IO.Image;
using OpenQA.Selenium;
using SpecFlowDemoQA.Helpers;

namespace SpecFlowDemoQA.Utils
{
    public class PDFUtil
    {
        private ScenarioContext cenario;
        private ScreenShotUtil ScreenShotUtil;
        private IWebDriver driver;
        private IWebElement element;

        public PDFUtil(ScenarioContext cenario, IWebDriver driver, IWebElement element)
        {
            this.driver = driver;
            this.element = element;
            this.cenario = cenario;
            ScreenShotUtil = new ScreenShotUtil(cenario);
        }

        public Document exportarPDF()
        {
            string arguments = DataHelper.DataAtual() + "-" + DataHelper.HoraAtual() + "-" + cenario.ScenarioInfo.Title +".pdf";
            string fileEvidences = FileEvidences(cenario);
            Dictionary<Image, string> images = img(driver, element);

            using (PdfWriter pdfw = new PdfWriter(fileEvidences + arguments, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfdocument = new PdfDocument(pdfw);
                var document = new Document(pdfdocument, PageSize.A4);
                document.Add(cabecalho());
                document.Add(automatizador());
                document.Add(DataHora());
                document.Add(new LineSeparator(new SolidLine()));
                document.Add(nomeCenario(cenario));
                document.Add(statusCenario(cenario));
                document.Add(new LineSeparator(new SolidLine()));
                foreach (KeyValuePair<Image, string> item in images)
                {
                    document.Add(item.Key);
                    document.Add(new Paragraph(item.Value));     
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
            
            if (!Directory.Exists(DataHelper.CaminhoEvidencias()))
            {
                Directory.CreateDirectory(DataHelper.CaminhoEvidencias());
            }

            if (cenario.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                if (!Directory.Exists(DataHelper.CaminhoStatusPassed()))
                {
                    Directory.CreateDirectory(DataHelper.CaminhoStatusPassed());
                }
                return DataHelper.CaminhoStatusPassed();
            }
            else
            {
                if (!Directory.Exists(DataHelper.CaminhoStatusFailed()))
                {
                    Directory.CreateDirectory(DataHelper.CaminhoStatusFailed());
                }
                return DataHelper.CaminhoStatusFailed();
            }
        }

        private Image[] adicionarImagensNoPDF()
        {

            string data = DateTime.Now.ToString("dd-MM-yyyy");

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
            string data = DateTime.Now.ToString("dd-MM-yyyy");
            Directory.Delete(@"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Screenshoots\\" + data + "\\", true);
        }

        public Dictionary<Image,string> img(IWebDriver driver, IWebElement element)
        {
            Dictionary<Image, string> a = new Dictionary<Image, string>();

            string data = DateTime.Now.ToString("dd-MM-yyyy");

            string nomePasta = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Screenshoots\\" + data + "\\";
            string[] itens = Directory.GetFiles(nomePasta);
            Image[] images = new Image[itens.Length];

            for (int i = 0; i < itens.Length; i++)
            {
                a.Add(new Image(ImageDataFactory.Create(itens[i])).SetTextAlignment(TextAlignment.CENTER),"teste");
            }
            return a;
     
        }
    }  
}
