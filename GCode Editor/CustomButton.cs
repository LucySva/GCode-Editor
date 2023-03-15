using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCode_Editor
{
    // @@@ AutoScalable Button Color Design @@@
    public class CustomButton : Button
    {
        // Editable Variables
        public Color C1_FormBackColor { get; set; } = Color.FromArgb(248, 248, 228);
        public Color C2_ButtonBorderBackColor { get; set; } = Color.FromArgb(198, 221, 198);
        public Color C3_ButtonBackColor { get; set; } = Color.FromArgb(142, 186, 142);
        public Color C4_ButtonDesignColor { get; set; } = Color.FromArgb(255, 255, 255);
        public Color C5_TextColor { get; set; } = Color.FromArgb(255, 255, 255);

        // Variables
        StringFormat stringFormat = new StringFormat();

        // Paint Call
        public CustomButton()
        {
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            Paint += new PaintEventHandler(CustomButton_Paint);
        }

        // Main Paint 
        private void CustomButton_Paint(object? sender, PaintEventArgs g)
        {
            // Drawing Correction
            int width = Width - 1;
            int height = Height - 1;

            // Button BackColor and Border
            Point p1 = new Point { X = width - width + 6, Y = height - height };
            Point p2 = new Point { X = width, Y = height - height };
            Point p3 = new Point { X = width, Y = height - 6 };
            Point p4 = new Point { X = width - 6, Y = height };
            Point p5 = new Point { X = width - width, Y = height };
            Point p6 = new Point { X = width - width, Y = height - height + 6 };

            // Left Big Square
            Size lSize = new Size(4, 4);
            Point lLocation = new Point(width - width + 3, height - 6);
            Rectangle lSquare = new Rectangle(lLocation, lSize);

            // Right Big Square
            Size rSize = new Size(4, 4);
            Point rLocation = new Point(width - 6, height - height + 3);
            Rectangle rSquare = new Rectangle(rLocation, rSize);

            // Left Medium Square
            int x1 = width - width + 3;
            int y1 = height - 9;

            // Left Medium Bottom Square
            int x2 = width - width + 8;
            int y2 = height - 4;

            // Right Medium Square
            int x3 = width - 4;
            int y3 = height - height + 8;

            // Right Medium Top Square
            int x4 = width - 9;
            int y4 = height - height +3;

            // Left Tiny Pixel
            int x5 = width - width + 3;
            int y5 = height - 11;

            // Left Tiny Bottom Pixel
            int x6 = width - width + 11;
            int y6 = height - 3;

            // Right Tiny Pixel
            int x7 = width - 3;
            int y7 = height - height +11;

            // Right Tiny Top Pixel
            int x8 = width - 11;
            int y8 = height - height + 3;

            using SolidBrush sb1 = new SolidBrush(C1_FormBackColor);
            using SolidBrush sb2 = new SolidBrush(C2_ButtonBorderBackColor);
            using SolidBrush sb3 = new SolidBrush(C3_ButtonBackColor);
            using SolidBrush sb4 = new SolidBrush(C4_ButtonDesignColor);
            using SolidBrush sb5 = new SolidBrush(C5_TextColor);
            using (Pen pen1 = new Pen(sb2, 1))
            {
                // Draw Button Background Color
                g.Graphics.FillRectangle(sb1, 0, 0, Width, Height);

                // Draw Button BackColor
                g.Graphics.FillPolygon(sb3, new Point[] { p1, p2, p3, p4, p5, p6 });

                // Draw Button Border Color
                g.Graphics.DrawLines(pen1, new Point[] { p1, p2, p3, p4, p5, p6, p1 });

                // Draw Big Left Square
                g.Graphics.FillRectangle(sb4, lSquare);

                // Draw Big Righ Square
                g.Graphics.FillRectangle(sb4, rSquare);

                // Draw Left Medium Square
                g.Graphics.FillRectangle(sb4, x1, y1, 2, 2);

                // Draw Left Medium Bottom Square
                g.Graphics.FillRectangle(sb4, x2, y2, 2, 2);

                // Draw Right Medium Square
                g.Graphics.FillRectangle(sb4, x3, y3, 2, 2);

                // Draw Right Medium Top Square
                g.Graphics.FillRectangle(sb4, x4, y4, 2, 2);

                // Draw Left Tiny Pixel
                g.Graphics.FillRectangle(sb4, x5, y5, 1, 1);

                // Draw Left Tiny Bottom Pixel
                g.Graphics.FillRectangle(sb4, x6, y6, 1, 1);

                // Draw Right Tiny Pixel
                g.Graphics.FillRectangle(sb4, x7, y7, 1, 1);

                // Draw Right Tiny Top Pixel
                g.Graphics.FillRectangle(sb4, x8, y8, 1, 1);

                // Draw Text
                g.Graphics.DrawString(Text, Font, sb5, new Rectangle(0, 0, width, height), stringFormat);
            }
        }
    }
}
