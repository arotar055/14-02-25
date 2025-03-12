
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using interfaces;

namespace Open
{
    public class open_document : IOpen
    {
        public void open(RichTextBox richTextBox)
        {
            // открытие файла
            var dialog = new OpenFileDialog
            {
                Filter = "Rich Text Files|*.rtf|All Files|*.*"
            };

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.Open))
                {
                    TextRange range = new TextRange(
                        richTextBox.Document.ContentStart,
                        richTextBox.Document.ContentEnd
                    );
                    range.Load(fs, DataFormats.Rtf);
                }
            }
        }
    }

}
