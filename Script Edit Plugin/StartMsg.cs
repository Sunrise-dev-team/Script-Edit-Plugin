using System;
using System.Windows.Forms;

namespace Script_Edit_Plugin
{
    public partial class StartMsg : Form
    {
        public StartMsg()
        {
            InitializeComponent();
        }
#if !CLEAR
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void zonbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void standbtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
#endif
    }
}
