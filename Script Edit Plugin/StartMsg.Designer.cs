namespace Script_Edit_Plugin
{
    partial class StartMsg
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
            this.zonbtn = new System.Windows.Forms.Button();
            this.standbtn = new System.Windows.Forms.Button();
            this.StartLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // zonbtn
            // 
            this.zonbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zonbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.zonbtn.FlatAppearance.BorderSize = 0;
            this.zonbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zonbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zonbtn.Location = new System.Drawing.Point(34, 213);
            this.zonbtn.Name = "zonbtn";
            this.zonbtn.Size = new System.Drawing.Size(164, 30);
            this.zonbtn.TabIndex = 3;
            this.zonbtn.Text = "В Zone View режиме";
            this.zonbtn.UseVisualStyleBackColor = false;
            this.zonbtn.Click += new System.EventHandler(this.zonbtn_Click);
            // 
            // standbtn
            // 
            this.standbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.standbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.standbtn.FlatAppearance.BorderSize = 0;
            this.standbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.standbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.standbtn.Location = new System.Drawing.Point(237, 213);
            this.standbtn.Name = "standbtn";
            this.standbtn.Size = new System.Drawing.Size(164, 30);
            this.standbtn.TabIndex = 4;
            this.standbtn.Text = "В стандартном режиме";
            this.standbtn.UseVisualStyleBackColor = false;
            this.standbtn.Click += new System.EventHandler(this.standbtn_Click);
            // 
            // StartLabel
            // 
            this.StartLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartLabel.ForeColor = System.Drawing.Color.White;
            this.StartLabel.Location = new System.Drawing.Point(35, 36);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(357, 128);
            this.StartLabel.TabIndex = 5;
            this.StartLabel.Text = "Программа получила более одного аргумента.\r\nОткрыть только первый переданный в ст" +
    "андартном режиме, или два в режиме с компиляцией (Ctrl+[Открыть скрипт] в ZoneVi" +
    "ew)?";
            this.StartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.checkBox1.Location = new System.Drawing.Point(133, 190);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Запомнить это решение";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // StartMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(427, 247);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.standbtn);
            this.Controls.Add(this.zonbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(670, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(419, 229);
            this.Name = "StartMsg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartMsg";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion
#if !CLEAR
        private System.Windows.Forms.Button zonbtn;
        private System.Windows.Forms.Button standbtn;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.CheckBox checkBox1;
#endif
    }
}