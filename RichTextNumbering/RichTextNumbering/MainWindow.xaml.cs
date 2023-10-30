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
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

            // Get the original text with formatting
            string text = textRange.Text;

            // Split the text into lines
            string[] lines = text.Split('\n');

            // Create a new Paragraph for the RichTextBox
            Paragraph paragraph = new Paragraph();

            // Loop through lines and add line numbers with preserved formatting
            for (int i = 0; i < lines.Length; i++)
            {
                // Create a new Run with the original formatting
                Run run = new Run(lines[i]);

                // Copy the formatting from the original text to the new Run
                if (i < textRange.Text.Length)
                {
                    TextPointer start = textRange.Start.GetPositionAtOffset(lines[i].Length, (LogicalDirection)i);
                    TextPointer end = start.GetPositionAtOffset(lines[i].Length, (LogicalDirection)1);
                    TextRange lineRange = new TextRange(start, end);

                    // Copy TextDecorations individually
                    foreach (TextDecoration decoration in lineRange.TextDecorations)
                    {
                        run.TextDecorations.Add(decoration);
                    }

                    run.FontFamily = lineRange.GetPropertyValue(TextElement.FontFamilyProperty) as FontFamily;
                    run.FontSize = (double)lineRange.GetPropertyValue(TextElement.FontSizeProperty);
                    run.FontWeight = (FontWeight)lineRange.GetPropertyValue(TextElement.FontWeightProperty);
                    run.FontStyle = (FontStyle)lineRange.GetPropertyValue(TextElement.FontStyleProperty);
                    run.Foreground = lineRange.GetPropertyValue(TextElement.ForegroundProperty) as Brush;
                }

                // Add line number
                paragraph.Inlines.Add(new Run((i + 1).ToString() + ": "));

                // Add the line's text with original formatting
                paragraph.Inlines.Add(run);
            }

            // Clear the existing content in the RichTextBox
            richTextBox.Document.Blocks.Clear();

            // Add the new paragraph with line numbers and preserved formatting to the RichTextBox
            richTextBox.Document.Blocks.Add(paragraph);
        }
    }
}
