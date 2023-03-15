using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCode_Editor
{
    // @@@ Progress Bar (not scalable) @@@
    public class CustomProgressBar : Panel
    {
        // Variables Get Set
        public Color C1_BackColor { get; set; } = Color.FromArgb(255, 255, 255);
        public Color C2_Outer1of4 { get; set; } = Color.FromArgb(215, 215, 215);
        public Color C3_Outer2of4 { get; set; } = Color.FromArgb(173, 173, 173);
        public Color C4_Outer3of4 { get; set; } = Color.FromArgb(102, 102, 102);
        public Color C5_Outer4of4 { get; set; } = Color.FromArgb(50, 50, 50);
        public int C6_Increment { get; set; } = 0;
        public Color C7_LeadingBarColor { get; set; } = Color.FromArgb(37, 192, 84);
        public Color C8_FormBackColor { get; set; } = Color.FromArgb(248, 248, 228);
        public List<int> C10_columnList { get; set; } = new List<int>();

        // Variables
        int columnWidth = 3;
        int columnHeight = 13;
        int columnStartWidth = 14;
        int columnStartHeight = 12;
        int numberOfVisibleColumns = 25;

        // Paint Call
        public CustomProgressBar()
        {
            Paint += new PaintEventHandler(CustomProgressBar_Paint);
        }

        // Main Paint 
        private void CustomProgressBar_Paint(object? sender, PaintEventArgs g)
        {
            // Max size of the ProgressBar Graphics (Background)
            int sizeWidth = 128;
            int sizeHeight = 18;

            // Drawing Correction
            int xDC = 11;
            int yDC = 9;

            // Drawing ProgressBar Border - 1/4 - Drawing from Outside to Inside
            Point p1 = new Point { X = xDC + 4, Y = yDC + 21 };
            Point p2 = new Point { X = xDC + 131, Y = yDC + 21 };
            Point p3 = new Point { X = xDC + 131, Y = yDC + 4 };

            // Drawing ProgressBar Border - 2/4
            Point p4 = new Point { X = xDC + 3, Y = yDC + 20 };
            Point p5 = new Point { X = xDC + 130, Y = yDC + 20 };
            Point p6 = new Point { X = xDC + 130, Y = yDC + 3 };

            // Drawing ProgressBar Border - 3/4
            Point p7 = new Point { X = xDC + 2, Y = yDC + 19 };
            Point p8 = new Point { X = xDC + 129, Y = yDC + 19 };
            Point p9 = new Point { X = xDC + 129, Y = yDC + 2 };

            // Drawing ProgressBar Border - 4/4 - Last inner one
            Point p10 = new Point { X = xDC + 1, Y = yDC + 18 };
            Point p11 = new Point { X = xDC + 128, Y = yDC + 18 };
            Point p12 = new Point { X = xDC + 128, Y = yDC + 1 };

            Point p13 = new Point { X = xDC + 127, Y = yDC + 1 };
            Point p14 = new Point { X = xDC + 127, Y = yDC + 17 };
            Point p15 = new Point { X = xDC + 1, Y = yDC + 17 };
            Point p16 = new Point { X = xDC + 1, Y = yDC + 1 };

            using SolidBrush sb1 = new SolidBrush(C1_BackColor);
            using SolidBrush sb2 = new SolidBrush(C2_Outer1of4);
            using SolidBrush sb3 = new SolidBrush(C3_Outer2of4);
            using SolidBrush sb4 = new SolidBrush(C4_Outer3of4);
            using SolidBrush sb5 = new SolidBrush(C5_Outer4of4);
            using SolidBrush sb7 = new SolidBrush(C7_LeadingBarColor);
            using SolidBrush sb8 = new SolidBrush(C8_FormBackColor);
            using Pen pen2 = new Pen(sb2, 1);
            using Pen pen3 = new Pen(sb3, 1);
            using Pen pen4 = new Pen(sb4, 1);
            using (Pen pen5 = new Pen(sb5, 1))
            {
                // Draw Form Background Color
                g.Graphics.FillRectangle(sb8, 0, 0, Width, Height);

                // Draw Border
                g.Graphics.DrawRectangle(pen5, 1, 1, Width - 3, Height - 3);
                g.Graphics.DrawRectangle(pen4, 0, 0, Width - 1, Height - 1);

                // Draw Background Color
                g.Graphics.FillRectangle(sb1, 12, 10, sizeWidth, sizeHeight);

                // Draw ProgressBar Border 1/4 Color
                g.Graphics.DrawLines(pen2, new Point[] { p1, p2, p3 });

                // Draw ProgressBar Border 2/4 Color
                g.Graphics.DrawLines(pen3, new Point[] { p4, p5, p6 });

                // Draw ProgressBar Border 3/4 Color
                g.Graphics.DrawLines(pen4, new Point[] { p7, p8, p9 });

                // Draw ProgressBar Border 4/4 Color
                g.Graphics.DrawLines(pen5, new Point[] { p10, p11, p12 });
                g.Graphics.DrawLines(pen5, new Point[] { p13, p14, p15, p16, p13 });

                // Draw Columns
                if (C6_Increment <= numberOfVisibleColumns + 1) // + 1 to draw no column
                {
                    if (C6_Increment == 0)
                    {
                        C10_columnList.Add(0);
                        g.Graphics.FillRectangle(sb7, columnStartWidth, columnStartHeight, columnWidth, columnHeight);
                    }
                    else if (C6_Increment >= 1 && C6_Increment <= numberOfVisibleColumns - 1) // - 1 because C6_ == 0 already added one
                    {
                        C10_columnList.Add(C6_Increment);

                        foreach (var item in C10_columnList)
                        {
                            g.Graphics.FillRectangle(sb7, columnStartWidth + (5 * item), columnStartHeight, columnWidth, columnHeight);
                        }
                    }
                }
            }
        }
    }
}

