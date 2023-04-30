namespace Script_Edit_Plugin
{
    partial class GroupGen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupGen));
            this.IDsBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.grpNameBox = new System.Windows.Forms.TextBox();
            this.OKbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IDsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IDsBox
            // 
            this.IDsBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.IDsBox.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.IDsBox.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.IDsBox.BackBrush = null;
            this.IDsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.IDsBox.CharHeight = 14;
            this.IDsBox.CharWidth = 8;
            this.IDsBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IDsBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.IDsBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.IDsBox.ForeColor = System.Drawing.SystemColors.Control;
            this.IDsBox.IndentBackColor = System.Drawing.Color.Transparent;
            this.IDsBox.IsReplaceMode = false;
            this.IDsBox.Location = new System.Drawing.Point(0, 0);
            this.IDsBox.Name = "IDsBox";
            this.IDsBox.Paddings = new System.Windows.Forms.Padding(0);
            this.IDsBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.IDsBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("IDsBox.ServiceColors")));
            this.IDsBox.ShowLineNumbers = false;
            this.IDsBox.Size = new System.Drawing.Size(333, 322);
            this.IDsBox.TabIndex = 0;
            this.IDsBox.Zoom = 100;
            this.IDsBox.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.IDsBox_TextChangedDelayed);
            // 
            // grpNameBox
            // 
            this.grpNameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.grpNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpNameBox.ForeColor = System.Drawing.SystemColors.Window;
            this.grpNameBox.Location = new System.Drawing.Point(3, 325);
            this.grpNameBox.Name = "grpNameBox";
            this.grpNameBox.Size = new System.Drawing.Size(328, 20);
            this.grpNameBox.TabIndex = 1;
            this.grpNameBox.TextChanged += new System.EventHandler(this.grpNameBox_TextChanged);
            // 
            // OKbtn
            // 
            this.OKbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.OKbtn.FlatAppearance.BorderSize = 0;
            this.OKbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OKbtn.Location = new System.Drawing.Point(76, 349);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(75, 30);
            this.OKbtn.TabIndex = 2;
            this.OKbtn.Text = "OK";
            this.OKbtn.UseVisualStyleBackColor = false;
            this.OKbtn.Click += new System.EventHandler(this.OKbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbtn.FlatAppearance.BorderSize = 0;
            this.Cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancelbtn.Location = new System.Drawing.Point(168, 349);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(75, 30);
            this.Cancelbtn.TabIndex = 3;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = false;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // GroupGen
            // 
            this.AcceptButton = this.OKbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.Cancelbtn;
            this.ClientSize = new System.Drawing.Size(333, 384);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.OKbtn);
            this.Controls.Add(this.grpNameBox);
            this.Controls.Add(this.IDsBox);
            this.Name = "GroupGen";
            this.Text = "GroupGen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GroupGen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IDsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox IDsBox;
        private System.Windows.Forms.TextBox grpNameBox;
        private System.Windows.Forms.Button OKbtn;
        private System.Windows.Forms.Button Cancelbtn;
    }
}