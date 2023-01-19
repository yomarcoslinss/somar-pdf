using somar_pdf.Models;


var lerPdf = new ConvertePdf();


// Insira aqui o caminho do seu arquivo PDF:
var texto = lerPdf.ExtrairPdf("./Assets/NomeDoArquivo.pdf");



var valoresMonetarios = lerPdf.ExtrairValoresMonetarios(texto);

foreach (var valor in valoresMonetarios)
{
    Console.WriteLine(valor);
}