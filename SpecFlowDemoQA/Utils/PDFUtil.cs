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

namespace SpecFlowDemoQA.Utils
{
    public class PDFUtil
    {
        ScenarioContext cenario;
        public PDFUtil(ScenarioContext cenario)
        {
            this.cenario = cenario;
        }

        public Document exportarPDF(string caminho)
        {
            using (PdfWriter pdfw = new PdfWriter(caminho, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {              
                var pdfdocument = new PdfDocument(pdfw);

                var document = new iText.Layout.Document(pdfdocument, PageSize.A4);

                document.Add(cabecalho());
                document.Add(nomeCenario(cenario));
                document.Add(statusCenario(cenario));

                document.Close();
                pdfdocument.Close();
                return document;
            }
            
        }

        private Paragraph cabecalho()
        {
            Paragraph header = new Paragraph("EVIDENCIAS DEMOQA").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
            return header;
        }

        private Paragraph nomeCenario(ScenarioContext cenario)
        {         
            Paragraph nomeCenario = new Paragraph("Cenário: " +cenario.ScenarioInfo.Title).SetTextAlignment(TextAlignment.LEFT).SetFontSize(16);
            return nomeCenario;
        }

        private Paragraph statusCenario(ScenarioContext cenario)
        {
            Paragraph status = new Paragraph();
            if (cenario.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                status = new Paragraph("Status:" + cenario.ScenarioExecutionStatus).SetTextAlignment(TextAlignment.LEFT).SetFontSize(16)
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


        //using (PdfWriter writer = new PdfWriter(dt))
        //
        //
        // System.IO.FileStream fs = new FileStream(strPDF, FileMode.Create, FileAccess.Write, FileShare.None);
        // Document doc = new Document();
        // doc.s(iTextSharp.text.PageSize.A2);
        // PdfWriter writer = PdfWriter.GetInstance(doc, fs);
        // doc.Open();
        //
        // //CABEÇALHO
        // BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        // iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfnHead, 22, 1, iTextSharp.text.BaseColor.BLACK);
        // Paragraph paragrafo = new Paragraph();
        // paragrafo.Alignment = Element.ALIGN_CENTER;
        // paragrafo.Add(new Chunk(strHead.ToUpper(), fntHead));
        // doc.Add(paragrafo);
        //
        // //DADOS
        // Paragraph autor = new Paragraph();
        // BaseFont bfnAutor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        // iTextSharp.text.Font Fontautor = new iTextSharp.text.Font(bfnHead, 16, 1, iTextSharp.text.BaseColor.GRAY);
        // autor.Alignment = Element.ALIGN_LEFT;
        // autor.Add(new Chunk("Autor : JOAO MARCOS", Fontautor));
        // //autor.Add(new Chunk("\nCliente : " + lbl_nome_cliente.Text, Fontautor));
        // autor.Add(new Chunk("\nData do Relatório:" + DateTime.Now, Fontautor));
        // //autor.Add(new Chunk("\nTotal:" + lbl_total_geral.Text, Fontautor));
        // autor.Add(new Chunk("\nQuantidade compras:" + dt_compras_efetuadas.RowCount, Fontautor));
        // autor.Add(new Chunk("\nTotal :" + lbl_TotalDasCompras.Text, Fontautor));
        //
        // autor.Add(new Chunk(" " + "", Fontautor));
        // doc.Add(autor);
        //
        // //
        // doc.Add(new Chunk("\n", fntHead));
        //
        // //TABELA
        // PdfPTable pdfTable = new PdfPTable(dt_compras_efetuadas.ColumnCount);
        // pdfTable.DefaultCell.Padding = 3;
        // pdfTable.WidthPercentage = 50;
        // pdfTable.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
        // pdfTable.DefaultCell.BorderWidth = 1;
        //
        // foreach (DataGridViewColumn column in dt_compras_efetuadas.Columns)
        // {
        //     PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
        //     cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
        //     pdfTable.AddCell(cell);
        //
        // }
        //
        // //Adding DataRow
        // foreach (DataGridViewRow row in dt_compras_efetuadas.Rows)
        // {
        //     foreach (DataGridViewCell cell in row.Cells)
        //     {
        //         pdfTable.AddCell(cell.Value.ToString());
        //     }
        // }
        //
        // doc.Add(pdfTable);
        // doc.Close();
        // writer.Close();
        // fs.Close();
        //
        //
    }
    
}
