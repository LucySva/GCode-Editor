namespace GCode_Editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            richTextBox1 = new RichTextBox();
            openFileDialog1 = new OpenFileDialog();
            richTextBox2 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label31 = new Label();
            label32 = new Label();
            CustomButton1 = new CustomButton();
            CustomPartAButton1 = new CustomPartAButton();
            CustomPartBButton1 = new CustomPartBButton();
            CustomButton2 = new CustomButton();
            CustomButton3 = new CustomButton();
            customProgressBar1 = new CustomProgressBar();
            CustomButton4 = new CustomButton();
            label33 = new Label();
            label34 = new Label();
            customBottomPanel1 = new CustomBottomPanel();
            label18 = new Label();
            label17 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            customMinMaxCloseButtons1 = new CustomMinMaxCloseButtons();
            customMinMaxCloseButtons2 = new CustomMinMaxCloseButtons();
            customMinMaxCloseButtons3 = new CustomMinMaxCloseButtons();
            customFormResizePanels1 = new CustomFormResizePanels();
            customFormResizePanels2 = new CustomFormResizePanels();
            customFormResizePanels3 = new CustomFormResizePanels();
            customProgressBar1.SuspendLayout();
            customBottomPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 54);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(544, 449);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.MouseClick += richTextBox1_MouseClick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(590, 54);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(544, 449);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            richTextBox2.KeyUp += richTextBox2_KeyUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(244, 36);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 4;
            label1.Text = "Original Code";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(825, 36);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 5;
            label2.Text = "Modified Code";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(272, 509);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 6;
            label3.Text = ". . .";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(12, 509);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 9;
            label4.Text = ". . .";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(589, 509);
            label5.Name = "label5";
            label5.Size = new Size(22, 15);
            label5.TabIndex = 10;
            label5.Text = ". . .";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(1112, 566);
            label6.Name = "label6";
            label6.Size = new Size(22, 15);
            label6.TabIndex = 11;
            label6.Text = ". . .";
            label6.SizeChanged += label6_SizeChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(1112, 543);
            label7.Name = "label7";
            label7.Size = new Size(22, 15);
            label7.TabIndex = 12;
            label7.Text = ". . .";
            label7.SizeChanged += label7_SizeChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 7);
            label8.Name = "label8";
            label8.Size = new Size(22, 15);
            label8.TabIndex = 14;
            label8.Text = ". . .";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Location = new Point(12, 539);
            label9.Name = "label9";
            label9.Size = new Size(128, 15);
            label9.TabIndex = 15;
            label9.Text = "G0 - Rapid positioning ";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label10.AutoSize = true;
            label10.Location = new Point(12, 554);
            label10.Name = "label10";
            label10.Size = new Size(135, 15);
            label10.TabIndex = 16;
            label10.Text = "G1 - Linear interpolation";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label11.AutoSize = true;
            label11.Location = new Point(12, 584);
            label11.Name = "label11";
            label11.Size = new Size(242, 15);
            label11.TabIndex = 18;
            label11.Text = "G3 - Counter clockwise circular interpolation";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label12.AutoSize = true;
            label12.Location = new Point(12, 569);
            label12.Name = "label12";
            label12.Size = new Size(198, 15);
            label12.TabIndex = 17;
            label12.Text = "G2 - Clockwise circular interpolation";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label13.AutoSize = true;
            label13.Location = new Point(330, 614);
            label13.Name = "label13";
            label13.Size = new Size(97, 15);
            label13.TabIndex = 22;
            label13.Text = "S - Spindle speed";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label14.AutoSize = true;
            label14.Location = new Point(330, 599);
            label14.Name = "label14";
            label14.Size = new Size(126, 15);
            label14.TabIndex = 21;
            label14.Text = "F - Interpolation speed";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label15.AutoSize = true;
            label15.Location = new Point(330, 659);
            label15.Name = "label15";
            label15.Size = new Size(381, 15);
            label15.TabIndex = 20;
            label15.Text = "I, J, K - Distance coordinates between the start point and a circle center ";
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label16.AutoSize = true;
            label16.Location = new Point(330, 644);
            label16.Name = "label16";
            label16.Size = new Size(207, 15);
            label16.TabIndex = 19;
            label16.Text = "X, Y, Z - Positioning point coordinates";
            // 
            // label19
            // 
            label19.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label19.AutoSize = true;
            label19.Location = new Point(330, 629);
            label19.Name = "label19";
            label19.Size = new Size(91, 15);
            label19.TabIndex = 23;
            label19.Text = "T - Tool number";
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label20.AutoSize = true;
            label20.Location = new Point(12, 659);
            label20.Name = "label20";
            label20.Size = new Size(212, 15);
            label20.TabIndex = 26;
            label20.Text = "G43 - Tool height offset compensation ";
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label21.AutoSize = true;
            label21.Location = new Point(12, 674);
            label21.Name = "label21";
            label21.Size = new Size(286, 15);
            label21.TabIndex = 27;
            label21.Text = "G90 - Coordinates relative to work coordinate system";
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label22.AutoSize = true;
            label22.Location = new Point(330, 539);
            label22.Name = "label22";
            label22.Size = new Size(157, 15);
            label22.TabIndex = 28;
            label22.Text = "M3 - Spindle On (Clockwise)";
            // 
            // label23
            // 
            label23.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label23.AutoSize = true;
            label23.Location = new Point(330, 554);
            label23.Name = "label23";
            label23.Size = new Size(205, 15);
            label23.TabIndex = 29;
            label23.Text = "M4 - Spindle On (Counter-Clockwise)";
            // 
            // label24
            // 
            label24.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label24.AutoSize = true;
            label24.Location = new Point(330, 569);
            label24.Name = "label24";
            label24.Size = new Size(94, 15);
            label24.TabIndex = 30;
            label24.Text = "M5 - Spindle Off";
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label25.AutoSize = true;
            label25.Location = new Point(330, 584);
            label25.Name = "label25";
            label25.Size = new Size(124, 15);
            label25.TabIndex = 31;
            label25.Text = "M30 - End of program";
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label26.AutoSize = true;
            label26.Location = new Point(12, 599);
            label26.Name = "label26";
            label26.Size = new Size(101, 15);
            label26.TabIndex = 32;
            label26.Text = "G17 - XY (Default)";
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label27.AutoSize = true;
            label27.Location = new Point(12, 614);
            label27.Name = "label27";
            label27.Size = new Size(52, 15);
            label27.TabIndex = 33;
            label27.Text = "G18 - ZX";
            // 
            // label28
            // 
            label28.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label28.AutoSize = true;
            label28.Location = new Point(12, 644);
            label28.Name = "label28";
            label28.Size = new Size(203, 15);
            label28.TabIndex = 35;
            label28.Text = "G21 - Use millimeters for length units";
            // 
            // label29
            // 
            label29.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label29.AutoSize = true;
            label29.Location = new Point(12, 629);
            label29.Name = "label29";
            label29.Size = new Size(52, 15);
            label29.TabIndex = 34;
            label29.Text = "G19 - YZ";
            // 
            // label31
            // 
            label31.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label31.AutoSize = true;
            label31.Location = new Point(1112, 589);
            label31.Name = "label31";
            label31.Size = new Size(22, 15);
            label31.TabIndex = 37;
            label31.Text = ". . .";
            label31.SizeChanged += label31_SizeChanged;
            // 
            // label32
            // 
            label32.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label32.AutoSize = true;
            label32.BackColor = Color.FromArgb(234, 234, 234);
            label32.Location = new Point(1112, 5);
            label32.Name = "label32";
            label32.Size = new Size(22, 15);
            label32.TabIndex = 38;
            label32.Text = ". . .";
            label32.SizeChanged += label32_SizeChanged;
            // 
            // CustomButton1
            // 
            CustomButton1.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            CustomButton1.C2_ButtonBorderBackColor = Color.FromArgb(198, 221, 198);
            CustomButton1.C3_ButtonBackColor = Color.FromArgb(142, 186, 142);
            CustomButton1.C4_ButtonDesignColor = Color.FromArgb(255, 255, 255);
            CustomButton1.C5_TextColor = Color.FromArgb(255, 255, 255);
            CustomButton1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CustomButton1.Location = new Point(12, 25);
            CustomButton1.Name = "CustomButton1";
            CustomButton1.Size = new Size(100, 26);
            CustomButton1.TabIndex = 40;
            CustomButton1.Text = "Open File";
            CustomButton1.UseVisualStyleBackColor = true;
            CustomButton1.Click += CustomButton1_Click;
            CustomButton1.MouseEnter += CustomButton1_MouseEnter;
            CustomButton1.MouseLeave += CustomButton1_MouseLeave;
            // 
            // CustomPartAButton1
            // 
            CustomPartAButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CustomPartAButton1.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            CustomPartAButton1.C2_ButtonBorderBackColor = Color.FromArgb(198, 221, 198);
            CustomPartAButton1.C3_ButtonBackColor = Color.FromArgb(142, 186, 142);
            CustomPartAButton1.C4_ButtonDesignColor = Color.FromArgb(255, 255, 255);
            CustomPartAButton1.C5_TextColor = Color.FromArgb(255, 255, 255);
            CustomPartAButton1.C6_ButtonColumnLineColor = Color.FromArgb(133, 182, 133);
            CustomPartAButton1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CustomPartAButton1.Location = new Point(933, 506);
            CustomPartAButton1.Name = "CustomPartAButton1";
            CustomPartAButton1.Size = new Size(100, 26);
            CustomPartAButton1.TabIndex = 41;
            CustomPartAButton1.Text = "Save as .txt";
            CustomPartAButton1.UseVisualStyleBackColor = true;
            CustomPartAButton1.Click += CustomPartAButton1_Click;
            CustomPartAButton1.MouseEnter += CustomPartAButton1_MouseEnter;
            CustomPartAButton1.MouseLeave += CustomPartAButton1_MouseLeave;
            // 
            // CustomPartBButton1
            // 
            CustomPartBButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CustomPartBButton1.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            CustomPartBButton1.C2_ButtonBorderBackColor = Color.FromArgb(198, 221, 198);
            CustomPartBButton1.C3_ButtonBackColor = Color.FromArgb(142, 186, 142);
            CustomPartBButton1.C4_ButtonDesignColor = Color.FromArgb(255, 255, 255);
            CustomPartBButton1.C5_TextColor = Color.FromArgb(255, 255, 255);
            CustomPartBButton1.C6_ButtonColumnLineColor = Color.FromArgb(133, 182, 133);
            CustomPartBButton1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CustomPartBButton1.Location = new Point(1033, 506);
            CustomPartBButton1.Name = "CustomPartBButton1";
            CustomPartBButton1.Size = new Size(100, 26);
            CustomPartBButton1.TabIndex = 42;
            CustomPartBButton1.Text = "Save as .tap";
            CustomPartBButton1.UseVisualStyleBackColor = true;
            CustomPartBButton1.Click += CustomPartBButton1_Click;
            CustomPartBButton1.MouseEnter += CustomPartBButton1_MouseEnter;
            CustomPartBButton1.MouseLeave += CustomPartBButton1_MouseLeave;
            // 
            // CustomButton2
            // 
            CustomButton2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CustomButton2.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            CustomButton2.C2_ButtonBorderBackColor = Color.FromArgb(198, 221, 198);
            CustomButton2.C3_ButtonBackColor = Color.FromArgb(142, 186, 142);
            CustomButton2.C4_ButtonDesignColor = Color.FromArgb(255, 255, 255);
            CustomButton2.C5_TextColor = Color.FromArgb(255, 255, 255);
            CustomButton2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CustomButton2.Location = new Point(1033, 663);
            CustomButton2.Name = "CustomButton2";
            CustomButton2.Size = new Size(100, 26);
            CustomButton2.TabIndex = 43;
            CustomButton2.Text = "Open Folder";
            CustomButton2.UseVisualStyleBackColor = true;
            CustomButton2.Click += CustomButton2_Click;
            CustomButton2.MouseEnter += CustomButton2_MouseEnter;
            CustomButton2.MouseLeave += CustomButton2_MouseLeave;
            // 
            // CustomButton3
            // 
            CustomButton3.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            CustomButton3.C2_ButtonBorderBackColor = Color.FromArgb(248, 192, 192);
            CustomButton3.C3_ButtonBackColor = Color.FromArgb(241, 126, 126);
            CustomButton3.C4_ButtonDesignColor = Color.FromArgb(255, 255, 255);
            CustomButton3.C5_TextColor = Color.FromArgb(255, 255, 255);
            CustomButton3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CustomButton3.Location = new Point(488, 25);
            CustomButton3.Name = "CustomButton3";
            CustomButton3.Size = new Size(171, 26);
            CustomButton3.TabIndex = 44;
            CustomButton3.Text = "Delete and Remove Texts";
            CustomButton3.UseVisualStyleBackColor = true;
            CustomButton3.Click += CustomButton3_Click;
            CustomButton3.MouseEnter += CustomButton3_MouseEnter;
            CustomButton3.MouseLeave += CustomButton3_MouseLeave;
            // 
            // customProgressBar1
            // 
            customProgressBar1.C1_BackColor = Color.FromArgb(255, 255, 255);
            customProgressBar1.C10_columnList = (List<int>)resources.GetObject("customProgressBar1.C10_columnList");
            customProgressBar1.C2_Outer1of4 = Color.FromArgb(215, 215, 215);
            customProgressBar1.C3_Outer2of4 = Color.FromArgb(173, 173, 173);
            customProgressBar1.C4_Outer3of4 = Color.FromArgb(102, 102, 102);
            customProgressBar1.C5_Outer4of4 = Color.FromArgb(50, 50, 50);
            customProgressBar1.C6_Increment = 0;
            customProgressBar1.C7_LeadingBarColor = Color.FromArgb(37, 192, 84);
            customProgressBar1.C8_FormBackColor = Color.FromArgb(248, 248, 228);
            customProgressBar1.Controls.Add(CustomButton4);
            customProgressBar1.Location = new Point(497, 241);
            customProgressBar1.Name = "customProgressBar1";
            customProgressBar1.Size = new Size(153, 75);
            customProgressBar1.TabIndex = 45;
            // 
            // CustomButton4
            // 
            CustomButton4.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            CustomButton4.C2_ButtonBorderBackColor = Color.FromArgb(248, 192, 192);
            CustomButton4.C3_ButtonBackColor = Color.FromArgb(241, 126, 126);
            CustomButton4.C4_ButtonDesignColor = Color.FromArgb(255, 255, 255);
            CustomButton4.C5_TextColor = Color.FromArgb(255, 255, 255);
            CustomButton4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CustomButton4.Location = new Point(38, 39);
            CustomButton4.Name = "CustomButton4";
            CustomButton4.Size = new Size(77, 26);
            CustomButton4.TabIndex = 46;
            CustomButton4.Text = "Stop";
            CustomButton4.UseVisualStyleBackColor = true;
            CustomButton4.Click += CustomButton4_Click;
            CustomButton4.MouseEnter += CustomButton4_MouseEnter;
            CustomButton4.MouseLeave += CustomButton4_MouseLeave;
            // 
            // label33
            // 
            label33.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label33.AutoSize = true;
            label33.Location = new Point(1112, 612);
            label33.Name = "label33";
            label33.Size = new Size(22, 15);
            label33.TabIndex = 47;
            label33.Text = ". . .";
            label33.SizeChanged += label33_SizeChanged;
            // 
            // label34
            // 
            label34.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label34.AutoSize = true;
            label34.Location = new Point(1112, 635);
            label34.Name = "label34";
            label34.Size = new Size(22, 15);
            label34.TabIndex = 48;
            label34.Text = ". . .";
            label34.SizeChanged += label34_SizeChanged;
            // 
            // customBottomPanel1
            // 
            customBottomPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customBottomPanel1.C1_BackColor = Color.FromArgb(234, 234, 234);
            customBottomPanel1.C2_TopLineColor = Color.FromArgb(209, 209, 209);
            customBottomPanel1.Controls.Add(label18);
            customBottomPanel1.Controls.Add(label17);
            customBottomPanel1.Controls.Add(label32);
            customBottomPanel1.Location = new Point(2, 693);
            customBottomPanel1.Name = "customBottomPanel1";
            customBottomPanel1.Size = new Size(1142, 25);
            customBottomPanel1.TabIndex = 49;
            // 
            // label18
            // 
            label18.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label18.AutoSize = true;
            label18.BackColor = Color.FromArgb(234, 234, 234);
            label18.Location = new Point(8, 5);
            label18.Name = "label18";
            label18.Size = new Size(22, 15);
            label18.TabIndex = 40;
            label18.Text = ". . .";
            label18.Click += label18_Click;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label17.AutoSize = true;
            label17.BackColor = Color.FromArgb(234, 234, 234);
            label17.Location = new Point(562, 5);
            label17.Name = "label17";
            label17.Size = new Size(22, 15);
            label17.TabIndex = 39;
            label17.Text = ". . .";
            label17.SizeChanged += label17_SizeChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            // 
            // customMinMaxCloseButtons1
            // 
            customMinMaxCloseButtons1.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            customMinMaxCloseButtons1.C10_DrawMinButton = true;
            customMinMaxCloseButtons1.C11_DrawMaxButton = false;
            customMinMaxCloseButtons1.C12_DrawCloseButton = false;
            customMinMaxCloseButtons1.C13_ButtonCenterBorderColor = Color.FromArgb(142, 186, 142);
            customMinMaxCloseButtons1.C2_BackColor = Color.FromArgb(255, 255, 255);
            customMinMaxCloseButtons1.C3_CloseLightColor = Color.FromArgb(248, 192, 192);
            customMinMaxCloseButtons1.C4_CloseMiddleColor = Color.FromArgb(244, 162, 162);
            customMinMaxCloseButtons1.C5_CloseDarkColor = Color.FromArgb(241, 126, 126);
            customMinMaxCloseButtons1.C6_MinMaxLightColor = Color.FromArgb(198, 221, 198);
            customMinMaxCloseButtons1.C7_MinMaxMiddleColor = Color.FromArgb(167, 201, 167);
            customMinMaxCloseButtons1.C8_MinMaxDarkColor = Color.FromArgb(142, 186, 142);
            customMinMaxCloseButtons1.C9_ButtonCenterColor = Color.FromArgb(255, 255, 255);
            customMinMaxCloseButtons1.Location = new Point(1035, 6);
            customMinMaxCloseButtons1.Name = "customMinMaxCloseButtons1";
            customMinMaxCloseButtons1.Size = new Size(33, 23);
            customMinMaxCloseButtons1.TabIndex = 50;
            customMinMaxCloseButtons1.Text = "customMinMaxCloseButtons1";
            customMinMaxCloseButtons1.UseVisualStyleBackColor = true;
            customMinMaxCloseButtons1.Click += customMinMaxCloseButtons1_Click;
            customMinMaxCloseButtons1.MouseEnter += customMinMaxCloseButtons1_MouseEnter;
            customMinMaxCloseButtons1.MouseLeave += customMinMaxCloseButtons1_MouseLeave;
            // 
            // customMinMaxCloseButtons2
            // 
            customMinMaxCloseButtons2.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            customMinMaxCloseButtons2.C10_DrawMinButton = false;
            customMinMaxCloseButtons2.C11_DrawMaxButton = true;
            customMinMaxCloseButtons2.C12_DrawCloseButton = false;
            customMinMaxCloseButtons2.C13_ButtonCenterBorderColor = Color.FromArgb(142, 186, 142);
            customMinMaxCloseButtons2.C2_BackColor = Color.FromArgb(255, 255, 255);
            customMinMaxCloseButtons2.C3_CloseLightColor = Color.FromArgb(248, 192, 192);
            customMinMaxCloseButtons2.C4_CloseMiddleColor = Color.FromArgb(244, 162, 162);
            customMinMaxCloseButtons2.C5_CloseDarkColor = Color.FromArgb(241, 126, 126);
            customMinMaxCloseButtons2.C6_MinMaxLightColor = Color.FromArgb(198, 221, 198);
            customMinMaxCloseButtons2.C7_MinMaxMiddleColor = Color.FromArgb(167, 201, 167);
            customMinMaxCloseButtons2.C8_MinMaxDarkColor = Color.FromArgb(142, 186, 142);
            customMinMaxCloseButtons2.C9_ButtonCenterColor = Color.FromArgb(255, 255, 255);
            customMinMaxCloseButtons2.Location = new Point(1071, 6);
            customMinMaxCloseButtons2.Name = "customMinMaxCloseButtons2";
            customMinMaxCloseButtons2.Size = new Size(33, 23);
            customMinMaxCloseButtons2.TabIndex = 51;
            customMinMaxCloseButtons2.Text = "customMinMaxCloseButtons2";
            customMinMaxCloseButtons2.UseVisualStyleBackColor = true;
            customMinMaxCloseButtons2.Click += customMinMaxCloseButtons2_Click;
            customMinMaxCloseButtons2.MouseEnter += customMinMaxCloseButtons2_MouseEnter;
            customMinMaxCloseButtons2.MouseLeave += customMinMaxCloseButtons2_MouseLeave;
            // 
            // customMinMaxCloseButtons3
            // 
            customMinMaxCloseButtons3.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            customMinMaxCloseButtons3.C10_DrawMinButton = false;
            customMinMaxCloseButtons3.C11_DrawMaxButton = false;
            customMinMaxCloseButtons3.C12_DrawCloseButton = true;
            customMinMaxCloseButtons3.C13_ButtonCenterBorderColor = Color.FromArgb(241, 126, 126);
            customMinMaxCloseButtons3.C2_BackColor = Color.FromArgb(255, 255, 255);
            customMinMaxCloseButtons3.C3_CloseLightColor = Color.FromArgb(248, 192, 192);
            customMinMaxCloseButtons3.C4_CloseMiddleColor = Color.FromArgb(244, 162, 162);
            customMinMaxCloseButtons3.C5_CloseDarkColor = Color.FromArgb(241, 126, 126);
            customMinMaxCloseButtons3.C6_MinMaxLightColor = Color.FromArgb(198, 221, 198);
            customMinMaxCloseButtons3.C7_MinMaxMiddleColor = Color.FromArgb(167, 201, 167);
            customMinMaxCloseButtons3.C8_MinMaxDarkColor = Color.FromArgb(142, 186, 142);
            customMinMaxCloseButtons3.C9_ButtonCenterColor = Color.FromArgb(255, 255, 255);
            customMinMaxCloseButtons3.Location = new Point(1107, 6);
            customMinMaxCloseButtons3.Name = "customMinMaxCloseButtons3";
            customMinMaxCloseButtons3.Size = new Size(33, 23);
            customMinMaxCloseButtons3.TabIndex = 52;
            customMinMaxCloseButtons3.Text = "customMinMaxCloseButtons3";
            customMinMaxCloseButtons3.UseVisualStyleBackColor = true;
            customMinMaxCloseButtons3.Click += customMinMaxCloseButtons3_Click;
            customMinMaxCloseButtons3.MouseEnter += customMinMaxCloseButtons3_MouseEnter;
            customMinMaxCloseButtons3.MouseLeave += customMinMaxCloseButtons3_MouseLeave;
            // 
            // customFormResizePanels1
            // 
            customFormResizePanels1.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            customFormResizePanels1.C10_PositionTop = false;
            customFormResizePanels1.C11_PositionLeft = false;
            customFormResizePanels1.C12_PositionRight = true;
            customFormResizePanels1.C2_BackColor = Color.FromArgb(142, 186, 142);
            customFormResizePanels1.C3_BorderColor = Color.FromArgb(199, 199, 199);
            customFormResizePanels1.Cursor = Cursors.SizeWE;
            customFormResizePanels1.Location = new Point(1136, 300);
            customFormResizePanels1.Name = "customFormResizePanels1";
            customFormResizePanels1.Size = new Size(8, 120);
            customFormResizePanels1.TabIndex = 53;
            customFormResizePanels1.MouseDown += customFormResizePanels1_MouseDown;
            customFormResizePanels1.MouseEnter += customFormResizePanels1_MouseEnter;
            customFormResizePanels1.MouseLeave += customFormResizePanels1_MouseLeave;
            customFormResizePanels1.MouseMove += customFormResizePanels1_MouseMove;
            customFormResizePanels1.MouseUp += customFormResizePanels1_MouseUp;
            // 
            // customFormResizePanels2
            // 
            customFormResizePanels2.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            customFormResizePanels2.C10_PositionTop = false;
            customFormResizePanels2.C11_PositionLeft = true;
            customFormResizePanels2.C12_PositionRight = false;
            customFormResizePanels2.C2_BackColor = Color.FromArgb(142, 186, 142);
            customFormResizePanels2.C3_BorderColor = Color.FromArgb(199, 199, 199);
            customFormResizePanels2.Cursor = Cursors.SizeWE;
            customFormResizePanels2.Location = new Point(2, 300);
            customFormResizePanels2.Name = "customFormResizePanels2";
            customFormResizePanels2.Size = new Size(8, 120);
            customFormResizePanels2.TabIndex = 54;
            customFormResizePanels2.MouseDown += customFormResizePanels2_MouseDown;
            customFormResizePanels2.MouseEnter += customFormResizePanels2_MouseEnter;
            customFormResizePanels2.MouseLeave += customFormResizePanels2_MouseLeave;
            customFormResizePanels2.MouseMove += customFormResizePanels2_MouseMove;
            customFormResizePanels2.MouseUp += customFormResizePanels2_MouseUp;
            // 
            // customFormResizePanels3
            // 
            customFormResizePanels3.BackColor = Color.FromArgb(248, 248, 228);
            customFormResizePanels3.C1_FormBackColor = Color.FromArgb(248, 248, 228);
            customFormResizePanels3.C10_PositionTop = true;
            customFormResizePanels3.C11_PositionLeft = false;
            customFormResizePanels3.C12_PositionRight = false;
            customFormResizePanels3.C2_BackColor = Color.FromArgb(142, 186, 142);
            customFormResizePanels3.C3_BorderColor = Color.FromArgb(199, 199, 199);
            customFormResizePanels3.Cursor = Cursors.SizeNS;
            customFormResizePanels3.Location = new Point(515, 2);
            customFormResizePanels3.Name = "customFormResizePanels3";
            customFormResizePanels3.Size = new Size(120, 8);
            customFormResizePanels3.TabIndex = 55;
            customFormResizePanels3.MouseDown += customFormResizePanels3_MouseDown;
            customFormResizePanels3.MouseEnter += customFormResizePanels3_MouseEnter;
            customFormResizePanels3.MouseLeave += customFormResizePanels3_MouseLeave;
            customFormResizePanels3.MouseMove += customFormResizePanels3_MouseMove;
            customFormResizePanels3.MouseUp += customFormResizePanels3_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 248, 228);
            ClientSize = new Size(1146, 720);
            Controls.Add(customFormResizePanels3);
            Controls.Add(customFormResizePanels2);
            Controls.Add(customFormResizePanels1);
            Controls.Add(customMinMaxCloseButtons3);
            Controls.Add(customMinMaxCloseButtons2);
            Controls.Add(customMinMaxCloseButtons1);
            Controls.Add(customBottomPanel1);
            Controls.Add(label34);
            Controls.Add(label33);
            Controls.Add(customProgressBar1);
            Controls.Add(CustomButton3);
            Controls.Add(CustomButton2);
            Controls.Add(CustomPartBButton1);
            Controls.Add(CustomPartAButton1);
            Controls.Add(CustomButton1);
            Controls.Add(label31);
            Controls.Add(label28);
            Controls.Add(label29);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(label25);
            Controls.Add(label24);
            Controls.Add(label23);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "G-Code Editor";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            Resize += Form1_Resize;
            customProgressBar1.ResumeLayout(false);
            customBottomPanel1.ResumeLayout(false);
            customBottomPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox richTextBox1;
        private OpenFileDialog openFileDialog1;
        private RichTextBox richTextBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label31;
        private Label label32;
        private CustomButton CustomButton1;
        private CustomPartAButton CustomPartAButton1;
        private CustomPartBButton CustomPartBButton1;
        private CustomButton CustomButton2;
        private CustomButton CustomButton3;
        private CustomProgressBar customProgressBar1;
        private CustomButton CustomButton4;
        private Label label33;
        private Label label34;
        private CustomBottomPanel customBottomPanel1;
        private NotifyIcon notifyIcon1;
        private Label label17;
        private CustomMinMaxCloseButtons customMinMaxCloseButtons1;
        private CustomMinMaxCloseButtons customMinMaxCloseButtons2;
        private CustomMinMaxCloseButtons customMinMaxCloseButtons3;
        private CustomFormResizePanels customFormResizePanels1;
        private CustomFormResizePanels customFormResizePanels2;
        private CustomFormResizePanels customFormResizePanels3;
        private Label label18;
    }
}