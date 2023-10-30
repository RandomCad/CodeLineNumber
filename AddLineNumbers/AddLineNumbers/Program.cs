// See https://aka.ms/new-console-template for more information
// Load the existing DOCX document
using System.Drawing;
using Xceed.Words.NET;

internal class Program
{
    private static void Main(string[] args)
    {// Load the existing DOCX document
        DocX doc = DocX.Load("input.docx");

        int lineNumber = 1;

        // Iterate through each paragraph in the document and add line numbers
        foreach (var paragraph in doc.Paragraphs)
        {
            Xceed.Document.NET.Formatting paragraphFormatting = new Xceed.Document.NET.Formatting();
            paragraphFormatting.FontColor = Color.Black;
            paragraphFormatting.Bold = false;
            paragraphFormatting.Italic = false;

            paragraph.InsertText(0, $"{lineNumber}.\t",false, paragraphFormatting);
            lineNumber++;
        }

        // Save the modified document to a new file
        doc.SaveAs("output.docx");
    }
}