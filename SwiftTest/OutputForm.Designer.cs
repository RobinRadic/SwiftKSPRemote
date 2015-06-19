namespace SwiftTest
{
    partial class OutputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.editor = new ScintillaNET.Scintilla();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.acBtn1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1329, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(1329, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "10000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // editor
            // 
            this.editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editor.IndentationGuides = ScintillaNET.IndentView.Real;
            this.editor.IndentWidth = 4;
            this.editor.Lexer = ScintillaNET.Lexer.Cpp;
            this.editor.Location = new System.Drawing.Point(-1, -1);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(1321, 954);
            this.editor.TabIndex = 4;
            this.editor.Text = "scintilla1";
            this.editor.UseTabs = false;
            this.editor.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.editor_UpdateUI);
            this.editor.TextChanged += new System.EventHandler(this.editor_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.acBtn1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1326, 93);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(146, 300);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.AutoSize = true;
            this.button6.Location = new System.Drawing.Point(3, 253);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 44);
            this.button6.TabIndex = 5;
            this.button6.Text = "Action Button 1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(3, 203);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 44);
            this.button5.TabIndex = 4;
            this.button5.Text = "Action Button 1";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(3, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "activeVessel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // acBtn1
            // 
            this.acBtn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acBtn1.AutoSize = true;
            this.acBtn1.Location = new System.Drawing.Point(3, 3);
            this.acBtn1.Name = "acBtn1";
            this.acBtn1.Size = new System.Drawing.Size(140, 44);
            this.acBtn1.TabIndex = 0;
            this.acBtn1.Text = "getGame";
            this.acBtn1.UseVisualStyleBackColor = true;
            this.acBtn1.Click += new System.EventHandler(this.acBtn1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(3, 153);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 44);
            this.button3.TabIndex = 2;
            this.button3.Text = "mech: hasIt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(3, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 44);
            this.button4.TabIndex = 3;
            this.button4.Text = "flightGlobals";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 954);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.editor);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "OutputForm";
            this.Text = "OutputForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private ScintillaNET.Scintilla editor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button acBtn1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}