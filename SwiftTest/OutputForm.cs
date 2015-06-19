using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ScintillaNET;

using FontFamily = System.Windows.Media.FontFamily;

namespace SwiftTest
{
    public partial class OutputForm : Form
    {
        private Client client;
        private int refreshIntervalMs = 100;

        private System.Timers.Timer t;

        private int lastCaretPos = 0;
        private int maxLineNumberCharLength;
        private int foldLevel = 2;

        public OutputForm()
        {
            InitializeComponent();

            client = new Client();

            t = new System.Timers.Timer(refreshIntervalMs);
            t.Elapsed += ClientRefresher;

            var scintilla = editor;
       
            #region editor config
            editor.StyleResetDefault();
            editor.Styles[Style.Default].Font = "Consolas";
            editor.Styles[Style.Default].Size = 10;
            editor.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            editor.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            editor.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            editor.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            editor.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            editor.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            editor.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            editor.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            editor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            editor.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            editor.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            editor.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            
            editor.Lexer = Lexer.Cpp;

            // Instruct the lexer to calculate folding
            editor.SetProperty("fold", "1");
            editor.SetProperty("fold.compact", "1");


            // Configure a margin to display folding symbols
            editor.Margins[2].Type = MarginType.Symbol;
            editor.Margins[2].Mask = Marker.MaskFolders;
            editor.Margins[2].Sensitive = true;
            editor.Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                editor.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                editor.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            editor.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            editor.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            editor.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            editor.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            editor.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            editor.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            editor.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            editor.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);



            scintilla.IndentationGuides = IndentView.LookBoth;
            scintilla.Styles[Style.BraceLight].BackColor = Color.LightGray;
            scintilla.Styles[Style.BraceLight].ForeColor = Color.BlueViolet;
            scintilla.Styles[Style.BraceBad].ForeColor = Color.Red;
            #endregion

            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (t.Enabled)
            {
                t.Enabled = false;
                client.Disconnect();
            }
            else
            {
                client.Connect();
                t.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out refreshIntervalMs);
            t.Interval = refreshIntervalMs;
        }

        private void acBtn1_Click(object sender, EventArgs e)
        {
            client.Connect();
            SetText(client.GetGame().RDump());
            client.Disconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            client.Connect();
            SetText(client.GetActiveVessel().RDump());
            client.Disconnect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.Connect();
            SetText(client.GetFlightGlobals().RDump());
            client.Disconnect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.Connect();
            SetText(client.mech.hasIt() ? "We got it" : "No joy");
            client.Disconnect();
        }

        private void ClientRefresher(Object source, ElapsedEventArgs e)
        {
            if (refreshIntervalMs == 100) refreshIntervalMs = 10000;
            int.TryParse(textBox1.Text, out refreshIntervalMs);
            t.Interval = refreshIntervalMs;

            SetText(client.ActiveVesselDump());

        }

        #region Editor methods
        private static bool IsBrace(int c)
        {
            switch (c)
            {
                case '(':
                case ')':
                case '[':
                case ']':
                case '{':
                case '}':
                case '<':
                case '>':
                    return true;
            }

            return false;
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.editor.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.editor.Text = text;

                foreach (Line line in editor.Lines)
                {
                    int foldLevel = editor.GetFoldLevel(line.Index);
                    bool isFoldLine = editor.IsFoldLine(line.Index);

                    if (foldLevel >= this.foldLevel && isFoldLine)
                    {
                        //editor.GetFoldParentLine(line.Index)
                        editor.FoldChildren(line.Index, EditorExtensions.FoldAction.CONTRACT);
                    }
                    editor.Update();
                }
            }
        }


        private void editor_TextChanged(object sender, EventArgs e)
        {

            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = editor.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            editor.Margins[0].Width = editor.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;


        }

        private void editor_UpdateUI(object sender, UpdateUIEventArgs e)
        {


            // Has the caret changed position?
            var caretPos = editor.CurrentPosition;
            if (lastCaretPos != caretPos)
            {
                lastCaretPos = caretPos;
                var bracePos1 = -1;
                var bracePos2 = -1;

                // Is there a brace to the left or right?
                if (caretPos > 0 && IsBrace(editor.GetCharAt(caretPos - 1)))
                    bracePos1 = (caretPos - 1);
                else if (IsBrace(editor.GetCharAt(caretPos)))
                    bracePos1 = caretPos;

                if (bracePos1 >= 0)
                {
                    // Find the matching brace
                    bracePos2 = editor.BraceMatch(bracePos1);
                    if (bracePos2 == Scintilla.InvalidPosition)
                    {
                        editor.BraceBadLight(bracePos1);
                        editor.HighlightGuide = 0;
                    }
                    else
                    {
                        editor.BraceHighlight(bracePos1, bracePos2);
                        editor.HighlightGuide = editor.GetColumn(bracePos1);
                    }
                }
                else
                {
                    // Turn off brace matching
                    editor.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                    editor.HighlightGuide = 0;
                }
            }

        }
        #endregion




    }
}
