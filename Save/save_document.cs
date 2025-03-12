
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using interfaces;

namespace Save
{
    public class save_document : ISave
    {
        public void save(RichTextBox richTextBox)
        {
            // сохранения файла
            var dialog = new SaveFileDialog
            {
                Filter = "Rich Text Files|*.rtf|All Files|*.*"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.Create))
                {
                    TextRange range = new TextRange(
                        richTextBox.Document.ContentStart,
                        richTextBox.Document.ContentEnd
                    );
                    range.Save(fs, DataFormats.Rtf);
                }
            }
        }
    }

}
