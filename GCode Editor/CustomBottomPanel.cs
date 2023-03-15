using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCode_Editor
{
    public class CustomBottomPanel : Panel
    {
        // Variables Get Set
        public Color C1_BackColor { get; set; } = Color.FromArgb(234, 234, 234);
        public Color C2_TopLineColor { get; set; } = Color.FromArgb(209, 209, 209);

        // Paint Call
        public CustomBottomPanel()
        {
            Paint += new PaintEventHandler(CustomBottomPanel_Paint);
        }

        // Main Paint 
        private void CustomBottomPanel_Paint(object? sender, PaintEventArgs g)
        {
            // Drawing Correction
            int width = Width - 1;
            int height = Height - 1;

            // Drawing ProgressBar Border - 1/4 - Drawing from Outside to Inside
            Point p1 = new Point { X = width - width, Y = height - height };
            Point p2 = new Point { X = width, Y = height - height };

            using SolidBrush sb1 = new SolidBrush(C1_BackColor);
            using SolidBrush sb2 = new SolidBrush(C2_TopLineColor);
            using (Pen pen2 = new Pen(sb2, 1))
            {
                // Draw Background Color
                g.Graphics.FillRectangle(sb1, 0, 0, Width, Height);

                // Draw Top Line
                g.Graphics.DrawLine(pen2, p1, p2);
            }
        }
    }
}
