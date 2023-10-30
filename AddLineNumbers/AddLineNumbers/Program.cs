// See https://aka.ms/new-console-template for more information
// Load the existing DOCX document
using System.Drawing;
using Xceed.Words.NET;

internal class Program
{
    private static void Main(string[] args)
    {
        // Load the existing DOCX document
        DocX doc = DocX.Load("input.docx");

        int lineNumber = 1;

        // Iterate through each paragraph in the document and add line numbers
        for(int i = 0; i< doc.Paragraphs.Count; i+=2)
        {
            var paragraph = doc.Paragraphs[i];
            // Insert the line number at the beginning of the paragraph
            var run = paragraph.InsertParagraphAfterSelf(paragraph).Append($"{lineNumber}. ");

            // Set the formatting for the line numbers (e.g., black color)
            run.Color(Color.Black);
            run.Bold(); // You can also set other formatting options as needed

            lineNumber++;
        }

        // Save the modified document to a new file
        doc.SaveAs("output.docx");
    }
}