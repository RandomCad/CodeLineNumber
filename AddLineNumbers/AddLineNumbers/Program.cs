// See https://aka.ms/new-console-template for more information
// Load the existing DOCX document
using Xceed.Words.NET;

DocX doc = DocX.Load("input.docx");

int lineNumber = 1;

// Iterate through each paragraph in the document and add line numbers
foreach (var paragraph in doc.Paragraphs)
{
    paragraph.InsertText(0, $"{lineNumber}. ");
    lineNumber++;
}

// Save the modified document to a new file
doc.SaveAs("output.docx");
