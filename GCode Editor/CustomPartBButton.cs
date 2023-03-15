using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCode_Editor
{
    // @@@ AutoScalable Button Color Design @@@
    public class CustomPartBButton : Button
    {
        // Editable Variables
        public Color C1_FormBackColor { get; set; } = Color.FromArgb(248, 248, 228);
        public Color C2_ButtonBorderBackColor { get; set; } = Color.FromArgb(198, 221, 198);
        public Color C3_ButtonBackColor { get; set; } = Color.FromArgb(142, 186, 142);
        public Color C4_ButtonDesignColor { get; set; } = Color.FromArgb(255, 255, 255);
        public Color C5_TextColor { get; set; } = Color.FromArgb(255, 255, 255);
        public Color C6_ButtonColumnLineColor { get; set; } = Color.FromArgb(133, 182, 133);

        // Variables
        StringFormat stringFormat = new StringFormat();

        // Paint Call
        public CustomPartBButton()
        {
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            Paint += new PaintEventHandler(CustomPartBButton_Paint);
        }

        // Main Paint 
        private void CustomPartBButton_Paint(object? sender, PaintEventArgs g)
        {
            // Drawing Correction
            int width = Width - 1;
            int height = Height - 1;

            // Button BackColor and Border
            Point p1 = new Point { X = width - width, Y = height - height };
            Point p2 = new Point { X = width, Y = height - height };
            Point p3 = new Point { X = width, Y = height - 6 };
            Point p4 = new Point { X = width - 6, Y = height };
            Point p5 = new Point { X = width - width, Y = height };

            // Right Top Column
            Point p6 = new Point { X = width - width + 7, Y = height - 2 };
            Point p7 = new Point { X = width - width + 2, Y = height - 2 };
            Point p8 = new Point { X = width - width + 2, Y = height - 5 };
            Point p9 = new Point { X = width - width + 1, Y = height - 5 };
            Point p10 = new Point { X = width - width + 1, Y = height - 1 };
            Point p11 = new Point { X = width - width + 7, Y = height - 1 };

            // Right Bottom Column
            Point p12 = new Point { X = width - width + 7, Y = height - height + 2 };
            Point p13 = new Point { X = width - width + 2, Y = height - height + 2 };
            Point p14 = new Point { X = width - width + 2, Y = height - height + 5 };
            Point p15 = new Point { X = width - width + 1, Y = height - height + 5 };
            Point p16 = new Point { X = width - width + 1, Y = height - height + 1 };
            Point p17 = new Point { X = width - width + 7, Y = height - height + 1 };

            // Right Column Top Line
            Point p20 = new Point { X = width - width + 2, Y = height - height + 3 };
            Point p21 = new Point { X = width - width, Y = height - height + 3 };

            // Right Column Bottom Line
            Point p22 = new Point { X = width - width + 2, Y = height - 3 };
            Point p23 = new Point { X = width - width, Y = height - 3 };

            // Right Big Square
            Size rSize = new Size(4, 4);
            Point rLocation = new Point(width - 6, height - height + 3);
            Rectangle rSquare = new Rectangle(rLocation, rSize);

            // Right Medium Square
            int x1 = width - 4;
            int y1 = height - height + 8;

            // Right Medium Top Square
            int x2 = width - 9;
            int y2 = height - height + 3;

            // Right Tiny Pixel
            int x3 = width - 3;
            int y3 = height - height + 11;

            // Right Tiny Top Pixel
            int x4 = width - 11;
            int y4 = height - height + 3;

            // Left Column Top Tiny Pixel
            int x5 = width - width;
            int y5 = height - 6;

            // Left Column Bottom Tiny Pixel
            int x6 = width - width;
            int y6 = height - height + 6;

            using SolidBrush sb1 = new SolidBrush(C1_FormBackColor);
            using SolidBrush sb2 = new SolidBrush(C2_ButtonBorderBackColor);
            using SolidBrush sb3 = new SolidBrush(C3_ButtonBackColor);
            using SolidBrush sb4 = new SolidBrush(C4_ButtonDesignColor);
            using SolidBrush sb5 = new SolidBrush(C5_TextColor);
            using SolidBrush sb6 = new SolidBrush(C6_ButtonColumnLineColor);
            using Pen pen1 = new Pen(sb2, 1);
            using (Pen pen2 = new Pen(sb6, 1))
            {
                // Draw Button Background Color
                g.Graphics.FillRectangle(sb1, 0, 0, Width, Height);

                // Draw Button BackColor
                g.Graphics.FillPolygon(sb3, new Point[] { p1, p2, p3, p4, p5 });

                // Draw Button Border Color
                g.Graphics.DrawLines(pen1, new Point[] { p1, p2, p3, p4, p5, p1 });

                // Draw Big Right Square
                g.Graphics.FillRectangle(sb4, rSquare);

                // Draw Right Medium Square
                g.Graphics.FillRectangle(sb4, x1, y1, 2, 2);

                // Draw Right Medium Bottom Square
                g.Graphics.FillRectangle(sb4, x2, y2, 2, 2);

                // Draw Right Tiny Pixel
                g.Graphics.FillRectangle(sb4, x3, y3, 1, 1);

                // Draw Right Tiny Bottom Pixel
                g.Graphics.FillRectangle(sb4, x4, y4, 1, 1);

                // Draw Left Top Column
                g.Graphics.DrawLines(pen1, new Point[] { p6, p7, p8, p9, p10, p11 });

                // Draw Left Bottom Column
                g.Graphics.DrawLines(pen1, new Point[] { p12, p13, p14, p15, p16, p17 });

                // Draw Left Column Top Line
                g.Graphics.DrawLine(pen2, p20, p21);

                // Draw Left Column Bottom Line
                g.Graphics.DrawLine(pen2, p22, p23);

                // Draw Left Column Top Tiny Pixel
                g.Graphics.FillRectangle(sb6, x5, y5, 1, 1);

                // Draw Left Column Bottom Tiny Pixel
                g.Graphics.FillRectangle(sb6, x6, y6, 1, 1);

                // Draw Text
                g.Graphics.DrawString(Text, Font, sb5, new Rectangle(0, 0, width, height), stringFormat);
            }
        }
    }
}
