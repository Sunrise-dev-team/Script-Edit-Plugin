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
    public partial class ExportSettings : Form
    {
        private string showcast = "// GVars\r\nGlobalVars (\r\n  NULL : object,\r\n\t\tVSS#i#val : object,\r\n  i : object,\r\n  obj1 : object,\r\n  obj2 : object\r\n)\r\n\r\n// Declares\r\nDeClAREsCRiPT \t\tVCheck#0#1 (  this : object )\r\nDECLARESCRIPT VTriger#0#2 (   )\r\ndeclarescript VCheck#0#4 (   )\r\nDeclareScript #OnBriefingComplete (  nPlayer : float,  szComplete : string )\r\n\r\n// Scriptblocks\r\nScript VCheck#0#1\r\n(\r\n  IF\r\n  (\r\n    IsEqual( GSGetVar( 0, \"q.gz11k.q43k\" ) , 2 ) \r\n    IsEqual( GSGetVar( 0, \"b.Trapper.T42\" ) , 2 ) \r\n  )\r\n  Then\r\n  (\r\n    KillScript(  ) \r\n    VTriger#0#2( this ) \r\n  )\r\n)\r\n\r\nScript \tVTriger#0#2\r\n(\r\n  if\t\r\n\t\t(\r\n  \r\n  )\r\n  then\r\n  (\r\n    KillScript(  ) \r\n\t\t\tGSSetVarMax( 0, \"b.Trapper.T43\", 1 ) \r\n  )\r\n)\r\n\r\nScript VCheck#0#4\r\n(\r\n  if\r\n  (\r\n    IsEqual\t\t\t( \t\tGSGetVar\t( 0, \"q.gz11k.q43k\" ) , 2 ) \r\n    IsEqual( GSGetVar( 0, \"b.Magess.Mg42\" ) , 2 \t) \r\n  )\r\n  then\r\n  (\r\n    KillScript\t\t(  ) \r\n\t\r\n\tVTriger#0#2()\r\n  )\r\n)\r\n\r\n// onbrif\r\nScript #OnBriefingComplete\r\n(\r\n  if\r\n  (\r\n    IsEqualString( szComplete, \"b.Trapper.T42\" ) \r\n  )\r\n  then\r\n  (\r\n    KillScript(  ) \r\n  )\r\n  if\r\n  (\r\n    IsEqualString( szComplete, \"b.bz8k.K42\" ) \r\n  )\r\n  then\r\n  (\r\n    kIllScrIPt(  ) \r\n    GSSETVaRmAx( 0, \"b.Shopper.Tr42\", 1 ) \r\n    GSSetVarMax( 0, \"b.Magess.Mg42\", 1 ) \r\n    GSseTvarmaX( 0, \"b.Kapitan.K42_1\", 1 ) \r\n    GSSetVarMax( 0, \"b.Huber.G42\", 1 ) \r\n    GSSetVarMax( 0, \"b.Trapper.T42\", 1 ) \r\n    GSSetVarMax( 0, \"b.Shopper.constr_3\", 1 ) \r\n  )\r\n  if\r\n  (\r\n  )\r\n  then\r\n  (\r\n    KillScript(  ) \r\n  )\r\n)\r\n\r\n// WorldScript\r\nWorldScript\r\n(\r\n // sleeping...\r\n  Sleep( 2 ) \r\n  // objects\r\n  obj1 = GetObjectByID( \"1000059188\" ) \r\n  obj2 = GetObjectByID( \"27\" )\r\n\r\n\t//scripts\r\n  VCheck#0#1( NULL ) \r\n  VCheck#0#4\t(  ) \r\n)\r\n";
        public ExportSettings()
        {
            InitializeComponent();
        }

        private void ExportSettings_Load(object sender, EventArgs e)
        {
            ExpBox.Text = showcast;
        }
    }
}
