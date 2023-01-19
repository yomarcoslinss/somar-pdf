using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text.RegularExpressions;


namespace somar_pdf.Models
{
    public class ConvertePdf
    {
        string result = "";
        public string ExtrairPdf(string caminho)
        {
            PdfReader pdfReader = new PdfReader(caminho);
            PdfDocument pdfDoc = new PdfDocument(pdfReader);

            for (int pag = 1; pag <= pdfDoc.GetNumberOfPages(); pag++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string conteudo = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pag), strategy);
                result += conteudo;
            }
            pdfDoc.Close();
            pdfReader.Close();
            return result;
        }

        public List<string> ExtrairValoresMonetarios(string texto)
        {
            List<string> valoresMonetarios = new List<string>();
            string padrao = @"(?<=R\$)\s*\d+(,\d{2})?";
            MatchCollection matches = Regex.Matches(texto, padrao);
            foreach (Match match in matches)
            {
                valoresMonetarios.Add(match.Value);
            }
            
            return valoresMonetarios;
        }
    }
}
