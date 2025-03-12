
using System.Windows.Documents;
using System.Windows;
using interfaces;
using System.Windows.Forms;

namespace Fonts
{
    public class font_select : IFont
    {
        public void select_font(System.Windows.Controls.RichTextBox richTextBox)
        {
            // גûבמנ רנטפעא
            using (var dialog = new FontDialog())
            {
                if (!richTextBox.Selection.IsEmpty)
                {
                    object family = richTextBox.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
                    object size = richTextBox.Selection.GetPropertyValue(TextElement.FontSizeProperty);

                    if (family != DependencyProperty.UnsetValue && size != DependencyProperty.UnsetValue)
                    {
                        var currentFamily = family as System.Windows.Media.FontFamily;
                        var currentSize = (double)size;

                        if (currentFamily != null && currentSize > 0)
                        {
                            float sizeInPoints = (float)(currentSize * 72.0 / 96.0);
                            string fontName = currentFamily.Source;

                            dialog.Font = new System.Drawing.Font(fontName, sizeInPoints);
                        }
                    }
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var newFamily = new System.Windows.Media.FontFamily(dialog.Font.Name);
                    double newSizePx = dialog.Font.Size * 96.0 / 72.0;

                    richTextBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, newFamily);
                    richTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, newSizePx);
                }
            }
        }
    }

}
