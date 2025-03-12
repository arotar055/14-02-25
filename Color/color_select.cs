
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Windows.Forms;
using interfaces;

namespace Color
{
    public class color_select : IColor
    {
        public void select_color(System.Windows.Controls.RichTextBox richTextBox)
        {
            // выбор цвета
            using (var dialog = new ColorDialog())
            {
                TextSelection selection = richTextBox.Selection;

                object currentColorObj = selection.GetPropertyValue(TextElement.ForegroundProperty);

                if (currentColorObj != DependencyProperty.UnsetValue)
                {
                    var brush = currentColorObj as SolidColorBrush;

                    if (brush != null)
                    {
                        var wpfColor = brush.Color;
                        dialog.Color = System.Drawing.Color.FromArgb(
                            wpfColor.A, wpfColor.R, wpfColor.G, wpfColor.B
                        );
                    }
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var newColor = System.Windows.Media.Color.FromArgb(
                        dialog.Color.A, dialog.Color.R, dialog.Color.G, dialog.Color.B
                    );
                    selection.ApplyPropertyValue(
                        TextElement.ForegroundProperty,
                        new SolidColorBrush(newColor)
                    );
                }
            }
        }
    }

}
