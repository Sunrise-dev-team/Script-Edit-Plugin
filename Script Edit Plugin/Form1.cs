using FastColoredTextBoxNS;
using Script_Edit_Plugin.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
/*using CustomScrollBar;*/
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Script_Edit_Plugin
{
    public partial class MainForm : Form
    {
        
        static bool isChanged = false;
        static string FunText = "";
        static string openedFile;
        static string prevDir;
        static int errlineind = -1;
        //static int[] lineindexes;
        List<int> lineindexes = new List<int>();
        //static string[] linenames;
        List<string> linenames = new List<string>();
        public AutocompleteMenu popupMenu;

        Style FunctionNameStyle = new TextStyle(Brushes.SandyBrown, null, FontStyle.Bold);
        Style VarNameStyle = new TextStyle(Brushes.Turquoise, null, FontStyle.Bold);
        static public string getSelfPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        static public void setSelfDir()
        {
            prevDir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(getSelfPath());
        }
        static public void restorePrevDir()
        {
            Directory.SetCurrentDirectory(prevDir);
        }

        public void setDescriptionFile(string descriptionFile)
        {
            setSelfDir();
            restorePrevDir();
            try
            {
                FunBox.DescriptionFile = descriptionFile;
                FunBox.Text += "";
            }
            catch
            {
                FunBox.DescriptionFile = "";
            }
            FunBox.Text += "";
            setSelfDir();
        }

        public MainForm()
        {
            InitializeComponent();
            FunBox.AcceptsTab = true;
            themeCombo.SelectedIndex = global::Script_Edit_Plugin.Properties.Settings.Default.Theme;
            topMostToolStripMenuItem.Checked = global::Script_Edit_Plugin.Properties.Settings.Default.TopMost;
            autoUpdateListToolStripMenuItem.Checked = global::Script_Edit_Plugin.Properties.Settings.Default.AutoUpdateList;
            dynamicHighlighingToolStripMenuItem.Checked = global::Script_Edit_Plugin.Properties.Settings.Default.DynamicHighlighting;


            //setDescriptionFile("ei_syntax.xml");
            setSelfDir();
            restorePrevDir();
            popupMenu = new AutocompleteMenu(FunBox)
            {
                SearchPattern = @"[a-zA-Z]",
                AllowTabKey = true,
                ToolTipDuration = 10000
            };
            BuildAutocompleteMenu();
            setSelfDir();
        }


        private string getMethodName(string refs)
        {
            int pos = refs.IndexOf('(');
            if (pos >= 0)
                return refs.Substring(0, pos);
            return refs;
        }
        private string formatReference(string refs)
        {
            string result = "";
            refs = refs.Replace("``", "\n");
            if (refs[0] == '\"' && refs[refs.Length - 1] == '\"')
                refs = refs.Substring(1, refs.Length - 2);
            int len = 0, maxLen = 70;
            for (int i = 0; i < refs.Length; i++)
            {
                len++;
                if (refs[i] == '\n')
                    len = 0;

                if (len > maxLen && (refs[i] == ' ' ||
                    (i + 2 < refs.Length && refs.Substring(i, 2) == ". ")))
                {
                    if (refs[i] == '.')
                    {
                        result += refs[i];
                        i++;
                    }
                    result += '\n';
                    len = 0;
                }
                else
                    result += refs[i];
            }
            return result;
        }
        public class ProcedureItem : AutocompleteItem
        {
            private string lowerText;
            public ProcedureItem(string text, int imageIndex = -1)
                : base(text, imageIndex)
            {
                lowerText = text.ToLower();
            }

            public override CompareResult Compare(string fragmentText)
            {
                fragmentText = fragmentText.ToLower();
                if (lowerText.StartsWith(fragmentText))
                    return CompareResult.VisibleAndSelected;
                else if ( //lowerText[0] == fragmentText[0] ||
                    (fragmentText.Length >= 3 && lowerText.IndexOf(fragmentText) >= 0))
                {
                    return CompareResult.Visible;
                }
                return CompareResult.Hidden;
            }
        }
        private void BuildAutocompleteMenu()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            string[] keywords = { "GlobalVars", "DeclareScript", "Script", "WorldScript", "object", "float", "string", "group", "if", "then" };
            foreach (var item in keywords)
                items.Add(new AutocompleteItem(item) { });

            try
            {
                setSelfDir();
                string dir = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(getSelfPath());
                StreamReader reader = new StreamReader("script_refs.txt", Encoding.GetEncoding("windows-1251"));
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split('\t');
                    var Name = getMethodName(line[0]);
                    
                    if (Name != "KillScript" && Name != "FixItems" && Name != "GetLeader" && Name != "GetWorldTime" && Name != "IsCameraPlaying" && Name != "IsNight" && Name != "QFinish" && Name != "RecalcMercBriefings" && Name != "WaitEndAnimation")
                        items.Add(new ProcedureItem(Name + "(")
                        {
                            ToolTipTitle = line[0],
                            ToolTipText = formatReference(line[1]),
                        });
                    else
                        items.Add(new ProcedureItem(Name + "()")
                        {
                            ToolTipTitle = line[0],
                            ToolTipText = formatReference(line[1]),
                        });
                }
                restorePrevDir();
            }
            catch
            {
                string[] standardProcedures = { "ActivateTrap", "Add", "AddLoot", "AddMob", "AddObject", "AddRectToArea", "AddRoundToArea", "AddUnitToParty", "AddUnitToServer", "AddUnitUnderControl", "AlarmPosX", "AlarmPosY", "AlarmTime", "Any", "AttachParticles", "AttachParticleSource", "Attack", "BlockUnit", "Cast", "CastSpellPoint", "CastSpellUnit", "ConsoleFloat", "ConsoleString", "CopyItems", "CopyLoot", "CopyStats", "Crawl", "CreateFX", "CreateFXSource", "CreateLightning", "CreateParticleSource", "CreateParty", "CreatePointLight", "CreateRandomizeFXSource", "DeleteArea", "DeleteFXSource", "DeleteLightning", "DeleteParticleSource", "DeletePointLight", "DistanceUnitPoint", "DistanceUnitUnit", "Div", "EnableLever", "EraseQuestItem", "Every", "FixItems", "FixWorldTime", "Follow", "For", "ForIf", "GetAIClass", "GetBSZValue", "GetDiplomacy", "GetFutureX", "GetFutureY", "GetLeader", "GetLeverState", "GetLootItemsCount", "GetMercsNumber", "GetMoney", "GetObject", "GetObjectByID", "GetObjectByName", "GetObjectID", "GetPlayer", "GetPlayerUnits", "GetUnitOfPlayer", "GetWorldTime", "GetX", "GetY", "GetZ", "GetZValue", "GiveDexterity", "GiveIntelligence", "GiveItem", "GiveMoney", "GiveQuestItem", "GiveSkill", "GiveStrength", "GiveUnitQuestItem", "GiveUnitSpell", "GodMode", "GroupAdd", "GroupCross", "GroupHas", "GroupSee", "GroupSize", "GroupSub", "GSDelVar", "GSGetVar", "GSSetVar", "GSSetVarMax", "Guard", "HaveItem", "HideObject", "HP", "Idle", "InflictDamage", "InvokeAlarm", "IsAlarm", "IsAlive", "IsCameraPlaying", "IsDead", "IsEnemy", "IsEqual", "IsEqualString", "IsGreater", "IsInArea", "IsInSquare", "IsLess", "IsNight", "IsPlayerInDanger", "IsPlayerInSafety", "IsUnitBlocked", "IsUnitInWater", "IsUnitVisible", "KillScript", "KillUnit", "LeaveToZone", "Lie", "Mana", "MaxHP", "MaxMana", "MoveParticleSource", "MovePointLight", "MoveToObject", "MoveToPoint", "Mul", "Not", "PlayAnimation", "PlayCamera", "PlayerSee", "PlayFX", "PlayMovie", "QFinish", "QObjArea", "QObjGetItem", "QObjKillGroup", "QObjKillUnit", "QObjSeeObject", "QObjSeeUnit", "QObjUse", "QStart", "QuestComplete", "Random", "RecalcMercBriefings", "RedeployParty", "RemoveObject", "RemoveObjectFromServer", "RemoveParty", "RemoveQuestItem", "RemoveUnitFromControl", "RemoveUnitFromParty", "RemoveUnitFromServer", "ResetTarget", "Rest", "RotateTo", "Run", "RunWorldTime", "SendEvent", "SendStringEvent", "Sentry", "SetCameraOrientation", "SetCameraPosition", "SetCP", "SetCPFast", "SetCurrentParty", "SetDiplomacy", "SetDirectionToObject", "SetEnemy", "SetParticleSourceSize", "SetPlayer", "SetPlayerAggression", "SetScience", "SetSpellAggression", "SetSunLight", "SetWaterLevel", "SetWind", "ShowBitmap", "ShowCredits", "Sleep", "SleepUntil", "SleepUntilIdle", "Stand", "StartAnimation", "Sub", "SwitchLeverState", "SwitchLeverStateEx", "UMAg", "UMAggression", "UMClear", "UMCorpseWatcher", "UMFear", "UMFollow", "UMGuard", "UMGuardEx", "UMPatrol", "UMPatrolAddPoint", "UMPatrolAddPointLook", "UMPatrolClear", "UMPlayer", "UMRevenge", "UMSentry", "Walk", "CreateRandomizedFXSource", "PlayMusic", "SetBackGroundColor", "UMStandard", "UMSuspection", "UnitInSquare", "UnitSee", "WaitEndAnimation", "WaitSegment", "WasLooted" };
                foreach (var item in standardProcedures)
                    items.Add(new ProcedureItem(item) { });
            }
            items.Add(new ProcedureItem("DeclareScript myscript()\r\nScript myscript\r\n(\r\n  if\r\n  (\r\n  )\r\n  then\r\n  (\r\n    KillScript()\r\n    \r\n  )\r\n)") { });
            popupMenu.Items.SetAutocompleteItems(items);
        }

        private void checkSyntax(string content)
        {
            setSelfDir();
            string output;

            try
            {
                StreamWriter file = new StreamWriter("script.txt");
                file.Write("GlobalVars(Heroes:group)");
                file.Write(content);
                file.Close();

                Process proc = new Process();
                // Redirect the output stream of the child process.
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.FileName = "eisc_con.exe";
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                output = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
            }
            catch (Exception e)
            {
                try { File.Delete("script.txt"); }
                catch { }

                restorePrevDir();
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                try { File.Delete("script.txt"); }
                catch { }

                return;
            }

            try { File.Delete("script.txt"); }
            catch { }

            int line;
            Color color = FunBox.CurrentLineColor;
            try
            {
                if (output.Substring(0, 5) == "Line ")
                {
                    string line_str = output.Substring(5, output.IndexOf(':') - 5);
                    line = Int32.Parse(line_str);
                    if (line > 0)
                    {
                        FunBox[line - 1].LastVisit = DateTime.Now;
                        FunBox.Navigate(line - 1);
                        color = FunBox.CurrentLineColor;
                        FunBox.CurrentLineColor = Color.Red;
                        errlineind = line - 1;
                    }
                    else
                        output = "No errors were found";
                        errlineind = -1;
                }
            }
            catch { }


            toMes(output);
            FunBox.CurrentLineColor = color;
            restorePrevDir();
        }
        public static void toErr(string msg)
        {
            var rez = MessageBox.Show(msg + "\nProgram have potential errors! Abort?", "Warning!", MessageBoxButtons.YesNo);
            if (rez == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public static void toMes(string msg)
        {
            MessageBox.Show(msg, "Message!", MessageBoxButtons.OK);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string filePath = args[1];
                string filename = filePath;
                LoadFile(filePath);
            }
        }

        void LoadFile(string path)
        {
            if (File.Exists(path))
            {
                FunText = File.ReadAllText(path);
                FunBox.Text = FunText;
                openedFile = path;
                ParseList(FunBox);
                isChanged = false;
            }
            else
            {
                toErr(string.Format("File \"{0}\" not found!", path));
            }
        }

        private void openPrj()
        {
            if (isChanged)
            {
                var rez = MessageBox.Show("You have unsaved changes! Save?", "Warning!", MessageBoxButtons.YesNoCancel);
                if (rez == DialogResult.Yes)
                {
                    // TODO: Save here
                    savePrj(openedFile);
                    isChanged = false;
                }
                if (rez == DialogResult.Cancel) { return; }
            }
            OpenFileDialog OpenDialog1 = new OpenFileDialog
            {
                Filter = "EI script files (*.eis)|*.eis|Normal text files (*.txt)|*.txt|other files (*.*)|*.*"
            };
            DialogResult result = OpenDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = OpenDialog1.FileName;
                openedFile = filename;
                LoadFile(filename);
            }
        }
        private void savePrj(string path)
        {
            if (File.Exists(path))
            {
            var rez = MessageBox.Show("Do you really want to overwrite file?", "Warning!", MessageBoxButtons.YesNo);
            if (rez == DialogResult.No) { return; }
            }
            File.WriteAllText(path, FunBox.Text);
            FunText = FunBox.Text;
            isChanged = false;
        }

        void ParseList(FastColoredTextBox box)
        {
            string line = "";
            var lines = box.Lines;
            int nextlineIndex = 0;
            //bool isValid = true;
            linenames.Clear();
            lineindexes.Clear();
            while (nextlineIndex < box.LinesCount)
            {
                line = lines[nextlineIndex];
                if (line.ToLower().Contains("script "))
                {
                    lineindexes.Add(nextlineIndex);
                    linenames.Add( line.Replace("Script "," ") );
                }
                else if (line.ToLower().Contains("worldscript"))
                {
                    lineindexes.Add(nextlineIndex);
                    linenames.Add(line/*.Replace("Script ", " ")*/);
                }
                else if (line.ToLower().Contains("globalars"))
                {
                    lineindexes.Add(nextlineIndex);
                    linenames.Add(line/*.Replace("Script ", " ")*/);
                }
                nextlineIndex++;
            }
            //FunList.
            updateList();

            /*
            string line = "";
            bool flagStruct = false, flagUnused = false;

            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("extern uint8 ") || line.Contains("extern sint8 "))
                {
                    writer.WriteLine("#define START_SECTION_OEM_volatile_FastRam_8bit");
                    writer.WriteLine("#include \"swsh_uaes2oem.h\"");
                }
                writer.WriteLine(line);

            }*/
        }

        private void updateList()
        {
            var sel = FunList.SelectedIndex;
            FunList.Items.Clear();
            //var FunArrTmp = Directory.GetFiles(prj.PrjPath + prj.PrjFunPath);
            /*if (FunArrTmp.Length % 2 != 0)
            {
                toErr(string.Format("Incorrect files count in \"{0}\". Some functions may be damaged!", prj.PrjPath + prj.PrjFunPath));
            }*/
            for (int i = 0; i < linenames.Count; i++)
            {
                
                    FunList.Items.Add(linenames[i].ToString());
                
            }
            if (sel < FunList.Items.Count)
                FunList.SelectedIndex = sel;
            else
                FunList.SelectedIndex = FunList.Items.Count - 1;
            //nowSelect = 0;
            //nowText = FunList.Text;
        }

        private void SetTheme(int numTheme)
        {
            /*if (File.Exists(path))
            {
                var rez = MessageBox.Show("Do you really want to overwrite \"Global Vars\" and \"World Script\" files?", "Warning!", MessageBoxButtons.YesNo);
                if (rez == DialogResult.No) { return; }
            }
            File.WriteAllText(path, FunBox.Text);
            FunText = FunBox.Text;
            isChanged = false;*/
            switch(numTheme){
                case 0:
                    FunBox.ForeColor = SystemColors.ActiveCaption;
                    FunBox.BackColor = Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
                    FunBox.DisabledColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
                    FunBox.IndentBackColor = Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
                    FunBox.LineNumberColor = Color.Chartreuse;
                    FunBox.SelectionColor = Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
                    //FunBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FunBox.ServiceColors")));
                    FunBox.ServiceLinesColor = Color.Black;
                    FunList.BackColor = Color.FromArgb(56, 56, 56);
                    FunList.ForeColor = Color.Chartreuse;
                    menuStrip1.BackColor = Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
                    fileToolStripMenuItem.ForeColor = Color.Chartreuse;
                    editToolStripMenuItem.ForeColor = Color.Chartreuse;
                    scriptToolStripMenuItem.ForeColor = Color.Chartreuse;
                    settingsToolStripMenuItem.ForeColor = Color.Chartreuse;
                    funcListToolStripMenuItem.ForeColor = Color.Chartreuse;
                    splitContainer1.BackColor = Color.FromArgb(64, 64, 64);
                    documentMap1.BackColor = Color.FromArgb(64, 64, 64);
                    FunctionNameStyle = new TextStyle(Brushes.SandyBrown, null, FontStyle.Bold);
                    VarNameStyle = new TextStyle(Brushes.Turquoise, null, FontStyle.Bold);
                    setDescriptionFile("ei_syntax_dark.xml");
                    break;
                case 1:
                    FunBox.ForeColor = Color.Black;
                    FunBox.BackColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                    FunBox.DisabledColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
                    FunBox.IndentBackColor = Color.Gainsboro;
                    FunBox.LineNumberColor = Color.ForestGreen;
                    FunBox.SelectionColor = Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
                    //FunBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FunBox.ServiceColors")));
                    FunBox.ServiceLinesColor = Color.Silver;
                    FunList.BackColor = Color.White;
                    FunList.ForeColor = Color.Black;
                    menuStrip1.BackColor = Color.Gainsboro;
                    fileToolStripMenuItem.ForeColor = Color.Black;
                    editToolStripMenuItem.ForeColor = Color.Black;
                    scriptToolStripMenuItem.ForeColor = Color.Black;
                    settingsToolStripMenuItem.ForeColor = Color.Black;
                    funcListToolStripMenuItem.ForeColor = Color.Black;
                    splitContainer1.BackColor = Color.Gainsboro;
                    documentMap1.BackColor = Color.Gainsboro;
                    FunctionNameStyle = new TextStyle(Brushes.Chocolate, null, FontStyle.Bold);
                    VarNameStyle = new TextStyle(Brushes.Navy, null, FontStyle.Bold);
                    setDescriptionFile("ei_syntax_light.xml");
                    break;
            };
        }

        /// <summary>
        /// Format all script text in target FastColoredTextBox.
        /// </summary>
        private void FormattingScript(FastColoredTextBox box)
        {
            /*foreach (Range found in box.GetRanges(@"\b(?<range>\w+)\s*:\s*(object|float|group|string)\b"))
            {
                box.Range.SetStyle(VarNameStyle, @"\b" + found.Text + @"\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            }*/
            var tmp = box.Text;
            //tmp = Regex.Replace(tmp, @"if.\s*\(.\s*\).\s*","if()");
            tmp = Regex.Replace(tmp, @"\b[Tt][Hh][Ee][Nn]\b\r\n\s*\(", "then("); // then\n( -> then(
            tmp = Regex.Replace(tmp, @"\b[Ii][Ff]\b\r\n\s*\(", "if("); // if\n( -> if(
            tmp = Regex.Replace(tmp, @"\(\s*\)", "()"); // (   ) -> ()
            tmp = Regex.Replace(tmp, @"\b[Dd][Ee][Cc][Ll][Aa][Rr][Ee][Ss][Cc][Rr][Ii][Pp][Tt]\b", "DeclareScript");
            tmp = Regex.Replace(tmp, @"\b[Ss][Cc][Rr][Ii][Pp][Tt]\b", "Script");
            tmp = Regex.Replace(tmp, @"\b[Gg][Ll][Oo][Bb][Aa][Ll][Vv][Aa][Rr][Ss]\b", "GlobalVars");
            tmp = Regex.Replace(tmp, @"\b[Ww][Oo][Rr][Ll][Dd][Ss][Cc][Rr][Ii][Pp][Tt]\b", "WorldScript");
            tmp = Regex.Replace(tmp, @" +\)\r\n", ")\r\n");
            
            tmp = Regex.Replace(tmp, @"\r\n[ ]*\)[ ]*\r\n", "\r\n\t)\r\n");
            tmp = Regex.Replace(tmp, @"\r\n[ ]*\b[Ii][Ff]\b", "\r\n\tif");
            tmp = Regex.Replace(tmp, @"\r\n[ ]*\b[Tt][Hh][Ee][Nn]\b", "\r\n\tthen");
            tmp = Regex.Replace(tmp, @"\r\n[ ]+", "\r\n\t\t");

            //tmp = Regex.Replace(tmp, "^[ ]+\b", "  "); // "     " -> " "
            box.Text = tmp;//Regex.Replace(tmp, @"if.\s*\(.\s*?<range>.\s*\).\s*", @"(<range>)");
            FormattingFormatStrings(box);
/*
            string line = "";
            var lines = box.Lines;
            int nextlineIndex = 0;
            while (nextlineIndex < box.LinesCount)
            {
                line = lines[nextlineIndex];

                if (line.ToLower().Contains(")"))
                {
                    var isnorm = true;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (!char.IsWhiteSpace(line[i]) && line[i] != ')')
                        {
                            isnorm = false;
                            break;
                        }
                    }
                    if (isnorm)
                    {
                        line = "    )";
                        lines[nextlineIndex] = line;
                    }
                    
                }
                nextlineIndex++;
            }
            var outs = "";
            for (int i = 0; i < lines.Count; i++)
            {
                outs = outs + lines[i];
            }
            box.Text = outs;
            //box.*/
        }

        /// <summary>
        /// Format all spaces in target FastColoredTextBox. 
        /// </summary>
        private void FormattingScriptSpaces(FastColoredTextBox box)
        {
            var tmp = box.Text;
            tmp = Regex.Replace(tmp, @"^\s*\r?\n|\r?\n(?!\s*\S)", "", RegexOptions.Multiline);
            //tmp = Regex.Replace(tmp, @"\b[Ss][Cc][Rr][Ii][Pp][Tt]\b", "\nScript");
            //tmp = Regex.Replace(tmp, @"\b[Ww][Oo][Rr][Ll][Dd][Ss][Cc][Rr][Ii][Pp][Tt]\b", "\nWorldScript");
            box.Text = tmp;
        }
        
        /// <summary>
         /// Format all spaces in target FastColoredTextBox. 
         /// </summary>
        private void FormattingScriptComments(FastColoredTextBox box)
        {
            var tmp = box.Text;
            tmp = Regex.Replace(tmp, @"(?s)\s*\/\/.+?\n|\/\*.*?\*\/\s*", "\r\n");
            box.Text = tmp;
        }

        private void FormattingFormatStrings(FastColoredTextBox box)
        {
            var unformattedstrings = new List<string>();
            var formattedstrings = new List<string>();
            try
            {
                setSelfDir();
                string dir = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(getSelfPath());
                StreamReader reader = new StreamReader("script_refs.txt", Encoding.GetEncoding("windows-1251"));
                var count = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split('\t');
                    var Name = getMethodName(line[0]);
                    unformattedstrings.Add(Name);
                    formattedstrings.Add(FormattingBuildFormattedString(Name));
                    count++;
                }
                for (int i = 0; i < formattedstrings.Count; i++)
                {
                    var tmp = box.Text;
                    tmp = Regex.Replace(tmp, @formattedstrings[i], unformattedstrings[i], RegexOptions.Multiline);
                    box.Text = tmp;
                }
                restorePrevDir();
            }
            catch
            {
                var unformattedstrings2 = new List<string>();
                var formattedstrings2 = new List<string>();
                string[] standardProcedures = { "ActivateTrap", "Add", "AddLoot", "AddMob", "AddObject", "AddRectToArea", "AddRoundToArea", "AddUnitToParty", "AddUnitToServer", "AddUnitUnderControl", "AlarmPosX", "AlarmPosY", "AlarmTime", "Any", "AttachParticles", "AttachParticleSource", "Attack", "BlockUnit", "Cast", "CastSpellPoint", "CastSpellUnit", "ConsoleFloat", "ConsoleString", "CopyItems", "CopyLoot", "CopyStats", "Crawl", "CreateFX", "CreateFXSource", "CreateLightning", "CreateParticleSource", "CreateParty", "CreatePointLight", "CreateRandomizeFXSource", "DeleteArea", "DeleteFXSource", "DeleteLightning", "DeleteParticleSource", "DeletePointLight", "DistanceUnitPoint", "DistanceUnitUnit", "Div", "EnableLever", "EraseQuestItem", "Every", "FixItems", "FixWorldTime", "Follow", "For", "ForIf", "GetAIClass", "GetBSZValue", "GetDiplomacy", "GetFutureX", "GetFutureY", "GetLeader", "GetLeverState", "GetLootItemsCount", "GetMercsNumber", "GetMoney", "GetObject", "GetObjectByID", "GetObjectByName", "GetObjectID", "GetPlayer", "GetPlayerUnits", "GetUnitOfPlayer", "GetWorldTime", "GetX", "GetY", "GetZ", "GetZValue", "GiveDexterity", "GiveIntelligence", "GiveItem", "GiveMoney", "GiveQuestItem", "GiveSkill", "GiveStrength", "GiveUnitQuestItem", "GiveUnitSpell", "GodMode", "GroupAdd", "GroupCross", "GroupHas", "GroupSee", "GroupSize", "GroupSub", "GSDelVar", "GSGetVar", "GSSetVar", "GSSetVarMax", "Guard", "HaveItem", "HideObject", "HP", "Idle", "InflictDamage", "InvokeAlarm", "IsAlarm", "IsAlive", "IsCameraPlaying", "IsDead", "IsEnemy", "IsEqual", "IsEqualString", "IsGreater", "IsInArea", "IsInSquare", "IsLess", "IsNight", "IsPlayerInDanger", "IsPlayerInSafety", "IsUnitBlocked", "IsUnitInWater", "IsUnitVisible", "KillScript", "KillUnit", "LeaveToZone", "Lie", "Mana", "MaxHP", "MaxMana", "MoveParticleSource", "MovePointLight", "MoveToObject", "MoveToPoint", "Mul", "Not", "PlayAnimation", "PlayCamera", "PlayerSee", "PlayFX", "PlayMovie", "QFinish", "QObjArea", "QObjGetItem", "QObjKillGroup", "QObjKillUnit", "QObjSeeObject", "QObjSeeUnit", "QObjUse", "QStart", "QuestComplete", "Random", "RecalcMercBriefings", "RedeployParty", "RemoveObject", "RemoveObjectFromServer", "RemoveParty", "RemoveQuestItem", "RemoveUnitFromControl", "RemoveUnitFromParty", "RemoveUnitFromServer", "ResetTarget", "Rest", "RotateTo", "Run", "RunWorldTime", "SendEvent", "SendStringEvent", "Sentry", "SetCameraOrientation", "SetCameraPosition", "SetCP", "SetCPFast", "SetCurrentParty", "SetDiplomacy", "SetDirectionToObject", "SetEnemy", "SetParticleSourceSize", "SetPlayer", "SetPlayerAggression", "SetScience", "SetSpellAggression", "SetSunLight", "SetWaterLevel", "SetWind", "ShowBitmap", "ShowCredits", "Sleep", "SleepUntil", "SleepUntilIdle", "Stand", "StartAnimation", "Sub", "SwitchLeverState", "SwitchLeverStateEx", "UMAg", "UMAggression", "UMClear", "UMCorpseWatcher", "UMFear", "UMFollow", "UMGuard", "UMGuardEx", "UMPatrol", "UMPatrolAddPoint", "UMPatrolAddPointLook", "UMPatrolClear", "UMPlayer", "UMRevenge", "UMSentry", "Walk", "CreateRandomizedFXSource", "PlayMusic", "SetBackGroundColor", "UMStandard", "UMSuspection", "UnitInSquare", "UnitSee", "WaitEndAnimation", "WaitSegment", "WasLooted" };
                /*var count = 0;
                unformattedstrings.Clear();
                formattedstrings.Clear();
                foreach (var item in standardProcedures)
                {
                    var Name = item;
                    unformattedstrings[count] = Name;
                    formattedstrings[count] = FormattingBuildFormattedString(Name);

                    count++;
                }*/
                //unformattedstrings.Clear();
                //formattedstrings.Clear();
                for (int i = 0; i < standardProcedures.Length; i++)
                {
                    var Name = standardProcedures[i];
                    unformattedstrings2.Add(Name);
                    formattedstrings2.Add(FormattingBuildFormattedString(Name));

                    //count++;
                }
                for (int i = 0; i < formattedstrings2.Count; i++)
                {
                    var tmp = box.Text;
                    tmp = Regex.Replace(tmp, @formattedstrings2[i], unformattedstrings2[i], RegexOptions.Multiline);
                    box.Text = tmp;
                }

            }
        }
        private string FormattingBuildFormattedString(string funName)
        {
            if (string.IsNullOrEmpty(funName))
                return "";
            var tmp = @"";
            tmp += @"\b";
            for (int i = 0; i<funName.Length; i++)
            {
                tmp += @"[";
                tmp += @funName[i].ToString().ToUpper();
                tmp += @funName[i].ToString().ToLower();
                tmp += @"]";
            }
            tmp += @"\b";
            return tmp;
        }

            private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openPrj();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePrj(openedFile);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            global::Script_Edit_Plugin.Properties.Settings.Default.Theme = themeCombo.SelectedIndex;
            global::Script_Edit_Plugin.Properties.Settings.Default.TopMost = topMostToolStripMenuItem.Checked;
            global::Script_Edit_Plugin.Properties.Settings.Default.AutoUpdateList = autoUpdateListToolStripMenuItem.Checked;
            global::Script_Edit_Plugin.Properties.Settings.Default.DynamicHighlighting = dynamicHighlighingToolStripMenuItem.Checked;

            global::Script_Edit_Plugin.Properties.Settings.Default.SplitShift = splitContainer1.SplitterDistance;
            global::Script_Edit_Plugin.Properties.Settings.Default.SplitShift2 = splitContainer2.SplitterDistance;
            Properties.Settings.Default.Save();
        }

        private void validCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkSyntax(FunBox.Text);
        }

        private void createGroupFromIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupGen dialog = new GroupGen();
            dialog.ShowDialog();
            /*if(dialog.DialogResult == DialogResult.OK)
            {
                Clipboard.SetText()
                dialog.GroupText 
            }*/
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunBox.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunBox.Cut();
        }

        private void themeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTheme(themeCombo.SelectedIndex);
        }

        private void topMostToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = topMostToolStripMenuItem.Checked;
        }

        private void FunBox_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            if (FunText != FunBox.Text )
            {
                if (autoUpdateListToolStripMenuItem.Checked == true)
                    ParseList(FunBox);

                isChanged = true;
            }



            FunBox.Range.ClearStyle(FunctionNameStyle);
            FunBox.Range.ClearStyle(VarNameStyle);

            if (dynamicHighlighingToolStripMenuItem.Checked == true)
            {
                foreach (Range found in FunBox.GetRanges(@"\b(?<range>\w+)\s*:\s*(object|float|group|string)\b"))
                {
                    FunBox.Range.SetStyle(VarNameStyle, @"\b" + found.Text + @"\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                }

                foreach (Range found in FunBox.GetRanges(@"\b(DeclareScript|declarescript)\s+(?<range>\w+)\b"))
                    FunBox.Range.SetStyle(FunctionNameStyle, @"\b" + found.Text + @"\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                foreach (Range found in FunBox.GetRanges(@"\b(DeclareScript|declarescript)\s+\W(?<range>\w+)\b"))
                {
                    FunBox.Range.SetStyle(FunctionNameStyle, @"\b" + found.Text + @"\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    FunBox.Range.SetStyle(FunctionNameStyle, @"#", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }
            }
            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();
            //set markers for folding
            e.ChangedRange.SetFoldingMarkers(@"\(", @"\)");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                var rez = MessageBox.Show("You have unsaved changes! Save?", "Warning!", MessageBoxButtons.YesNoCancel);
                if (rez == DialogResult.Yes)
                {
                    // TODO: Save here
                    savePrj(openedFile);
                    isChanged = false;
                }
                if (rez == DialogResult.Cancel) { e.Cancel = true; return; }
            }
            e.Cancel = false;
        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FunBox.ShowFindDialog();
        }

        private void FunBox_Click(object sender, EventArgs e)
        {
            //FunBox.Navigate(line - 1);
            //FunBox.pos
            //var pos = FunBox.PlaceToPosition();
        }

        private void FunList_DoubleClick(object sender, EventArgs e)
        {
            FunBox.Navigate(lineindexes[FunList.SelectedIndex]);

            //draw current line marker
            //if (e.LineIndex == fctb.Selection.Start.iLine)
            //    using (var brush = new LinearGradientBrush(new Rectangle(0, e.LineRect.Top, 15, 15), Color.LightPink, Color.Red, 45))
             //       e.Graphics.FillEllipse(brush, 0, e.LineRect.Top, 15, 15);
            //FunBox.Selection = FunBox.Selection+4;
            //FunBox.Selection = new Range(FunBox.Selection.FromLine);

        }

        private void scrollBarEx1_Scroll(object sender, ScrollEventArgs e)
        {
            /*if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                FunBox.HorizontalScroll.Value = e.NewValue;
            }
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if(e.NewValue > e.OldValue)
                    FunList.HorizontalScrollbar = FunBox.VerticalScroll.Value+50;
                if (e.NewValue < e.OldValue)
                    FunBox.VerticalScroll.Value = FunBox.VerticalScroll.Value-50;
            }*/
        }

        private void scrollBarEx2_Scroll(object sender, ScrollEventArgs e)
        {
            /*if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                if (e.NewValue > e.OldValue)
                    FunBox.HorizontalScroll.Value = e.NewValue*10;
                if (e.NewValue < e.OldValue)
                    FunBox.H = e.NewValue*10;
            }*/
        }

        private void FunBox_PaintLine(object sender, PaintLineEventArgs e)
        {
            //draw current line marker
            if (e.LineIndex == FunBox.Selection.Start.iLine)
            {
                if (themeCombo.SelectedIndex == 0)
                {
                    using (var brush = new LinearGradientBrush(new Rectangle(0, e.LineRect.Top, 15, 15), Color.DarkOrange, Color.DarkOrange, 45))
                        e.Graphics.FillEllipse(brush, 0, e.LineRect.Top, 15, 15);
                }
                if (themeCombo.SelectedIndex == 1)
                {
                    using (var brush = new LinearGradientBrush(new Rectangle(0, e.LineRect.Top, 15, 15), Color.Orange, Color.DarkOrange, 45))
                        e.Graphics.FillEllipse(brush, 0, e.LineRect.Top, 15, 15);
                }
            }
            if (e.LineIndex == errlineind && errlineind != -1)
            {
                if (themeCombo.SelectedIndex == 0)
                {
                    using (var brush = new LinearGradientBrush(new Rectangle(0, e.LineRect.Top, 15, 15), Color.Red, Color.Red, 45))
                        e.Graphics.FillEllipse(brush, 0, e.LineRect.Top, 15, 15);
                }
                if (themeCombo.SelectedIndex == 1)
                {
                    using (var brush = new LinearGradientBrush(new Rectangle(0, e.LineRect.Top, 15, 15), Color.LightPink, Color.Red, 45))
                        e.Graphics.FillEllipse(brush, 0, e.LineRect.Top, 15, 15);
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParseList(FunBox);
        }

        private void collapseAllBracetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunBox.CollapseAllFoldingBlocks();
        }

        private void uncollapseAllBracketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunBox.ExpandAllFoldingBlocks();
        }

        private void commentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FunBox.CommentSelected();
        }

        private void autoUpdateListToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //autoUpdateListToolStripMenuItem.Checked;
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormattingScript(FunBox);
        }

        private void fixEmptyLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormattingScriptSpaces(FunBox);
        }

        private void deleteCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormattingScriptComments(FunBox);
        }
    }
}
