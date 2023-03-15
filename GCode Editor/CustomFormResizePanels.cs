using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCode_Editor
{
    public class CustomFormResizePanels : Panel
    {
        // Variables Get Set
        public Color C1_FormBackColor { get; set; } = Color.FromArgb(248, 248, 228);
        public Color C2_BackColor { get; set; } = Color.FromArgb(142, 186, 142);
        public Color C3_BorderColor { get; set; } = Color.FromArgb(199, 199, 199);
        public bool C10_PositionTop { get; set; } = true;
        public bool C11_PositionLeft { get; set; } = false;
        public bool C12_PositionRight { get; set; } = false;

        // Paint Call
        public CustomFormResizePanels()
        {
            Paint += new PaintEventHandler(CustomFormResizePanels_Paint);
        }

        // Main Paint 
        private void CustomFormResizePanels_Paint(object? sender, PaintEventArgs g)
        {
            // Drawing Position Corection
            int width = Width - 0;
            int height = Height - 0;

            // Top Border
            Point p1 = new Point { X = (width / 2) + 57, Y = height - height };
            Point p2 = new Point { X = (width / 2) + 50, Y = height - height + 7 };
            Point p3 = new Point { X = (width / 2) - 50, Y = height - height + 7 };
            Point p4 = new Point { X = (width / 2) - 57, Y = height - height };

            // Top Color of the Handle
            Point p5 = new Point { X = (width / 2) + 54, Y = height - height };
            Point p6 = new Point { X = (width / 2) + 50, Y = height - height + 4 };
            Point p7 = new Point { X = (width / 2) - 50, Y = height - height + 4 };
            Point p8 = new Point { X = (width / 2) - 54, Y = height - height };

            // Left Border
            Point p9 = new Point { X = width - width, Y = (height / 2) + 57 };
            Point p10 = new Point { X = width - width + 7, Y = (height / 2) + 50 };
            Point p11 = new Point { X = width - width + 7, Y = (height / 2) - 50 };
            Point p12 = new Point { X = width - width, Y = (height / 2) - 57 };

            // Left Color of the Handle
            Point p13 = new Point { X = width - width, Y = (height / 2) + 54 };
            Point p14 = new Point { X = width - width + 4, Y = (height / 2) + 50 };
            Point p15 = new Point { X = width - width + 4, Y = (height / 2) - 50 };
            Point p16 = new Point { X = width - width, Y = (height / 2) - 54 };

            // Right Border
            Point p17 = new Point { X = width, Y = (height / 2) + 57 };
            Point p18 = new Point { X = width - 7, Y = (height / 2) + 50 };
            Point p19 = new Point { X = width - 7, Y = (height / 2) - 50 };
            Point p20 = new Point { X = width, Y = (height / 2) - 57 };

            // Right Color of the Handle
            Point p21 = new Point { X = width, Y = (height / 2) + 54 };
            Point p22 = new Point { X = width - 4, Y = (height / 2) + 50 };
            Point p23 = new Point { X = width - 4, Y = (height / 2) - 50 };
            Point p24 = new Point { X = width, Y = (height / 2) - 54 };

            using SolidBrush sb1 = new SolidBrush(C1_FormBackColor);
            using SolidBrush sb2 = new SolidBrush(C2_BackColor);
            using (SolidBrush sb3 = new SolidBrush(C3_BorderColor))
            {
                // Draw Form Background Color
                g.Graphics.FillRectangle(sb1, 0, 0, Width, Height);

                if (C10_PositionTop == true)
                {
                    // Draw Top Handle
                    g.Graphics.FillPolygon(sb3, new Point[] { p1, p2, p3, p4 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p5, p6, p7, p8 });
                }

                if (C11_PositionLeft == true)
                {
                    // Draw Left Handle
                    g.Graphics.FillPolygon(sb3, new Point[] { p9, p10, p11, p12 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p13, p14, p15, p16 });
                }

                if (C12_PositionRight == true)
                {
                    // Draw Right Handle
                    g.Graphics.FillPolygon(sb3, new Point[] { p17, p18, p19, p20 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p21, p22, p23, p24 });
                }
            }
        }
    }
}
