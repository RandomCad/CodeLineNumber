// See https://aka.ms/new-console-template for more information
// Load the existing DOCX document
using System.Drawing;
using Xceed.Words.NET;

internal class Program
{
    private static void Main(string[] args)
    {

        string docxFile = string.Empty;
        int? fromNumber = null;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].EndsWith(".docx", StringComparison.OrdinalIgnoreCase))
            {
                docxFile = args[i];
            }
            else if (args[i] == "-f" && i < args.Length - 1)
            {
                if (int.TryParse(args[i + 1], out int number))
                {
                    fromNumber = number;
                    i++; // Skip the next argument since it was successfully parsed as a number.
                }
            }
            else if (args[i] == "-h" || args[i] == "--help")
            {
                Console.WriteLine("Usage: YourProgram.exe <docx_file> [-f <from_number>] [-h/--help]");
                Console.WriteLine("  <docx_file>  - A string ending with '.docx'");
                Console.WriteLine("  -f <from_number>  - Specify the 'start' number");
                Console.WriteLine("  -h, --help  - Display this help message");

                return;
            }
        }

        if (!File.Exists(docxFile))
        {
            return;
            
        }

        // Load the existing DOCX document
        DocX doc = DocX.Load(docxFile);

        int lineNumber = (int)fromNumber;

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
        doc.SaveAs($"out-{docxFile}");
    }
}