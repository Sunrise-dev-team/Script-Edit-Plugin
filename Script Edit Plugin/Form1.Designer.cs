namespace Script_Edit_Plugin
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FunBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.commentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.collapseAllBracketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllBracketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllBracetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncollapseAllBracketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fixEmptyLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.createGroupFromIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dynamicHighlighingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeCombo = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FunList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.documentMap1 = new FastColoredTextBoxNS.DocumentMap();
            this.deleteCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.FunBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FunBox
            // 
            this.FunBox.AutoCompleteBrackets = true;
            this.FunBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '\"',
        '\"'};
            this.FunBox.AutoIndentChars = false;
            this.FunBox.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.FunBox.AutoScrollMinSize = new System.Drawing.Size(59, 14);
            this.FunBox.BackBrush = null;
            this.FunBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.FunBox.CaretColor = System.Drawing.Color.DimGray;
            this.FunBox.CharHeight = 14;
            this.FunBox.CharWidth = 8;
            this.FunBox.ContextMenuStrip = this.contextMenuStrip1;
            this.FunBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FunBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.FunBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.FunBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FunBox.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.FunBox.IsReplaceMode = false;
            this.FunBox.LeftBracket = '(';
            this.FunBox.LineNumberColor = System.Drawing.Color.Chartreuse;
            this.FunBox.Location = new System.Drawing.Point(0, 0);
            this.FunBox.Name = "FunBox";
            this.FunBox.Paddings = new System.Windows.Forms.Padding(0);
            this.FunBox.ReservedCountOfLineNumberChars = 5;
            this.FunBox.RightBracket = ')';
            this.FunBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.FunBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FunBox.ServiceColors")));
            this.FunBox.ServiceLinesColor = System.Drawing.Color.Black;
            this.FunBox.ShowCaretWhenInactive = true;
            this.FunBox.ShowFoldingLines = true;
            this.FunBox.ShowScrollBars = false;
            this.FunBox.Size = new System.Drawing.Size(438, 576);
            this.FunBox.TabIndex = 4;
            this.FunBox.TabLength = 2;
            this.FunBox.Zoom = 100;
            this.FunBox.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.FunBox_TextChangedDelayed);
            this.FunBox.PaintLine += new System.EventHandler<FastColoredTextBoxNS.PaintLineEventArgs>(this.FunBox_PaintLine);
            this.FunBox.Click += new System.EventHandler(this.FunBox_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commentSelectedToolStripMenuItem,
            this.toolStripSeparator5,
            this.collapseAllBracketsToolStripMenuItem,
            this.expandAllBracketsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(246, 76);
            // 
            // commentSelectedToolStripMenuItem
            // 
            this.commentSelectedToolStripMenuItem.Name = "commentSelectedToolStripMenuItem";
            this.commentSelectedToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.commentSelectedToolStripMenuItem.Text = "Comment/uncomment selected";
            this.commentSelectedToolStripMenuItem.Click += new System.EventHandler(this.commentSelectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(242, 6);
            // 
            // collapseAllBracketsToolStripMenuItem
            // 
            this.collapseAllBracketsToolStripMenuItem.Name = "collapseAllBracketsToolStripMenuItem";
            this.collapseAllBracketsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.collapseAllBracketsToolStripMenuItem.Text = "collapse all brackets";
            // 
            // expandAllBracketsToolStripMenuItem
            // 
            this.expandAllBracketsToolStripMenuItem.Name = "expandAllBracketsToolStripMenuItem";
            this.expandAllBracketsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.expandAllBracketsToolStripMenuItem.Text = "expand all brackets";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.scriptToolStripMenuItem,
            this.funcListToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Chartreuse;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Enabled = false;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.toolStripSeparator4,
            this.findToolStripMenuItem1,
            this.collapseAllBracetsToolStripMenuItem,
            this.uncollapseAllBracketsToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.Chartreuse;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(191, 6);
            // 
            // findToolStripMenuItem1
            // 
            this.findToolStripMenuItem1.Name = "findToolStripMenuItem1";
            this.findToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.findToolStripMenuItem1.Text = "Find";
            this.findToolStripMenuItem1.Click += new System.EventHandler(this.findToolStripMenuItem1_Click);
            // 
            // collapseAllBracetsToolStripMenuItem
            // 
            this.collapseAllBracetsToolStripMenuItem.Name = "collapseAllBracetsToolStripMenuItem";
            this.collapseAllBracetsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.collapseAllBracetsToolStripMenuItem.Text = "Collapse all brackets";
            this.collapseAllBracetsToolStripMenuItem.Click += new System.EventHandler(this.collapseAllBracetsToolStripMenuItem_Click);
            // 
            // uncollapseAllBracketsToolStripMenuItem
            // 
            this.uncollapseAllBracketsToolStripMenuItem.Name = "uncollapseAllBracketsToolStripMenuItem";
            this.uncollapseAllBracketsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.uncollapseAllBracketsToolStripMenuItem.Text = "Uncollapse all brackets";
            this.uncollapseAllBracketsToolStripMenuItem.Click += new System.EventHandler(this.uncollapseAllBracketsToolStripMenuItem_Click);
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validCheckToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.fixEmptyLinesToolStripMenuItem,
            this.deleteCommentsToolStripMenuItem,
            this.toolStripSeparator3,
            this.createGroupFromIDsToolStripMenuItem});
            this.scriptToolStripMenuItem.ForeColor = System.Drawing.Color.Chartreuse;
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.scriptToolStripMenuItem.Text = "Script";
            // 
            // validCheckToolStripMenuItem
            // 
            this.validCheckToolStripMenuItem.Name = "validCheckToolStripMenuItem";
            this.validCheckToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.validCheckToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.validCheckToolStripMenuItem.Text = "Valid check";
            this.validCheckToolStripMenuItem.Click += new System.EventHandler(this.validCheckToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.formatToolStripMenuItem.Text = "Format brackets";
            this.formatToolStripMenuItem.Click += new System.EventHandler(this.formatToolStripMenuItem_Click);
            // 
            // fixEmptyLinesToolStripMenuItem
            // 
            this.fixEmptyLinesToolStripMenuItem.Name = "fixEmptyLinesToolStripMenuItem";
            this.fixEmptyLinesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.fixEmptyLinesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.fixEmptyLinesToolStripMenuItem.Text = "Fix empty lines";
            this.fixEmptyLinesToolStripMenuItem.Click += new System.EventHandler(this.fixEmptyLinesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(228, 6);
            // 
            // createGroupFromIDsToolStripMenuItem
            // 
            this.createGroupFromIDsToolStripMenuItem.Name = "createGroupFromIDsToolStripMenuItem";
            this.createGroupFromIDsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.createGroupFromIDsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.createGroupFromIDsToolStripMenuItem.Text = "Create group from IDs";
            this.createGroupFromIDsToolStripMenuItem.Click += new System.EventHandler(this.createGroupFromIDsToolStripMenuItem_Click);
            // 
            // funcListToolStripMenuItem
            // 
            this.funcListToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.funcListToolStripMenuItem.ForeColor = System.Drawing.Color.Chartreuse;
            this.funcListToolStripMenuItem.Name = "funcListToolStripMenuItem";
            this.funcListToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.funcListToolStripMenuItem.Text = "Func list";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMostToolStripMenuItem,
            this.autoUpdateListToolStripMenuItem,
            this.dynamicHighlighingToolStripMenuItem,
            this.themeCombo});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Chartreuse;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.Checked = true;
            this.topMostToolStripMenuItem.CheckOnClick = true;
            this.topMostToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.topMostToolStripMenuItem.Text = "Top Most";
            this.topMostToolStripMenuItem.CheckedChanged += new System.EventHandler(this.topMostToolStripMenuItem_CheckedChanged);
            // 
            // autoUpdateListToolStripMenuItem
            // 
            this.autoUpdateListToolStripMenuItem.Checked = true;
            this.autoUpdateListToolStripMenuItem.CheckOnClick = true;
            this.autoUpdateListToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoUpdateListToolStripMenuItem.Name = "autoUpdateListToolStripMenuItem";
            this.autoUpdateListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.autoUpdateListToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.autoUpdateListToolStripMenuItem.Text = "Auto Update List";
            this.autoUpdateListToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autoUpdateListToolStripMenuItem_CheckedChanged);
            // 
            // dynamicHighlighingToolStripMenuItem
            // 
            this.dynamicHighlighingToolStripMenuItem.Checked = true;
            this.dynamicHighlighingToolStripMenuItem.CheckOnClick = true;
            this.dynamicHighlighingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dynamicHighlighingToolStripMenuItem.Name = "dynamicHighlighingToolStripMenuItem";
            this.dynamicHighlighingToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.dynamicHighlighingToolStripMenuItem.Text = "DynamicHighlighing";
            // 
            // themeCombo
            // 
            this.themeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themeCombo.Items.AddRange(new object[] {
            "Dark",
            "Light"});
            this.themeCombo.Name = "themeCombo";
            this.themeCombo.Size = new System.Drawing.Size(121, 23);
            this.themeCombo.SelectedIndexChanged += new System.EventHandler(this.themeCombo_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.FunList);
            this.splitContainer1.Panel1MinSize = 1;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 576);
            this.splitContainer1.SplitterDistance = global::Script_Edit_Plugin.Properties.Settings.Default.SplitShift;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 6;
            // 
            // FunList
            // 
            this.FunList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.FunList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FunList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunList.ForeColor = System.Drawing.SystemColors.Window;
            this.FunList.FormattingEnabled = true;
            this.FunList.Location = new System.Drawing.Point(0, 0);
            this.FunList.Name = "FunList";
            this.FunList.Size = new System.Drawing.Size(140, 576);
            this.FunList.TabIndex = 0;
            this.FunList.DoubleClick += new System.EventHandler(this.FunList_DoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.FunBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.documentMap1);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(655, 576);
            this.splitContainer2.SplitterDistance = 438;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 5;
            // 
            // documentMap1
            // 
            this.documentMap1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.documentMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentMap1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.documentMap1.Location = new System.Drawing.Point(0, 0);
            this.documentMap1.Name = "documentMap1";
            this.documentMap1.Scale = 0.27F;
            this.documentMap1.Size = new System.Drawing.Size(212, 576);
            this.documentMap1.TabIndex = 0;
            this.documentMap1.Target = this.FunBox;
            this.documentMap1.Text = "documentMap1";
            // 
            // deleteCommentsToolStripMenuItem
            // 
            this.deleteCommentsToolStripMenuItem.Name = "deleteCommentsToolStripMenuItem";
            this.deleteCommentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.deleteCommentsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.deleteCommentsToolStripMenuItem.Text = "Delete comments";
            this.deleteCommentsToolStripMenuItem.Click += new System.EventHandler(this.deleteCommentsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = global::Script_Edit_Plugin.Properties.Settings.Default.Size;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Script_Edit_Plugin.Properties.Settings.Default, "ScreenPos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::Script_Edit_Plugin.Properties.Settings.Default, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::Script_Edit_Plugin.Properties.Settings.Default.ScreenPos;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(611, 519);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EI Script extension";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FunBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox FunBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem createGroupFromIDsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox themeCombo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox FunList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private FastColoredTextBoxNS.DocumentMap documentMap1;
        private System.Windows.Forms.ToolStripMenuItem funcListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseAllBracetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncollapseAllBracketsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem collapseAllBracketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem expandAllBracketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dynamicHighlighingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fixEmptyLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCommentsToolStripMenuItem;
    }
}

