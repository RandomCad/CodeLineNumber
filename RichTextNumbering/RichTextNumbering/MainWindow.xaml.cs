using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RichTextNumbering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the text from the RichTextBox
            FlowDocument doc = richTextBox.Document;

            // Create a new FlowDocument for the RichTextBox
            FlowDocument newDoc = new FlowDocument();

            // Create a new Paragraph for the RichTextBox
            Paragraph paragraph = new Paragraph();

            int lineNumber = 1;

            foreach (Block block in doc.Blocks)
            {
                if (block is Paragraph originalParagraph)
                {
                    // Create a new paragraph for each original paragraph
                    Paragraph newParagraph = new Paragraph();

                    // Copy the original paragraph's properties
                    newParagraph.TextAlignment = originalParagraph.TextAlignment;
                    newParagraph.FontSize = originalParagraph.FontSize;
                    newParagraph.FontFamily = originalParagraph.FontFamily;
                    newParagraph.FontWeight = originalParagraph.FontWeight;
                    newParagraph.FontStyle = originalParagraph.FontStyle;
                    newParagraph.Foreground = originalParagraph.Foreground;

                    // Add the line number
                    newParagraph.Inlines.Add(new Run(lineNumber + ": "));

                    // Copy and add the original text to the new paragraph with formatting
                    foreach (Inline inline in originalParagraph.Inlines)
                    {
                        if (inline is Run run)
                        {
                            Run newRun = new Run(run.Text);

                            // Copy formatting from the original Run to the new Run
                            newRun.FontSize = run.FontSize;
                            newRun.FontFamily = run.FontFamily;
                            newRun.FontWeight = run.FontWeight;
                            newRun.FontStyle = run.FontStyle;
                            newRun.Foreground = run.Foreground;

                            newParagraph.Inlines.Add(newRun);
                        }
                        // Handle other inline elements as needed
                    }

                    // Add the new paragraph to the new document
                    newDoc.Blocks.Add(newParagraph);

                    lineNumber++;
                }
            }

            // Clear the existing content in the RichTextBox
            richTextBox.Document.Blocks.Clear();

            // Add the new FlowDocument with line numbers and preserved formatting to the RichTextBox
            richTextBox.Document = newDoc;
        }
    }
}
