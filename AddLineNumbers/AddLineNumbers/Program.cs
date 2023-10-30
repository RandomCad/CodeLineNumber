// See https://aka.ms/new-console-template for more information
// Load the existing DOCX document
using System.Drawing;
using Xceed.Words.NET;

// Load the existing DOCX document
DocX doc = DocX.Load("input.docx");

int lineNumber = 1;

// Iterate through each paragraph in the document and add line numbers
foreach (var paragraph in doc.Paragraphs)
{
    // Insert the line number at the beginning of the paragraph
    var run = paragraph.InsertParagraph(0).Append($"{lineNumber}. ");

    // Set the formatting for the line numbers (e.g., black color)
    run.Color(Color.Black);
    run.Bold(); // You can also set other formatting options as needed

    lineNumber++;
}

// Save the modified document to a new file
doc.SaveAs("output.docx");
