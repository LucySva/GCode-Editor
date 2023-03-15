using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCode_Editor
{
    // @@@ Minimize Maximize Close Buttons (not scalable) @@@
    public class CustomMinMaxCloseButtons : Button
    {
        // Variables Get Set
        public Color C1_FormBackColor { get; set; } = Color.FromArgb(248, 248, 228);
        public Color C2_BackColor { get; set; } = Color.FromArgb(255, 255, 255);
        public Color C3_CloseLightColor { get; set; } = Color.FromArgb(248, 192, 192);
        public Color C4_CloseMiddleColor { get; set; } = Color.FromArgb(244, 162, 162);
        public Color C5_CloseDarkColor { get; set; } = Color.FromArgb(241, 126, 126);
        public Color C6_MinMaxLightColor { get; set; } = Color.FromArgb(198, 221, 198);
        public Color C7_MinMaxMiddleColor { get; set; } = Color.FromArgb(167, 201, 167);
        public Color C8_MinMaxDarkColor { get; set; } = Color.FromArgb(142, 186, 142);
        public Color C9_ButtonCenterColor { get; set; } = Color.FromArgb(255, 255, 255);
        public Color C13_ButtonCenterBorderColor { get; set; } = Color.FromArgb(255, 255, 255);
        public bool C10_DrawMinButton { get; set; } = false;
        public bool C11_DrawMaxButton { get; set; } = false;
        public bool C12_DrawCloseButton { get; set; } = true;

        // Paint Call
        public CustomMinMaxCloseButtons()
        {
            Paint += new PaintEventHandler(CustomMinMaxCloseButtons_Paint);
        }

        // Main Paint 
        private void CustomMinMaxCloseButtons_Paint(object? sender, PaintEventArgs g)
        {
            // Left Light Bracket
            Point p1 = new Point { X = 5, Y = 1 };
            Point p2 = new Point { X = 1, Y = 5 };
            Point p3 = new Point { X = 1, Y = 17 };
            Point p4 = new Point { X = 5, Y = 21 };

            // Left Dark Bracket
            Point p5 = new Point { X = 5, Y = 2 };
            Point p6 = new Point { X = 2, Y = 5 };
            Point p7 = new Point { X = 2, Y = 17 };
            Point p8 = new Point { X = 5, Y = 20 };

            // Left White Space in the Bracket
            Point p9 = new Point { X = 6, Y = 2 };
            Point p10 = new Point { X = 3, Y = 5 };
            Point p11 = new Point { X = 3, Y = 17 };
            Point p12 = new Point { X = 6, Y = 20 };

            // Right Light Bracket
            Point p13 = new Point { X = 27, Y = 1 };
            Point p14 = new Point { X = 31, Y = 5 };
            Point p15 = new Point { X = 31, Y = 17 };
            Point p16 = new Point { X = 27, Y = 21 };

            // Right Dark Bracket
            Point p17 = new Point { X = 27, Y = 2 };
            Point p18 = new Point { X = 30, Y = 5 };
            Point p19 = new Point { X = 30, Y = 17 };
            Point p20 = new Point { X = 27, Y = 20 };

            // Right White Space in the Bracket
            Point p21 = new Point { X = 27, Y = 2 };
            Point p22 = new Point { X = 30, Y = 6 };
            Point p23 = new Point { X = 30, Y = 16 };
            Point p24 = new Point { X = 27, Y = 20 };

            // Middle Light Circle
            Point p25 = new Point { X = 10, Y = 1 };
            Point p26 = new Point { X = 22, Y = 1 };
            Point p27 = new Point { X = 26, Y = 5 };
            Point p28 = new Point { X = 26, Y = 17 };
            Point p29 = new Point { X = 22, Y = 21 };
            Point p30 = new Point { X = 10, Y = 21 };
            Point p31 = new Point { X = 6, Y = 17 };
            Point p32 = new Point { X = 6, Y = 5 };

            // Middle Dark Circle
            Point p33 = new Point { X = 10, Y = 2 };
            Point p34 = new Point { X = 22, Y = 2 };
            Point p35 = new Point { X = 25, Y = 5 };
            Point p36 = new Point { X = 25, Y = 17 };
            Point p37 = new Point { X = 22, Y = 20 };
            Point p38 = new Point { X = 10, Y = 20 };
            Point p39 = new Point { X = 7, Y = 17 };
            Point p40 = new Point { X = 7, Y = 5 };

            // X Shape
            Point p41 = new Point { X = 11, Y = 5 };
            Point p42 = new Point { X = 13, Y = 5 };
            Point p43 = new Point { X = 16, Y = 8 };
            Point p44 = new Point { X = 19, Y = 5 };
            Point p45 = new Point { X = 21, Y = 5 };
            Point p46 = new Point { X = 22, Y = 6 };
            Point p47 = new Point { X = 22, Y = 8 };
            Point p48 = new Point { X = 19, Y = 11 };
            Point p49 = new Point { X = 22, Y = 14 };
            Point p50 = new Point { X = 22, Y = 16 };
            Point p51 = new Point { X = 21, Y = 17 };
            Point p52 = new Point { X = 19, Y = 17 };
            Point p53 = new Point { X = 16, Y = 14 };
            Point p54 = new Point { X = 13, Y = 17 };
            Point p55 = new Point { X = 11, Y = 17 };
            Point p56 = new Point { X = 10, Y = 16 };
            Point p57 = new Point { X = 10, Y = 14 };
            Point p58 = new Point { X = 13, Y = 11 };
            Point p59 = new Point { X = 10, Y = 8 };
            Point p60 = new Point { X = 10, Y = 6 };

            // O Shape
            Point p61 = new Point { X = 12, Y = 5 };
            Point p62 = new Point { X = 20, Y = 5 };
            Point p63 = new Point { X = 22, Y = 7 };
            Point p64 = new Point { X = 22, Y = 15 };
            Point p65 = new Point { X = 20, Y = 17 };
            Point p66 = new Point { X = 12, Y = 17 };
            Point p67 = new Point { X = 10, Y = 15 };
            Point p68 = new Point { X = 10, Y = 7 };

            // O Shape inside O Shape
            Point p69 = new Point { X = 14, Y = 8 };
            Point p70 = new Point { X = 18, Y = 8 };
            Point p71 = new Point { X = 19, Y = 9 };
            Point p72 = new Point { X = 19, Y = 13 };
            Point p73 = new Point { X = 18, Y = 14 };
            Point p74 = new Point { X = 14, Y = 14 };
            Point p75 = new Point { X = 13, Y = 13 };
            Point p76 = new Point { X = 13, Y = 9 };

            // -- Shape
            Point p77 = new Point { X = 11, Y = 14 };
            Point p78 = new Point { X = 21, Y = 14 };
            Point p79 = new Point { X = 22, Y = 15 };
            Point p80 = new Point { X = 22, Y = 16 };
            Point p81 = new Point { X = 21, Y = 17 };
            Point p82 = new Point { X = 11, Y = 17 };
            Point p83 = new Point { X = 10, Y = 16 };
            Point p84 = new Point { X = 10, Y = 15 };

            using SolidBrush sb1 = new SolidBrush(C1_FormBackColor);
            using SolidBrush sb2 = new SolidBrush(C2_BackColor);
            using SolidBrush sb3 = new SolidBrush(C3_CloseLightColor);
            using SolidBrush sb4 = new SolidBrush(C4_CloseMiddleColor);
            using SolidBrush sb5 = new SolidBrush(C5_CloseDarkColor);
            using SolidBrush sb6 = new SolidBrush(C6_MinMaxLightColor);
            using SolidBrush sb7 = new SolidBrush(C7_MinMaxMiddleColor);
            using SolidBrush sb8 = new SolidBrush(C8_MinMaxDarkColor);
            using SolidBrush sb9 = new SolidBrush(C9_ButtonCenterColor);
            using SolidBrush sb13 = new SolidBrush(C13_ButtonCenterBorderColor);
            using Pen pen2 = new Pen(sb2, 1);
            using Pen pen3 = new Pen(sb3, 1);  // Red L
            using Pen pen4 = new Pen(sb4, 1);  // Red M
            using Pen pen5 = new Pen(sb5, 1);  // Red D
            using Pen pen6 = new Pen(sb6, 1);  // Green L
            using Pen pen7 = new Pen(sb7, 1);  // Green M
            using (Pen pen8 = new Pen(sb8, 1)) // Green D
            {
                // Draw Form Background Color
                g.Graphics.FillRectangle(sb1, 0, 0, Width, Height);

                // Draw Minimize Button
                if (C10_DrawMinButton == true)
                {
                    // Draw Left Bracket
                    g.Graphics.DrawLines(pen6, new Point[] { p1, p2, p3, p4 });
                    g.Graphics.DrawLines(pen8, new Point[] { p5, p6, p7, p8 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p9, p10, p11, p12 });

                    // Draw Right Bracket
                    g.Graphics.DrawLines(pen6, new Point[] { p13, p14, p15, p16 });
                    g.Graphics.DrawLines(pen8, new Point[] { p17, p18, p19, p20 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p21, p22, p23, p24 });

                    // Draw Middle Circle
                    g.Graphics.FillPolygon(sb9, new Point[] { p33, p34, p35, p36, p37, p38, p39, p40, });
                    g.Graphics.DrawLines(pen6, new Point[] { p25, p26, p27, p28, p29, p30, p31, p32, p25 });
                    g.Graphics.DrawLines(pen8, new Point[] { p33, p34, p35, p36, p37, p38, p39, p40, p33 });

                    // Draw --
                    g.Graphics.FillPolygon(sb13, new Point[] { p77, p78, p79, p80, p81, p82, p83, p84 });
                    g.Graphics.DrawLines(pen7, new Point[] { p77, p78, p79, p80, p81, p82, p83, p84, p77 });
                }

                // Draw Maximize Button
                if (C11_DrawMaxButton == true)
                {
                    // Draw Left Bracket
                    g.Graphics.DrawLines(pen6, new Point[] { p1, p2, p3, p4 });
                    g.Graphics.DrawLines(pen8, new Point[] { p5, p6, p7, p8 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p9, p10, p11, p12 });

                    // Draw Right Bracket
                    g.Graphics.DrawLines(pen6, new Point[] { p13, p14, p15, p16 });
                    g.Graphics.DrawLines(pen8, new Point[] { p17, p18, p19, p20 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p21, p22, p23, p24 });

                    // Draw Middle Circle
                    g.Graphics.FillPolygon(sb9, new Point[] { p33, p34, p35, p36, p37, p38, p39, p40, });
                    g.Graphics.DrawLines(pen6, new Point[] { p25, p26, p27, p28, p29, p30, p31, p32, p25 });
                    g.Graphics.DrawLines(pen8, new Point[] { p33, p34, p35, p36, p37, p38, p39, p40, p33 });

                    // Draw O
                    g.Graphics.FillPolygon(sb13, new Point[] { p61, p62, p63, p64, p65, p66, p67, p68 });
                    g.Graphics.DrawLines(pen7, new Point[] { p61, p62, p63, p64, p65, p66, p67, p68, p61 });
                    g.Graphics.FillPolygon(sb9, new Point[] { p69, p70, p71, p72, p73, p74, p75, p76 });
                    g.Graphics.DrawLines(pen2, new Point[] { p69, p70, p71, p72, p73, p74, p75, p76, p69 });
                }

                // Draw Close Button
                if (C12_DrawCloseButton == true)
                {
                    // Draw Left Bracket
                    g.Graphics.DrawLines(pen3, new Point[] { p1, p2, p3, p4 });
                    g.Graphics.DrawLines(pen5, new Point[] { p5, p6, p7, p8 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p9, p10, p11, p12 });

                    // Draw Right Bracket
                    g.Graphics.DrawLines(pen3, new Point[] { p13, p14, p15, p16 });
                    g.Graphics.DrawLines(pen5, new Point[] { p17, p18, p19, p20 });
                    g.Graphics.FillPolygon(sb2, new Point[] { p21, p22, p23, p24 });

                    // Draw Middle Circle
                    g.Graphics.FillPolygon(sb9, new Point[] { p33, p34, p35, p36, p37, p38, p39, p40, });
                    g.Graphics.DrawLines(pen3, new Point[] { p25, p26, p27, p28, p29, p30, p31, p32, p25 });
                    g.Graphics.DrawLines(pen5, new Point[] { p33, p34, p35, p36, p37, p38, p39, p40, p33 });

                    // Draw X
                    g.Graphics.FillPolygon(sb13, new Point[] { p41, p42, p43, p44, p45, p46, p47, p48, p49, p50, p51, p52, p53, p54, p55, p56, p57, p58, p59, p60 });
                    g.Graphics.DrawLines(pen4, new Point[] { p41, p42, p43, p44, p45, p46, p47, p48, p49, p50, p51, p52, p53, p54, p55, p56, p57, p58, p59, p60, p41 });
                }
            }
        }
    }
}
