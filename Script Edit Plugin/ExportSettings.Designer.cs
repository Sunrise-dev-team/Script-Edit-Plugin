namespace Script_Edit_Plugin
{
    partial class ExportSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportSettings));
            this.OKbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.ExpBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ExpBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKbtn
            // 
            this.OKbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.OKbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbtn.FlatAppearance.BorderSize = 0;
            this.OKbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OKbtn.Location = new System.Drawing.Point(247, 73);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(91, 30);
            this.OKbtn.TabIndex = 4;
            this.OKbtn.Text = "OK";
            this.OKbtn.UseVisualStyleBackColor = false;
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cancelbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Cancelbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelbtn.FlatAppearance.BorderSize = 0;
            this.Cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancelbtn.Location = new System.Drawing.Point(126, 73);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(91, 30);
            this.Cancelbtn.TabIndex = 5;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = false;
            // 
            // ExpBox
            // 
            this.ExpBox.AutoCompleteBrackets = true;
            this.ExpBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '\"',
        '\"'};
            this.ExpBox.AutoIndentChars = false;
            this.ExpBox.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.ExpBox.AutoScrollMinSize = new System.Drawing.Size(59, 14);
            this.ExpBox.BackBrush = null;
            this.ExpBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ExpBox.CaretColor = System.Drawing.Color.DimGray;
            this.ExpBox.CharHeight = 14;
            this.ExpBox.CharWidth = 8;
            this.ExpBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ExpBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ExpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExpBox.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ExpBox.IsReplaceMode = false;
            this.ExpBox.LeftBracket = '(';
            this.ExpBox.LineNumberColor = System.Drawing.Color.Chartreuse;
            this.ExpBox.Location = new System.Drawing.Point(0, 0);
            this.ExpBox.Name = "ExpBox";
            this.ExpBox.Paddings = new System.Windows.Forms.Padding(0);
            this.ExpBox.ReservedCountOfLineNumberChars = 5;
            this.ExpBox.RightBracket = ')';
            this.ExpBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.ExpBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("ExpBox.ServiceColors")));
            this.ExpBox.ServiceLinesColor = System.Drawing.Color.Black;
            this.ExpBox.ShowCaretWhenInactive = true;
            this.ExpBox.ShowFoldingLines = true;
            this.ExpBox.ShowScrollBars = false;
            this.ExpBox.Size = new System.Drawing.Size(474, 293);
            this.ExpBox.TabIndex = 6;
            this.ExpBox.TabLength = 2;
            this.ExpBox.Zoom = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ExpBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OKbtn);
            this.splitContainer1.Panel2.Controls.Add(this.Cancelbtn);
            this.splitContainer1.Size = new System.Drawing.Size(474, 412);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 7;
            // 
            // ExportSettings
            // 
            this.AcceptButton = this.OKbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.Cancelbtn;
            this.ClientSize = new System.Drawing.Size(474, 412);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "ExportSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExportSettings";
            this.Load += new System.EventHandler(this.ExportSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExpBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKbtn;
        private System.Windows.Forms.Button Cancelbtn;
        private FastColoredTextBoxNS.FastColoredTextBox ExpBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}