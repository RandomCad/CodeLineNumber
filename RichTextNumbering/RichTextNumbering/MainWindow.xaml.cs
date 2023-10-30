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
            string text = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;

            // Split the text into lines
            string[] lines = text.Split('\n');

            // Create a new Paragraph for the RichTextBox
            Paragraph paragraph = new Paragraph();

            // Add line numbers to each line and append to the Paragraph
            for (int i = 0; i < lines.Length; i++)
            {
                paragraph.Inlines.Add(new Run((i + 1).ToString() + ": ")); // Add line number
                paragraph.Inlines.Add(new Run(lines[i])); // Add the line's text
            }

            // Clear the existing content in the RichTextBox
            richTextBox.Document.Blocks.Clear();

            // Add the new paragraph with line numbers to the RichTextBox
            richTextBox.Document.Blocks.Add(paragraph);
        }
    }
}
