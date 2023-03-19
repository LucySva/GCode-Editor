using Microsoft.VisualBasic.Devices;
using System.Reflection.Emit;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Drawing;

namespace GCode_Editor
{
    public partial class Form1 : Form
    {
        // @@@@@@@@@@@@@@@@@@@ SETTINGS @@@@@@@@@@@@@@@@@@@
        readonly Color inputRTB1GCodeColor = Color.Red;   // Highlight a text that needs to be edited
        readonly Color outputRTB2GCodeColor = Color.Blue; // Highlighted text that was edited
        readonly Color searchedBackColor = Color.Pink;    // Clicked text in RTB1 is Highlighted and searched in RTB2 where it is also Highlighted
        readonly Color labelGreenColor = Color.Green;     // Good label color (Basicly no changes occurred)
        readonly Color labelRedColor = Color.Red;         // Indicating a Warning (Changes has been made that might effect the G-Code output)
        readonly Color labelDefaultColor = SystemColors.ControlText;

        // Final Messages
        readonly string popupSuccessMessage = @". . . // LOADING COMPLETE \\ . . .";
        readonly string popupFailMessage = @". . . // LOADING PROCESS FAILED \\ . . .";
        readonly string popupSaveMessage = @". . . // SAVING COMPLETE \\ . . .";

        // File Saving Path 
        readonly string savingFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Edited TAP TXT Files";

        // Settings
        readonly string settingFilePathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\G-Code Editor";
        readonly string settingFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\G-Code Editor\" + "Settings.txt";

        // Button Colors - Used when Mouse Enters/Leaves a Custom Button
        readonly Color defaultGreen = Color.FromArgb(142, 186, 142);
        readonly Color defaultWhite = Color.FromArgb(255, 255, 255);
        readonly Color defaultRed = Color.FromArgb(241, 126, 126);
        readonly Color hoverGreen = Color.FromArgb(90, 146, 90);
        readonly Color hoverRed = Color.FromArgb(234, 72, 72);

        // Custom Main Form Border Color
        readonly Color lightLayer = Color.FromArgb(199, 199, 199);
        readonly Color darkLayer = Color.FromArgb(136, 136, 136);

        // Application Size
        readonly int applicationMinimalWidth = 830;
        readonly int applicationMinimalHeight = 415;
        readonly int defaultWidth = 1146;
        readonly int defaultHeight = 720;
        readonly string defaultSavingWidth = "Width=1146";
        readonly string defaultSavingHeight = "Height=720";

        // Small Loaded Files Skipping
        readonly int skipProgressBarGraphicsInSmallFiles = 400; // 400 and less
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        // Variables
        Dictionary<string, string> settingsListDictionary = new Dictionary<string, string>();
        DateTime dateTime;
        Point oldFormPosition;
        Point newFormPosition;
        Point clickedMousePosition;
        string fileAddress = ". . .";
        bool printRTB2Line = true;
        bool mouseHoldingDown = false;
        bool blockFinalMessage = false;
        bool stopButtonPressed = false;
        bool enableSettingSaving = false;
        bool mouseAboveStopButton = false;
        bool allowEntryToG1Section = false;
        bool notifyIconAppShowHide = false;
        bool loadingProcessInterrupted = false;
        bool formLoadedFromMinimizedState = false;
        int linesToEditCounter = 0;
        int unrecognizedCode = 0;
        int counterToEnter = 0;
        int fileLinesCount = 0;
        int limitCounter = 0;

        // @@@@@@@@@@@@@@@@@@
        // @@@ Initialize @@@
        // @@@@@@@@@@@@@@@@@@
        public Form1()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = true;
            customProgressBar1.Visible = false;
            notifyIcon1.Visible = true;
            label17.Visible = false; // Successfully Saved To...

            Paint += new PaintEventHandler(CustomForm_Paint);
        }

