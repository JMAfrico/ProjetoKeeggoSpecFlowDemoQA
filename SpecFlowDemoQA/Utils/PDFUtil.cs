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
using OpenQA.Selenium;
using System.Drawing;

namespace SpecFlowDemoQA.Utils
{
    /// <summary>
    /// Classe responsável por gerar o arquivo PDF representando o sucesso ou a falha da execução do teste, utilizando a biblioteca ITEXT 7
    /// 
    /// </summary>
    public class PDFUtil
    {
        private ScenarioContext cenario;
        private IWebDriver driver;
        public PDFUtil(ScenarioContext cenario, IWebDriver driver)
        {
            this.cenario = cenario;
            this.driver = driver;
        }
       
        /// <summary>
        /// Método responsável por adicionar os dados da evidência no documento PDF
        /// </summary>
        /// <returns>Retorna um documento PDF contendo os dados da execução do teste</returns>
        public Document exportarPDF()
        { 

            string arguments = DataHelper.GetDataAtual() + "-" + DataHelper.GetHoraAtual() + "-" + cenario.ScenarioInfo.Title ;
            string fileEvidences = FileEvidences(cenario);
            

            using (PdfWriter pdfw = new PdfWriter(fileEvidences + arguments + ".pdf", new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfdocument = new PdfDocument(pdfw);
                var document = new Document(pdfdocument, PageSize.A4);
                Dictionary<Image, string> images = AddImagensPDF();

                document.Add(cabecalho("Evidencias DemoQA"));
                document.Add(automatizador("João Marcos"));
                document.Add(DataHora());
                document.Add(new LineSeparator(new SolidLine()));
                document.Add(nomeCenario(cenario));
                document.Add(statusCenario(cenario));
                document.Add(new LineSeparator(new SolidLine()));
                document.Add(new AreaBreak());

                foreach (KeyValuePair<Image, string> item in images)
                {
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

        /// <summary>
        /// Método responsável por criar um cabeçalho no Documento PDF 
        /// </summary>
        /// <param name="cabecalho">Representa o nome que deve aparecer no cabeçalho do Documento</param>
        /// <returns>Retorna um Paragrafo contendo a formatação de um cabeçalho</returns>
        private Paragraph cabecalho(string cabecalho)
        {
            Paragraph header = new Paragraph(cabecalho).SetTextAlignment(TextAlignment.CENTER).SetFontSize(17);
            return header;
        }

        /// <summary>
        /// Método responsável por adicionar o nome do Automatizador no Documento PDF 
        /// </summary>
        /// <param name="automatizador"> Representa o nome do Automatizador</param>
        /// <returns>Retorna um Paragrafo contendo o nome do Automatizador</returns>
        private Paragraph automatizador(string automatizador)
        {
            Paragraph nome = new Paragraph($"Automatizador: {automatizador}").SetTextAlignment(TextAlignment.LEFT).SetFontSize(15).SetOpacity(50);
            return nome;
        }

        /// <summary>
        /// Método responsável por adicionar a data e hora no Documento PDF 
        /// </summary>
        /// <returns>Retorna Um Paragrafo contendo a data e hora atual no Documento</returns>
        private Paragraph DataHora()
        {
            string data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Paragraph datahora = new Paragraph("Data: "+data).SetTextAlignment(TextAlignment.LEFT).SetFontSize(14).SetOpacity(50);
            return datahora;
        }

        /// <summary>
        /// Método responsável por adicionar o nome do cenário executado no Documento PDF
        /// </summary>
        /// <param name="cenario"> Parâmetro buscando o título do cenário executado</param>
        /// <returns>Retorna Um Paragrafo contendo o nome do cenário executado no Documento</returns>
        private Paragraph nomeCenario(ScenarioContext cenario)
        {         
            Paragraph nomeCenario = new Paragraph("CENÁRIO : " +(cenario.ScenarioInfo.Title).ToUpper()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(16);
            return nomeCenario;
        }

        /// <summary>
        /// Método responsável por adicionar o status do cenário executado no Documento PDF
        /// </summary>
        /// <param name="cenario">Parâmetro buscando o título do cenário executado</param>
        /// <returns>Retorna Um Paragrafo contendo o Status do cenário executado no Documento</returns>
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

        /// <summary>
        /// Método responsável por criar o caminho onde será armazenadas as evidências, de acordo com o Status do Teste
        /// </summary>
        /// <param name="cenario">Parâmetro buscando o título do cenário executado</param>
        /// <returns>Retorna uma pasta criada de acordo com o Status da evidência</returns>
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

        /// <summary>
        /// Método para deletar a pasta de screenshoots logo após os dados serem enviados para o Documento PDF
        /// </summary>
        public void deletarPasta()
        {
            Directory.Delete(DataHelper.GetCaminhoScreenshot(), true);
        }

        /// <summary>
        /// Método responsável por localizar as imagens das evidencias na pasta e adiciona-las no Documento PDF
        /// </summary>
        /// <returns>Retorna um <see cref="Dictionary{TKey, TValue}"/> contendo a imagem do screenshoot e seu respectivo step</returns>
        /// <exception cref="Exception">Exceção lançada caso não seja possível encontrar as imagens na pasta</exception>
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
