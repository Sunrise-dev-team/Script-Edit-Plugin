using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if(grpNameBox.Text.Length == 0 || IDsBox.Text.Length == 0)
            {
                OKbtn.Enabled = false;
            }
            else
            {
                OKbtn.Enabled = true;
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

        private void OKbtn_Click(object sender, EventArgs e)
        {
            GroupText = "";
            for (int i = 0;i < IDsBox.LinesCount;i++)
            {
                GroupText += string.Format("  AddObject({0}, GetObject({1}) )\n", grpNameBox.Text,IDsBox.GetLineText(i));
            }
            Clipboard.SetText(GroupText);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