        // @@@@@@@@@@@@@@@@@
        // @@@ Form Load @@@
        // @@@@@@@@@@@@@@@@@
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load Settings
            if (File.Exists(settingFilePath) == true)
            {
                using (StreamReader sr = new StreamReader(settingFilePath))
                {
                    string[] splitArray;

                    // Reading > Splitting > Storing
                    foreach (var item in File.ReadLines(settingFilePath))
                    {
                        if (item.Contains('='))
                        {
                            splitArray = item.Split('=');
                            settingsListDictionary.Add(splitArray[0], splitArray[1]);
                        }
                    }

                    int locX = 0;
                    int locY = 0;
                    int defaultLocationX = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2);
                    int defaultLocationY = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (Height / 2);

                    // Loading the settings
                    foreach (var item in settingsListDictionary)
                    {
                        if (item.Value != "" && item.Value != " ")
                        {
                            if (item.Key == "Width")
                            {
                                Width = (int.TryParse(item.Value, out _) == true) ? Convert.ToInt32(item.Value) : defaultWidth;
                            }
                            else if (item.Key == "Height")
                            {
                                Height = (int.TryParse(item.Value, out _) == true) ? Convert.ToInt32(item.Value) : defaultHeight;
                            }
                            else if (item.Key == "LocationX")
                            {
                                locX = (int.TryParse(item.Value, out _) == true) ? Convert.ToInt32(item.Value) : defaultLocationX;
                            }
                            else if (item.Key == "LocationY")
                            {
                                locY = (int.TryParse(item.Value, out _) == true) ? Convert.ToInt32(item.Value) : defaultLocationY;
                            }
                        }
                    }

                    if (locX != 0 && locY != 0)
                    {
                        Location = new Point(locX, locY);
                    }

                    settingsListDictionary.Clear();
                }
            }

            if (File.Exists(settingFilePath) == true)
            {
                ShowSettingFilePath();
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Main Form Paint @@@
        // @@@@@@@@@@@@@@@@@@@@@@@
        private void CustomForm_Paint(object? sender, PaintEventArgs g)
        {
            // Drawing Correction
            int width = Width - 1;
            int height = Height - 1;

            // Borders
            Point p1 = new Point { X = width - width, Y = height - height };
            Point p2 = new Point { X = width, Y = height - height };
            Point p3 = new Point { X = width, Y = height };
            Point p4 = new Point { X = width - width, Y = height };

            Point p5 = new Point { X = p1.X + 1, Y = p1.Y + 1 };
            Point p6 = new Point { X = p2.X - 1, Y = p2.Y + 1 };
            Point p7 = new Point { X = p3.X - 1, Y = p3.Y - 1 };
            Point p8 = new Point { X = p4.X + 1, Y = p4.Y - 1 };

            using SolidBrush sb1 = new SolidBrush(darkLayer);
            using SolidBrush sb2 = new SolidBrush(lightLayer);
            using Pen pen1 = new Pen(sb1, 1);
            using (Pen pen2 = new Pen(sb2, 1))
            {
                // Draw Form Outer Border
                g.Graphics.DrawLines(pen1, new Point[] { p1, p2, p3, p4, p1 });
                g.Graphics.DrawLines(pen2, new Point[] { p5, p6, p7, p8, p5 });
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Open File Button - Main Working Area - Async @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private async void CustomButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text File (*.txt;*.tap)|*.txt;*.tap";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in openFileDialog1.FileNames)
                {
                    fileAddress = item;

                    // Multiselect is OFF so, only one selected item is allowed even if the Multiselect was turned ON
                    break;
                }

                // File Path - Label text
                if (fileAddress != "")
                    label8.Text = fileAddress;

                // Reset
                AdditionalResetFunction();

                // Also an Error Prevention
                if (File.Exists(fileAddress) == true)
                {
                    // Get total number of lines from the loaded file
                    fileLinesCount = File.ReadLines(fileAddress).Count();
                    int progresBarBarsIncrement = fileLinesCount / 25; // 25 Bars in a ProgressBar

                    BlockUserFromChangingTextFunction(true);
                    BlockUserFromClickingOnButtonsFunction(true);

                    // Erasor of any text that was there before the loading of a New Code
                    // Do not delete this two lines unless you want to damage the CNC machine !
                    richTextBox1.Clear();
                    richTextBox2.Clear();

                    // Reading the G-Code Text File .tap or .txt
                    foreach (string line in File.ReadLines(fileAddress))
                    {
                        // @@@ G1 Section @@@
                        if (allowEntryToG1Section == true)
                        {
                            if (line != "")
                            {
                                if (line[0] == 'Z' && line != "Z5." && line != "Z15.")
                                {
                                    ColoringFunction();
                                    richTextBox2.AppendText("G1 ");
                                    allowEntryToG1Section = false;
                                    linesToEditCounter++;
                                }
                            }
                        }

                        // @@@ Logic Section @@@
                        if (line.Contains("WHEN USING FUSION 360 FOR PERSONAL USE, THE FEEDRATE OF") ||
                                    line.Contains("RAPID MOVES IS REDUCED TO MATCH THE FEEDRATE OF CUTTING") ||
                                    line.Contains("MOVES, WHICH CAN INCREASE MACHINING TIME. UNRESTRICTED RAPID") ||
                                    line.Contains("MOVES ARE AVAILABLE WITH A FUSION 360 SUBSCRIPTION."))
                        {
                            ColoringFunction();
                            RichTextBox2Function("(. . .)", false, false, false);
                        }
                        else if (line.Contains("Z5"))
                        {
                            if (line == "G1 Z5.")
                            {
                                ColoringFunction();
                                RichTextBox2Function(line.Replace("G1", "G0"), false, true, true);
                            }
                            else if (line == "Z5.")
                            {
                                ColoringFunction();
                                RichTextBox2Function("G0 Z5.", false, true, true);
                            }
                            else if (line == "G1 Z5. F500.")
                            {
                                richTextBox1.SelectionColor = Color.Orange;
                                // Do nothing else, for now.
                            }
                            else
                            {
                                richTextBox1.SelectionBackColor = Color.Khaki;

                                // Found New Unrecognized G-Code (If this happens, new conditions have to be added)
                                unrecognizedCode++;
                            }
                        }
                        else if (line.Contains("Z15"))
                        {
                            if (line == "G1 Z15. F500.")
                            {
                                ColoringFunction();
                                RichTextBox2Function(line.Replace("G1", "G0"), false, true, true);
                            }
                            else if (line == "G1 Z15.")
                            {
                                ColoringFunction();
                                RichTextBox2Function(line.Replace("G1", "G0"), false, true, true);
                            }
                            else if (line == "Z15.")
                            {
                                ColoringFunction();
                                RichTextBox2Function("G0 Z15.", false, true, true);
                            }
                            else if (!line.Contains("G43"))
                            {
                                richTextBox1.SelectionBackColor = Color.OrangeRed;

                                // Found New Unrecognized G-Code (If this happens, new conditions have to be added)
                                unrecognizedCode++;
                            }
                        }

                        // Print RTB1
                        richTextBox1.AppendText(line + Environment.NewLine);

                        // Print RTB2
                        if (printRTB2Line == true)
                            richTextBox2.AppendText(line + Environment.NewLine);

                        // Reset
                        printRTB2Line = true;

                        // Skip ProgressBar Graphics in small files
                        if (fileLinesCount >= skipProgressBarGraphicsInSmallFiles)
                        {
                            // @@@ Logic - ProgressBar Section @@@

                            counterToEnter++;

                            // 1/2 Show ProgressBar/Button
                            if (counterToEnter == 1)
                            {
                                // Show the ProgressBar/Button
                                customProgressBar1.Visible = true;

                                await Task.Delay(TimeSpan.FromMilliseconds(30));
                            }

                            // 2/2 Invalidate ProgressBar Graphics
                            if (counterToEnter >= progresBarBarsIncrement)
                            {
                                // 25 Column ProgressBar Limit
                                if (limitCounter <= 23)
                                {
                                    await Task.Delay(TimeSpan.FromMilliseconds(30));

                                    customProgressBar1.Invalidate();
                                    customProgressBar1.C6_Increment++;
                                    limitCounter++;
                                }

                                // Reset
                                counterToEnter = 0;
                            }

                            // Stop Button (ProgressBar) Mouse Enter/Leave
                            if (mouseAboveStopButton == true)
                            {
                                await Task.Delay(TimeSpan.FromMilliseconds(2000));

                                mouseAboveStopButton = false;
                            }

                            // Stopping the loop - Stop Button has been pressed
                            if (stopButtonPressed == true)
                            {
                                // Reset
                                stopButtonPressed = false;

                                break;
                            }
                        }
                    } // END of foreach

                    BlockUserFromChangingTextFunction(false);
                    BlockUserFromClickingOnButtonsFunction(false);

                    LabelsTextAssigning();

                    // Hide the ProgressBar/Button once the loading process is finished
                    customProgressBar1.Visible = false;

                    // Final Message - Windows Popup
                    if (blockFinalMessage == true)
                    {
                        notifyIcon1.ShowBalloonTip(10000, "G-Code Editor", popupFailMessage, ToolTipIcon.Warning);
                        blockFinalMessage = false;
                    }
                    else
                        notifyIcon1.ShowBalloonTip(10000, "G-Code Editor", popupSuccessMessage, ToolTipIcon.Info);
                }
            }
        }

        // @@@ Coloring for the above CustomButton1_Click
        private void ColoringFunction()
        {
            richTextBox1.SelectionColor = inputRTB1GCodeColor;
            richTextBox2.SelectionColor = outputRTB2GCodeColor;
        }

        // @@@ Logic Text Structuring for the above CustomButton1_Click
        private void RichTextBox2Function(string stringToChange, bool printRTB2LineWithoutEdit, bool allowG1SectionEntry, bool increaseCounterByOne)
        {
            richTextBox2.AppendText(stringToChange + Environment.NewLine);

            if (printRTB2LineWithoutEdit == false)
                printRTB2Line = false;

            if (allowG1SectionEntry == true)
                allowEntryToG1Section = true;

            if (increaseCounterByOne == true)
                linesToEditCounter++;
        }

        // @@@ Labels for the above CustomButton1_Click
        private void LabelsTextAssigning()
        {
            // Unrecognized Code
            if (unrecognizedCode == 0)
            {
                label31.Text = $"Found {unrecognizedCode} un-recognized lines.";
                label31.ForeColor = labelGreenColor;
            }
            else
            {
                label31.Text = $"Found {unrecognizedCode} un-recognized lines.";
                label31.ForeColor = labelRedColor;
            }

            // Lines Counter Print
            if (linesToEditCounter == 1)
                label3.Text = $"Found {linesToEditCounter} line to edit";
            else
                label3.Text = $"Found {linesToEditCounter} lines to edit";

            // Warning
            label6.Text = "No manual editing";
            label6.ForeColor = labelGreenColor;

            // RTB1 Lines Count
            int lines1 = richTextBox1.Lines.Count();
            label4.Text = $"Lines: {lines1 - 1}"; // 0 Based

            // RTB2 Lines Count
            int lines2 = richTextBox2.Lines.Count();
            label5.Text = $"Lines: {lines2 - 1}"; // 0 Based
            if (richTextBox1.Lines.Count() == richTextBox2.Lines.Count())
            {
                label7.Text = "Lines count match";
                label7.ForeColor = labelGreenColor;
            }
            else
            {
                label7.Text = "Lines count does not match !";
                label7.ForeColor = labelRedColor;
            }

            // File Loading Process
            if (loadingProcessInterrupted == false)
            {
                label33.Text = "Loading process is complete";
                label33.ForeColor = labelGreenColor;
            }

            // Loaded File Lines
            if (fileLinesCount == lines1 - 1)
            {
                label34.Text = $"Source file also has {fileLinesCount} lines";
                label34.ForeColor = labelGreenColor;
            }
            else
            {
                label34.Text = $"Source file has {fileLinesCount} lines, {(fileLinesCount - lines1) + 1} are missing !";
                label34.ForeColor = labelRedColor;
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ RichTextBox1 - Mouse Click - Text Highlight @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Error prevention
            if (richTextBox1.Text != "")
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Clicked Line in RTB1
                    int firstCharIndex = richTextBox1.GetFirstCharIndexOfCurrentLine();
                    int currentLineIndex = richTextBox1.GetLineFromCharIndex(firstCharIndex);
                    string currentLineText = richTextBox1.Lines[currentLineIndex];
                    richTextBox1.Select(firstCharIndex, currentLineText.Length);
                    richTextBox1.SelectionBackColor = searchedBackColor;

                    // Selected Line in RTB2
                    try
                    {
                        // Error Prevention
                        if (richTextBox2.Lines.Count() < currentLineIndex)
                            currentLineIndex = richTextBox2.Lines.Count();

                        for (int i = currentLineIndex; i >= 0; i--)
                        {
                            // Error Prevention
                            if (currentLineIndex < richTextBox2.Lines.Count())
                            {
                                // Get Text at specific Line
                                string line = richTextBox2.Lines[i];

                                if (line == currentLineText)
                                {
                                    // Highlighting the selected Line
                                    richTextBox2.Focus(); // Transfet Focus from RTB1 to RTB2
                                    richTextBox2.Select(richTextBox2.GetFirstCharIndexFromLine(i), line.Length);
                                    richTextBox2.SelectionBackColor = searchedBackColor;
                                    richTextBox2.Enabled = false; // Part A - This will disselect the selected text
                                    richTextBox2.Enabled = true;  // Part B - This will disselect the selected text
                                    break;
                                }
                            }
                            else
                            {
                                // Error Prevention
                                currentLineIndex--;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Error in RichTextBox1 Mouse Click Event " + Environment.NewLine + exception);
                    }
                }
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ RichTextBox2 - Any Keyboard Pressed - Output Code Manipulation Detection @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            // RTB1 Lines Count
            int lines1 = richTextBox1.Lines.Count() - 1; // -1 for Zero Based
            label4.Text = $"Lines: {lines1}";

            // RTB2 Lines Count
            int lines2 = richTextBox2.Lines.Count() - 1; // -1 for Zero Based
            label5.Text = $"Lines: {lines2}";

            if (richTextBox1.Lines.Count() == richTextBox2.Lines.Count())
            {
                label7.Text = "Lines count match";
                label7.ForeColor = labelGreenColor;
            }
            else
            {
                label7.Text = "Lines count does not match !";
                label7.ForeColor = labelRedColor;
            }

            label6.Text = "Manual editing detected !";
            label6.ForeColor = labelRedColor;
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Labels - Auto-Reposition @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void label6_SizeChanged(object sender, EventArgs e)
        {
            RepositionOfLabelNoManualEditing();
        }
        private void label7_SizeChanged(object sender, EventArgs e)
        {
            RepositionOfLabelLinesCountMatch();
        }
        private void label17_SizeChanged(object sender, EventArgs e)
        {
            RepositionOfLabelSavedTo();
        }
        private void label31_SizeChanged(object sender, EventArgs e)
        {
            RepositionOfLabelUnrecognizedCode();
        }
        private void label32_SizeChanged(object sender, EventArgs e)
        {
            RepositionOfLabelSavedTo();
        }
        private void label33_SizeChanged(object sender, EventArgs e)
        {
            RepositionOfLabelLoadingProcess();
        }
        private void label34_SizeChanged(object sender, EventArgs e)
        {
            RepositionOfLabelLoadedFileLines();
        }

        // Label - Successfully Saved To
        private void RepositionOfLabelSavedTo()
        {
            label32.Location = new Point(customBottomPanel1.Width - label32.Width - 8, customBottomPanel1.Height - 20);
            label17.Location = new Point(label32.Location.X - 119, customBottomPanel1.Height - 20);
            label17.Visible = (label17.Text != ". . .") ? true : false;
        }
        // Label - No Manual Editing
        private void RepositionOfLabelNoManualEditing()
        {
            label6.Location = new Point(Width - label6.Width - 10, Height - label6.Height - 140);
        }
        // Label - Lines count match
        private void RepositionOfLabelLinesCountMatch()
        {
            label7.Location = new Point(Width - label7.Width - 10, Height - label7.Height - 163);
        }
        // Label - Unrecognized Code
        private void RepositionOfLabelUnrecognizedCode()
        {
            label31.Location = new Point(Width - label31.Width - 10, Height - label31.Height - 117);
        }
        // Label - Loading Process
        private void RepositionOfLabelLoadingProcess()
        {
            label33.Location = new Point(Width - label33.Width - 10, Height - label33.Height - 94);
        }
        // Label - Loading Process
        private void RepositionOfLabelLoadedFileLines()
        {
            label34.Location = new Point(Width - label34.Width - 10, Height - label34.Height - 71);
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Program Resize - Items Repositioning @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Form Width / 2 = | Side A | Side B |

            // @@@ Side A @@@
            richTextBox1.Location = new Point(12, 54);
            richTextBox1.Size = new Size((Width / 2) - 30, Height - 271);
            label1.Location = new Point((Width / 4) - (label1.Width / 2) - 6, 36);
            label3.Location = new Point((richTextBox1.Size.Width / 2), Height - 211);
            RepositionOfLabelUnrecognizedCode();

            // @@@ Side B @@@
            richTextBox2.Location = new Point((Width / 2) + 18, 54);
            richTextBox2.Size = richTextBox1.Size;
            label2.Location = new Point(((Width / 4) * 3) - (label1.Width / 2) - 5, 36);
            label5.Location = new Point(richTextBox2.Location.X - 1, Height - 211);
            RepositionOfLabelSavedTo();
            RepositionOfLabelLinesCountMatch();
            RepositionOfLabelNoManualEditing();
            RepositionOfLabelLoadingProcess();
            RepositionOfLabelLoadedFileLines();
            customFormResizePanels1.Location = new Point(Width - 10, (Height / 2) - (customFormResizePanels1.Height / 2));
            customFormResizePanels2.Location = new Point(Width - Width + 2, (Height / 2) - (customFormResizePanels2.Height / 2));
            customFormResizePanels3.Location = new Point((Width / 2) - (customFormResizePanels3.Width / 2), Height - Height + 2);
            customMinMaxCloseButtons1.Location = new Point(Width - 111, Height - Height + 6);
            customMinMaxCloseButtons2.Location = new Point(Width - 75, Height - Height + 6);
            customMinMaxCloseButtons3.Location = new Point(Width - 39, Height - Height + 6);

            // Red Button (Delete Text)
            CustomButton3.Location = new Point((Width / 2) - (CustomButton3.Size.Width / 2) - 8, 25);

            // .Txt(A) & .Tap(B) Buttons
            CustomPartAButton1.Location = new Point(Width - CustomPartAButton1.Size.Width - CustomPartBButton1.Size.Width - 12, richTextBox2.Size.Height + richTextBox2.Location.Y + 3);
            CustomPartBButton1.Location = new Point(Width - CustomPartAButton1.Size.Width - 12, richTextBox2.Size.Height + richTextBox2.Location.Y + 3);

            // Open Folder Button
            CustomButton2.Location = new Point(Width - CustomButton2.Width - 12, Height - CustomButton2.Height - 32);

            // ProgressBar
            customProgressBar1.Location = new Point((Width / 2) - (customProgressBar1.Width / 2) - 8, richTextBox2.Location.Y + (richTextBox2.Height / 2) - (customProgressBar1.Height / 2));

            if (formLoadedFromMinimizedState == true)
            {
                // Reset
                formLoadedFromMinimizedState = false;
            }
            else
            {
                // Set Minimum Form Size
                if (Width < applicationMinimalWidth)
                {
                    Width = applicationMinimalWidth;

                    richTextBox1.SelectionStart = 0;
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectedText = $"Info: You have reached the minimal 830-Pixel application width. \n";
                }

                if (Height < applicationMinimalHeight)
                {
                    Height = applicationMinimalHeight;

                    richTextBox1.SelectionStart = 0;
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectedText = $"Info: You have reached the minimal 415-Pixel application height. \n";
                }
            }

            // Saving New Settings
            if (enableSettingSaving == true)
            {
                try
                {
                    SavingApplicationSettingsFunction("Width", $"{Width}");
                    SavingApplicationSettingsFunction("Height", $"{Height}");
                    SavingApplicationSettingsFunction("LocationX", $"{Location.X}");
                    SavingApplicationSettingsFunction("LocationY", $"{Location.Y}");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

                enableSettingSaving = false;
            }

            // Graphics Update|Refresh
            InvalidateUpdateFunction();
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ 1/6 Open File Button Events @@@ CTRL + F CustomButton1_Click
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void CustomButton1_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomButton1");
        }

        private void CustomButton1_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomButton1");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ 2/6 Open Folder or/and Select File Button Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void CustomButton2_Click(object sender, EventArgs e)
        {
            // Folder Check/Creation
            if (Directory.Exists(savingFolderPath) == false)
                Directory.CreateDirectory(savingFolderPath);

            if (label32.Text == ". . .")
            {
                try
                {
                    ProcessStartInfo ps = new ProcessStartInfo(savingFolderPath) { UseShellExecute = true, Verb = "Open" };
                    Process.Start(ps);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else // Opens Folder with Selected Last Saved File
            {
                try
                {
                    Process.Start("explorer.exe", $"/select, {label32.Text}");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void CustomButton2_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomButton2");
        }

        private void CustomButton2_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomButton2");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ 3/6 Delete Text Button Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void CustomButton3_Click(object sender, EventArgs e)
        {
            // Reset
            richTextBox1.Clear();
            richTextBox2.Clear();
            unrecognizedCode = 0;
            fileAddress = ". . .";
            label3.Text = ". . .";
            label4.Text = ". . .";
            label5.Text = ". . .";
            label6.Text = ". . .";
            label7.Text = ". . .";
            label8.Text = ". . .";
            label31.Text = ". . .";
            label33.Text = ". . .";
            label34.Text = ". . .";
            label17.Visible = false;
            label6.ForeColor = labelDefaultColor;
            label7.ForeColor = labelDefaultColor;
            label33.ForeColor = labelDefaultColor;

            AdditionalResetFunction();
        }

        private void CustomButton3_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomButton3");
        }

        private void CustomButton3_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomButton3");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ 4/6 .txt Button Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void CustomPartAButton1_Click(object sender, EventArgs e)
        {
            if (fileAddress != ". . .")
                SaveAsFunction(".txt");
            else
                MessageBox.Show($"Nothing to save.\nFile has to be loaded first.", "GCode_Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CustomPartAButton1_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomPartAButton1");

            // Added for cross Button Mouse Movements between .txt and .tap, switching colors does not work without this
            CustomPartBButton1.C3_ButtonBackColor = defaultGreen;
        }

        private void CustomPartAButton1_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomPartAButton1");

            // Added for cross Button Mouse Movements between .txt and .tap, switching colors does not work without this
            CustomPartBButton1.C3_ButtonBackColor = defaultGreen;
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ 5/6 .tap Button Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void CustomPartBButton1_Click(object sender, EventArgs e)
        {
            if (fileAddress != ". . .")
                SaveAsFunction(".tap");
            else
                MessageBox.Show($"Nothing to save.\nFile has to be loaded first.", "GCode_Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CustomPartBButton1_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomPartBButton1");

            // Added for cross Button Mouse Movements between .txt and .tap, switching colors does not work without this
            CustomPartAButton1.C3_ButtonBackColor = defaultGreen;
        }

        private void CustomPartBButton1_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomPartBButton1");

            // Added for cross Button Mouse Movements between .txt and .tap, switching colors does not work without this
            CustomPartAButton1.C3_ButtonBackColor = defaultGreen;
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ 6/6 Stop Button Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void CustomButton4_Click(object sender, EventArgs e)
        {
            // Terminating the current running File Loading Process
            stopButtonPressed = true;

            label33.Text = "Loading process was interrupted !";
            label33.ForeColor = labelRedColor;

            loadingProcessInterrupted = true;

            // Block Finishing Message
            blockFinalMessage = true;
        }

        private void CustomButton4_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomButton4");
            mouseAboveStopButton = true;
        }

        private void CustomButton4_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("CustomButton4");
            mouseAboveStopButton = true;
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Saving File Function @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void SaveAsFunction(string SaveAsFormat)
        {
            // GET current time and file name
            dateTime = DateTime.Now;
            string fileName = Path.GetFileNameWithoutExtension(fileAddress);

            // WRITE current time
            string days = $"{dateTime.Year}.{dateTime:MM}.{dateTime:dd}";
            string time = $"{dateTime:HH}.{dateTime:mm}.{dateTime:ss}";
            string savingPath = savingFolderPath + @"\" + $"{days}_{fileName}_{time}{SaveAsFormat}";

            // Folder Check/Creation
            if (Directory.Exists(savingFolderPath) == false)
            {
                Directory.CreateDirectory(savingFolderPath);
            }

            // Saving the file
            using (StreamWriter sr = new StreamWriter(savingPath))
            {
                foreach (var item in richTextBox2.Lines)
                {
                    sr.WriteLine(item);
                }
                sr.Close();

                notifyIcon1.ShowBalloonTip(10000, "G-Code Editor", popupSaveMessage, ToolTipIcon.Info);

                // Final saving message
                label32.ForeColor = labelGreenColor;
                label32.Text = $"{savingPath}";

                label17.Visible = true;
                label17.ForeColor = Color.Blue;
                label17.Text = "Successfully saved to:";
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Saving Settings Function @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void SavingApplicationSettingsFunction(string id, string value)
        {
            if (Directory.Exists(settingFilePathFolder) == false)
                Directory.CreateDirectory(settingFilePathFolder);

            if (File.Exists(settingFilePath) == false)
            {
                File.Create(settingFilePath).Close();

                // Make Default Settings
                using (StreamWriter sr = new StreamWriter(settingFilePath))
                {
                    sr.WriteLine(defaultSavingWidth);
                    sr.WriteLine(defaultSavingHeight);

                    sr.Close();
                }

                ShowSettingFilePath();
            }

            if (File.Exists(settingFilePath) == true)
            {
                string[] splitArray;

                // Reading > Splitting > Storing
                foreach (var item in File.ReadLines(settingFilePath))
                {
                    if (item != "" && item != " ")
                    {
                        if (item.Contains('='))
                        {
                            try
                            {
                                splitArray = item.Split('=');

                                // Can't have duplicite Keys
                                if (settingsListDictionary.ContainsKey(splitArray[0]) == false)
                                    settingsListDictionary.Add(splitArray[0], splitArray[1]);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                    }
                }

                // Changing the Setting Value
                settingsListDictionary[id] = value;

                // Rewriting the Setting file 
                using (StreamWriter sr = new StreamWriter(settingFilePath))
                {
                    foreach (var item in settingsListDictionary)
                    {
                        sr.WriteLine($"{item.Key}={item.Value}");
                    }

                    sr.Close();
                }

                settingsListDictionary.Clear();
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Show Setting File Path Function @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void ShowSettingFilePath()
        {
            label18.ForeColor = labelGreenColor;
            label18.Text = settingFilePath;
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Mouse Hover/Leave Function @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void EnterLeaveEventFunction(string buttonName)
        {
            if (buttonName == "CustomButton1")
            {
                CustomButton1.C3_ButtonBackColor = (CustomButton1.C3_ButtonBackColor == hoverGreen) ? defaultGreen : hoverGreen;
            }
            else if (buttonName == "CustomButton2")
            {
                CustomButton2.C3_ButtonBackColor = (CustomButton2.C3_ButtonBackColor == hoverGreen) ? defaultGreen : hoverGreen;
            }
            else if (buttonName == "CustomButton3")
            {
                CustomButton3.C3_ButtonBackColor = (CustomButton3.C3_ButtonBackColor == hoverRed) ? defaultRed : hoverRed;
            }
            else if (buttonName == "CustomButton4")
            {
                CustomButton4.C3_ButtonBackColor = (CustomButton4.C3_ButtonBackColor == hoverRed) ? defaultRed : hoverRed;
            }
            else if (buttonName == "CustomPartAButton1")
            {
                CustomPartAButton1.C3_ButtonBackColor = (CustomPartAButton1.C3_ButtonBackColor == hoverGreen) ? defaultGreen : hoverGreen;
            }
            else if (buttonName == "CustomPartBButton1")
            {
                CustomPartBButton1.C3_ButtonBackColor = (CustomPartBButton1.C3_ButtonBackColor == hoverGreen) ? defaultGreen : hoverGreen;
            }
            else if (buttonName == "customMinMaxCloseButtons1")
            {
                if (customMinMaxCloseButtons1.C9_ButtonCenterColor == defaultWhite)
                {
                    customMinMaxCloseButtons1.C9_ButtonCenterColor = defaultGreen;
                    customMinMaxCloseButtons1.C13_ButtonCenterBorderColor = defaultWhite;
                }
                else
                {
                    customMinMaxCloseButtons1.C9_ButtonCenterColor = defaultWhite;
                    customMinMaxCloseButtons1.C13_ButtonCenterBorderColor = defaultGreen;
                }
            }
            else if (buttonName == "customMinMaxCloseButtons2")
            {
                if (customMinMaxCloseButtons2.C9_ButtonCenterColor == defaultWhite)
                {
                    customMinMaxCloseButtons2.C9_ButtonCenterColor = defaultGreen;
                    customMinMaxCloseButtons2.C13_ButtonCenterBorderColor = defaultWhite;
                }
                else
                {
                    customMinMaxCloseButtons2.C9_ButtonCenterColor = defaultWhite;
                    customMinMaxCloseButtons2.C13_ButtonCenterBorderColor = defaultGreen;
                }
            }
            else if (buttonName == "customMinMaxCloseButtons3")
            {
                if (customMinMaxCloseButtons3.C9_ButtonCenterColor == defaultWhite)
                {
                    customMinMaxCloseButtons3.C9_ButtonCenterColor = defaultRed;
                    customMinMaxCloseButtons3.C13_ButtonCenterBorderColor = defaultWhite;
                }
                else
                {
                    customMinMaxCloseButtons3.C9_ButtonCenterColor = defaultWhite;
                    customMinMaxCloseButtons3.C13_ButtonCenterBorderColor = defaultRed;
                }
            }
            else if (buttonName == "customFormResizePanels1")
            {
                customFormResizePanels1.C2_BackColor = (customFormResizePanels1.C2_BackColor == hoverGreen) ? defaultGreen : hoverGreen;
                customFormResizePanels1.Invalidate();
            }
            else if (buttonName == "customFormResizePanels2")
            {
                customFormResizePanels2.C2_BackColor = (customFormResizePanels2.C2_BackColor == hoverGreen) ? defaultGreen : hoverGreen;
                customFormResizePanels2.Invalidate();
            }
            else if (buttonName == "customFormResizePanels3")
            {
                customFormResizePanels3.C2_BackColor = (customFormResizePanels3.C2_BackColor == hoverGreen) ? defaultGreen : hoverGreen;
                customFormResizePanels3.Invalidate();
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Custom Buttons Invalidate() Graphics Function @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void AdditionalResetFunction()
        {
            label17.Text = ". . .";
            label32.Text = ". . .";
            label17.ForeColor = labelDefaultColor;
            label32.ForeColor = labelDefaultColor;
            limitCounter = 0;
            counterToEnter = 0;
            linesToEditCounter = 0;
            allowEntryToG1Section = false;
            loadingProcessInterrupted = false;
            customProgressBar1.C6_Increment = 0;
            customProgressBar1.C10_columnList.Clear();
            customProgressBar1.Invalidate();
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Blocking User from changing Text while loading the file Function @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void BlockUserFromChangingTextFunction(bool blockUser)
        {
            if (blockUser == true)
            {
                richTextBox1.Enabled = false;
                richTextBox2.Enabled = false;
            }
            else
            {
                richTextBox1.Enabled = true;
                richTextBox2.Enabled = true;
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Blocking User from clicking Buttons while the file is loading Function @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void BlockUserFromClickingOnButtonsFunction(bool blockUser)
        {
            if (blockUser == true)
            {
                CustomButton1.Enabled = false;
                CustomButton2.Enabled = false;
                CustomButton3.Enabled = false;
                CustomPartAButton1.Enabled = false;
                CustomPartBButton1.Enabled = false;
            }
            else
            {
                CustomButton1.Enabled = true;
                CustomButton2.Enabled = true;
                CustomButton3.Enabled = true;
                CustomPartAButton1.Enabled = true;
                CustomPartBButton1.Enabled = true;
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Graphics Refresh @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@
        private void InvalidateUpdateFunction()
        {
            label1.Invalidate();
            label2.Invalidate();
            label3.Invalidate();
            label4.Invalidate();
            label5.Invalidate();
            label6.Invalidate();
            label7.Invalidate();
            label8.Invalidate();
            label9.Invalidate();
            label10.Invalidate();
            label12.Invalidate();
            label11.Invalidate();
            label16.Invalidate();
            label15.Invalidate();
            label14.Invalidate();
            label13.Invalidate();
            label19.Invalidate();
            label20.Invalidate();
            label21.Invalidate();
            label22.Invalidate();
            label23.Invalidate();
            label24.Invalidate();
            label25.Invalidate();
            label26.Invalidate();
            label27.Invalidate();
            label29.Invalidate();
            label28.Invalidate();
            label31.Invalidate();
            label33.Invalidate();
            label34.Invalidate();

            customProgressBar1.Invalidate();
            customBottomPanel1.Invalidate();
            customFormResizePanels1.Invalidate();
            customFormResizePanels2.Invalidate();
            customFormResizePanels3.Invalidate();

            CustomButton1.Update();
            CustomButton2.Update();
            CustomButton3.Update();
            CustomPartAButton1.Update();
            CustomPartBButton1.Update();
            customMinMaxCloseButtons1.Update();
            customMinMaxCloseButtons2.Update();
            customMinMaxCloseButtons3.Update();

            richTextBox1.Update();
            richTextBox2.Update();

            Invalidate();
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ SysTray Minimaze / Maximaze @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (notifyIconAppShowHide == false)
            {
                // Block Minimal Form Size Assignment
                formLoadedFromMinimizedState = true; // Not true at this moment but will load in Form1_Resize)

                WindowState = FormWindowState.Minimized;
                Hide();

                notifyIconAppShowHide = true;
            }
            else if (notifyIconAppShowHide == true)
            {
                Show();
                WindowState = FormWindowState.Normal;

                notifyIconAppShowHide = false;
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@  Open Saving Folder on Click @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void label18_Click(object sender, EventArgs e)
        {
            if (label18.Text != ". . .")
            {
                try
                {
                    ProcessStartInfo ps = new ProcessStartInfo(settingFilePathFolder) { UseShellExecute = true, Verb = "Open" };
                    Process.Start(ps);
                }
                catch (Exception)
                {
                    // Nothing yet..
                }
            }
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Is Mouse Down - Function @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void IsMouseDown(bool isMouseDown)
        {
            if (isMouseDown == true)
                mouseHoldingDown = true;
            else
                mouseHoldingDown = false;

            Invalidate();
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Dragging Form by Mouse - Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                clickedMousePosition = new Point(Cursor.Position.X, Cursor.Position.Y);
                oldFormPosition = Location;

                IsMouseDown(true);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                SavingApplicationSettingsFunction("LocationX", $"{Location.X}");
                SavingApplicationSettingsFunction("LocationY", $"{Location.Y}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            FormResizeOnMouseUp("MainForm");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            FormResizeOnMouseMove("MainForm");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Resizing Form from the Right Side - Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void customFormResizePanels1_MouseDown(object sender, MouseEventArgs e)
        {
            enableSettingSaving = true;
            IsMouseDown(true);
        }

        private void customFormResizePanels1_MouseUp(object sender, MouseEventArgs e)
        {
            FormResizeOnMouseUp("RightPanel");
        }

        private void customFormResizePanels1_MouseMove(object sender, MouseEventArgs e)
        {
            FormResizeOnMouseMove("RightPanel");
        }

        private void customFormResizePanels1_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customFormResizePanels1");
        }

        private void customFormResizePanels1_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customFormResizePanels1");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Resizing Form from the Left Side - Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void customFormResizePanels2_MouseDown(object sender, MouseEventArgs e)
        {
            enableSettingSaving = true;
            IsMouseDown(true);
        }

        private void customFormResizePanels2_MouseUp(object sender, MouseEventArgs e)
        {
            FormResizeOnMouseUp("LeftPanel");
        }

        private void customFormResizePanels2_MouseMove(object sender, MouseEventArgs e)
        {
            FormResizeOnMouseMove("LeftPanel");
        }

        private void customFormResizePanels2_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customFormResizePanels2");
        }

        private void customFormResizePanels2_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customFormResizePanels2");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Resizing Form from the Top Side - Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void customFormResizePanels3_MouseDown(object sender, MouseEventArgs e)
        {
            enableSettingSaving = true;
            IsMouseDown(true);
        }

        private void customFormResizePanels3_MouseUp(object sender, MouseEventArgs e)
        {
            FormResizeOnMouseUp("TopPanel");
        }

        private void customFormResizePanels3_MouseMove(object sender, MouseEventArgs e)
        {
            FormResizeOnMouseMove("TopPanel");
        }

        private void customFormResizePanels3_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customFormResizePanels3");
        }

        private void customFormResizePanels3_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customFormResizePanels3");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ MouseMove Form Resizing Function 1/2 @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void FormResizeOnMouseMove(string callerName)
        {
            int x = 0;
            int y = 0;

            if (mouseHoldingDown == true)
            {
                if (callerName == "MainForm")
                {
                    x = (Cursor.Position.X - clickedMousePosition.X) + oldFormPosition.X;
                    y = (Cursor.Position.Y - clickedMousePosition.Y) + oldFormPosition.Y;

                    Location = new Point(x, y);
                }
                else if (callerName == "TopPanel")
                {
                    x = (Width / 2) - (customFormResizePanels3.Width / 2);
                    y = Cursor.Position.Y - Location.Y;
                    customFormResizePanels3.Location = new Point(x, y);
                }
                else if (callerName == "LeftPanel")
                {
                    x = Cursor.Position.X - Location.X;
                    y = (Height / 2) - (customFormResizePanels2.Height / 2);
                    customFormResizePanels2.Location = new Point(x, y);
                }
                else if (callerName == "RightPanel")
                {
                    x = Cursor.Position.X - Location.X;
                    y = (Height / 2) - (customFormResizePanels1.Height / 2);
                    customFormResizePanels1.Location = new Point(x, y);
                }
            }

            // New Form Position 
            newFormPosition = new Point(x, y);

            // Graphical Fix
            richTextBox1.Update();
            richTextBox2.Update();
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ MouseUp Form Resizing Function 2/2 @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void FormResizeOnMouseUp(string callerName)
        {
            IsMouseDown(false);

            if (callerName == "MainForm")
            {
                // Nothing, yet...
            }
            else if (callerName == "TopPanel")
            {
                Size = new Size(Size.Width, Size.Height - newFormPosition.Y);
                Location = new Point(Location.X, Location.Y + newFormPosition.Y);
                customFormResizePanels3.Location = new Point(customFormResizePanels3.Location.X, 2);
            }
            else if (callerName == "LeftPanel")
            {
                Size = new Size(Size.Width - newFormPosition.X, Size.Height);
                Location = new Point(Location.X + newFormPosition.X, Location.Y);
                customFormResizePanels2.Location = new Point(2, customFormResizePanels2.Location.Y);
            }
            else if (callerName == "RightPanel")
            {
                Size = new Size(Cursor.Position.X - Location.X, Size.Height);
                customFormResizePanels1.Location = new Point(Width - 10, customFormResizePanels1.Location.Y);
            }

            Invalidate();
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Form Minimize Button - Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void customMinMaxCloseButtons1_Click(object sender, EventArgs e)
        {
            // Block Minimal Form Size Assignment
            formLoadedFromMinimizedState = true; // Not true at this moment but will load in Form1_Resize)

            WindowState = FormWindowState.Minimized;
        }

        private void customMinMaxCloseButtons1_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customMinMaxCloseButtons1");
        }

        private void customMinMaxCloseButtons1_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customMinMaxCloseButtons1");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Form Maximize Button - Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void customMinMaxCloseButtons2_Click(object sender, EventArgs e)
        {
            WindowState = (WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void customMinMaxCloseButtons2_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customMinMaxCloseButtons2");
        }

        private void customMinMaxCloseButtons2_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customMinMaxCloseButtons2");
        }

        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // @@@ Form Close Button - Events @@@
        // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void customMinMaxCloseButtons3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customMinMaxCloseButtons3_MouseEnter(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customMinMaxCloseButtons3");
        }

        private void customMinMaxCloseButtons3_MouseLeave(object sender, EventArgs e)
        {
            EnterLeaveEventFunction("customMinMaxCloseButtons3");
        }
    }
}

