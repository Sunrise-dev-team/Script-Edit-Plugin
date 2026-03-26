using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Script_Edit_Plugin
{
    public partial class GroupGen : Form
    {
        public string GroupText = "";
        public GroupGen()
        {
            InitializeComponent();
        }

        private void GroupGen_Load(object sender, EventArgs e)
        {
            CheckValid();
        }

        void CheckValid()
        {
            if (grpNameBox.Text.Length == 0 || IDsBox.Text.Length == 0)
            {
                Copybtn.Enabled = false;
                Copybtn.BackColor = Color.Transparent;
            }
            else
            {
                Copybtn.Enabled = true;
                Copybtn.BackColor = Color.FromArgb(128, 255, 128);
            }
        }

        private void IDsBox_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            CheckValid();
        }

        private void grpNameBox_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Copybtn_Click(object sender, EventArgs e)
        {
            GroupText = "";
#if zv1_2
            for (int i = 0; i < IDsBox.LinesCount; i++)
            {
                GroupText += string.Format("  AddObject({0}, GetObject({1}) )\n", grpNameBox.Text, IDsBox.GetLineText(i));
            }
#else
            GroupText = IDsBox.Text = Regex.Replace(IDsBox.Text, "group", grpNameBox.Text, RegexOptions.IgnoreCase);
#endif

            Clipboard.SetText(GroupText);
            //DialogResult = DialogResult.OK;
            //Close();
        }

    }
}
