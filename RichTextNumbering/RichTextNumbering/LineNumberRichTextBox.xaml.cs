﻿using System;
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
    /// Interaktionslogik für LineNumberRichTextBox.xaml
    /// </summary>
    public partial class LineNumberRichTextBox : UserControl
    {
        public LineNumberRichTextBox()
        {
            InitializeComponent();
        }
        public string GetText()
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            return textRange.Text;
        }
        public void AddLineNumbers(string text)
        {
            List<string> lines = text.Split('\n').ToList();
            lineNumbers.Items.Clear();

            for (int i = 0; i < lines.Count; i++)
            {
                lineNumbers.Items.Add((i + 1).ToString());
            }
        }
    }
}
