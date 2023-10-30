// See https://aka.ms/new-console-template for more information
// Load the existing DOCX document
using System.Drawing;
using Xceed.Words.NET;

internal class Program
{
    private static void Main(string[] args)
    {
        int i = 0;
        DocX doc;
        int lineNumber = 1;
        do
        {
            switch (args[i])
            {
                case "-v":
                    i++;
                    lineNumber = int.Parse(args[i++]);

                    break;

                default:
                    // Load the existing DOCX document
                    doc = DocX.Load(args[i++]);
                    break;
            }
        } while (args.Length < i);


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