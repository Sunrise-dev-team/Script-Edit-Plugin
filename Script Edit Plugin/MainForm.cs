using FastColoredTextBoxNS;
using Script_Edit_Plugin.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiLib;
using System.Xml.Linq;
using System.Xml;
using static Script_Edit_Plugin.MainForm;

namespace Script_Edit_Plugin
{
    public partial class MainForm : Form
    {
        static bool isZoneView = false;
        static string ZoneViewPath = "";

        /*string[] zv_macroses = {
                    "q_complete", "q_active", "q_fail",
                    "z_null","z_known", "z_explored",
                    "zt_open", "zt_closed",
                    "br_null", "br_active", "br_readed",
                    "trap_on", "trap_off"
                };*/
        public class Macro
        {
            public string name;
            public string universal_name;
            public string result;
        }
        public List<Macro> zv_macros = new List<Macro>
        {
            new Macro(){name = "q_null", universal_name = "quest_null", result = "0"},
            new Macro(){name = "q_active", universal_name = "quest_active", result = "1"},
            new Macro(){name = "q_complete", universal_name = "quest_completed", result = "2"},
            new Macro(){name = "q_fail", universal_name = "quest_failed", result = "3"},

            new Macro(){name = "z_null", universal_name = "zone_unknown", result = "0"},
            new Macro(){name = "z_known", universal_name = "zone_known", result = "1"},
            new Macro(){name = "z_explored", universal_name = "zone_explored", result = "2"},

            new Macro(){name = "zt_closed", universal_name = "transfer_zone_closed", result = "0"},
            new Macro(){name = "zt_opened", universal_name = "transfer_zone_opened", result = "1"},

            new Macro(){name = "br_null", universal_name = "bfiefing_null", result = "0"},
            new Macro(){name = "br_active", universal_name = "bfiefing_active", result = "1"},
            new Macro(){name = "br_readed", universal_name = "bfiefing_readed", result = "2"},

            new Macro(){name = "trap_on", universal_name = "trap_on", result = "0"},
            new Macro(){name = "trap_off", universal_name = "trap_off", result = "1"},

            new Macro(){name = "lever_disabled", universal_name = "lever_disabled", result = "0"},
            new Macro(){name = "lever_enabled", universal_name = "lever_enabled", result = "1"},
        };

        /*public Dictionary<string,int> zv_macroses = new Dictionary<string, int>
        {
            {"q_null", 0 }, {"q_active", 1 }, { "q_complete", 2 }, {"q_fail", 3 },
            {"quest_null", 0 }, {"quest_active", 1 }, { "quest_complete", 2 }, {"quest_fail", 3 },
            
            { "z_null", 0 },{"z_known", 1 }, { "z_explored", 2 },
            { "zone_null", 0 },{"zone_known", 1 }, { "zone_explored", 2 },

            { "zt_closed", 0 }, { "zt_open", 1 },
            { "zone_transfer_closed", 0 }, { "zone_transfer_open", 1 },

            { "briefing_null", 0 }, { "briefing_active", 1 }, { "briefing_readed", 2 },
            { "br_null", 0 }, { "br_active", 1 }, { "br_readed", 2 },

            { "trap_off", 0 }, { "trap_on", 1 },
            { "lever_disabled", 0 }, { "lever_enabled", 1 }
        };*/


        static bool isChanged = false;
        static bool isNowLoaded = false;
        static string FunText = "";
        static string openedFile;
        //static string prevDir;
        static int errlineind = -1;

        public List<int> lineindexes = new List<int>();
        public List<string> linenames = new List<string>();
        public List<Theme> themes = new List<Theme>();

        static bool isFormatListLoaded = false;
        static bool isThemesloaded = false;

        // TODO: add custom keywords for user defined input when paste template
        public AutocompleteMenu popupMenu;

        Style FunctionNameStyle = new TextStyle(Brushes.SandyBrown, null, FontStyle.Bold);
        Style VarNameStyle = new TextStyle(Brushes.Turquoise, null, FontStyle.Bold);

        public Formatter formatter = new Formatter();


        public void setDescriptionFile(string descriptionFile)
        {
            GuiHelper.setSelfDir();
            GuiHelper.restorePrevDir();
            try
            {
#if DEBUG
                //MessageBox.Show(descriptionFile);
#endif
                FunBox.DescriptionFile = descriptionFile;
                FunBox.Text += "";
            }
            catch
            {
                FunBox.DescriptionFile = "";
            }
            FunBox.Text += "";
            //FunBox_TextChangedDelayed(FunBox, new TextChangedEventArgs(FunBox.Range));
            //FunBox.Invalidate();
            GuiHelper.setSelfDir();
        }

        public MainForm()
        {
            InitializeComponent();
            FunBox.AcceptsTab = true;
            topMostToolStripMenuItem.Checked = Settings.Default.TopMost;
            autoUpdateListToolStripMenuItem.Checked = Settings.Default.AutoUpdateList;
            dynamicHighlighingToolStripMenuItem.Checked = Settings.Default.DynamicHighlighting;

            GuiHelper.setSelfDir();
            GuiHelper.restorePrevDir();
            popupMenu = new AutocompleteMenu(FunBox)
            {
                SearchPattern = @"[a-zA-Z_\-]",
                AllowTabKey = true,
                ToolTipDuration = 10000
            };
            BuildAutocompleteMenu();
            GuiHelper.setSelfDir();
        }

        private async void runBuildFormattingListAsync()
        {
            await Task.Run(() => formatter.FormattingFormatStringsPreBuild());
            isFormatListLoaded = true;
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
            protected readonly string lowerText;
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
                    fragmentText.Length >= 3 && lowerText.IndexOf(fragmentText) >= 0)
                {
                    return CompareResult.Visible;
                }
                return CompareResult.Hidden;
            }
        }

        public class MacroItem : ProcedureItem
        {
            public string search;
            public MacroItem(string text, int imageIndex = -1)
                : base(text, imageIndex)
            {
                //search = lowerText;
            }

            public override CompareResult Compare(string fragmentText)
            {
                if (search.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase))
                    return CompareResult.VisibleAndSelected;
                else if (MenuText.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                       MenuText != fragmentText)
                    return CompareResult.VisibleAndSelected;
                else if (Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) &&
                       Text != fragmentText)
                    return CompareResult.VisibleAndSelected;

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
                GuiHelper.setSelfDir();
                string dir = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(GuiHelper.getSelfPath());
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
                GuiHelper.restorePrevDir();
            }
            catch
            {
                string[] standardProcedures = { "ActivateTrap", "Add", "AddLoot", "AddMob", "AddObject", "AddRectToArea", "AddRoundToArea", "AddUnitToParty", "AddUnitToServer", "AddUnitUnderControl", "AlarmPosX", "AlarmPosY", "AlarmTime", "Any", "AttachParticles", "AttachParticleSource", "Attack", "BlockUnit", "Cast", "CastSpellPoint", "CastSpellUnit", "ConsoleFloat", "ConsoleString", "CopyItems", "CopyLoot", "CopyStats", "Crawl", "CreateFX", "CreateFXSource", "CreateLightning", "CreateParticleSource", "CreateParty", "CreatePointLight", "CreateRandomizeFXSource", "DeleteArea", "DeleteFXSource", "DeleteLightning", "DeleteParticleSource", "DeletePointLight", "DistanceUnitPoint", "DistanceUnitUnit", "Div", "EnableLever", "EraseQuestItem", "Every", "FixItems", "FixWorldTime", "Follow", "For", "ForIf", "GetAIClass", "GetBSZValue", "GetDiplomacy", "GetFutureX", "GetFutureY", "GetLeader", "GetLeverState", "GetLootItemsCount", "GetMercsNumber", "GetMoney", "GetObject", "GetObjectByID", "GetObjectByName", "GetObjectID", "GetPlayer", "GetPlayerUnits", "GetUnitOfPlayer", "GetWorldTime", "GetX", "GetY", "GetZ", "GetZValue", "GiveDexterity", "GiveIntelligence", "GiveItem", "GiveMoney", "GiveQuestItem", "GiveSkill", "GiveStrength", "GiveUnitQuestItem", "GiveUnitSpell", "GodMode", "GroupAdd", "GroupCross", "GroupHas", "GroupSee", "GroupSize", "GroupSub", "GSDelVar", "GSGetVar", "GSSetVar", "GSSetVarMax", "Guard", "HaveItem", "HideObject", "HP", "Idle", "InflictDamage", "InvokeAlarm", "IsAlarm", "IsAlive", "IsCameraPlaying", "IsDead", "IsEnemy", "IsEqual", "IsEqualString", "IsGreater", "IsInArea", "IsInSquare", "IsLess", "IsNight", "IsPlayerInDanger", "IsPlayerInSafety", "IsUnitBlocked", "IsUnitInWater", "IsUnitVisible", "KillScript", "KillUnit", "LeaveToZone", "Lie", "Mana", "MaxHP", "MaxMana", "MoveParticleSource", "MovePointLight", "MoveToObject", "MoveToPoint", "Mul", "Not", "PlayAnimation", "PlayCamera", "PlayerSee", "PlayFX", "PlayMovie", "QFinish", "QObjArea", "QObjGetItem", "QObjKillGroup", "QObjKillUnit", "QObjSeeObject", "QObjSeeUnit", "QObjUse", "QStart", "QuestComplete", "Random", "RecalcMercBriefings", "RedeployParty", "RemoveObject", "RemoveObjectFromServer", "RemoveParty", "RemoveQuestItem", "RemoveUnitFromControl", "RemoveUnitFromParty", "RemoveUnitFromServer", "ResetTarget", "Rest", "RotateTo", "Run", "RunWorldTime", "SendEvent", "SendStringEvent", "Sentry", "SetCameraOrientation", "SetCameraPosition", "SetCP", "SetCPFast", "SetCurrentParty", "SetDiplomacy", "SetDirectionToObject", "SetEnemy", "SetParticleSourceSize", "SetPlayer", "SetPlayerAggression", "SetScience", "SetSpellAggression", "SetSunLight", "SetWaterLevel", "SetWind", "ShowBitmap", "ShowCredits", "Sleep", "SleepUntil", "SleepUntilIdle", "Stand", "StartAnimation", "Sub", "SwitchLeverState", "SwitchLeverStateEx", "UMAg", "UMAggression", "UMClear", "UMCorpseWatcher", "UMFear", "UMFollow", "UMGuard", "UMGuardEx", "UMPatrol", "UMPatrolAddPoint", "UMPatrolAddPointLook", "UMPatrolClear", "UMPlayer", "UMRevenge", "UMSentry", "Walk", "CreateRandomizedFXSource", "PlayMusic", "SetBackGroundColor", "UMStandard", "UMSuspection", "UnitInSquare", "UnitSee", "WaitEndAnimation", "WaitSegment", "WasLooted" };
                foreach (var item in standardProcedures)
                    items.Add(new ProcedureItem(item) { });
            }
            items.Add(new ProcedureItem("DeclareScript new()\r\nScript new\r\n(\r\n  if(\r\n  )\r\n  then(\r\n    KillScript()\r\n    \r\n  )\r\n)") { });

            if( isZoneView)
            {
                foreach (var item in zv_macros) {
                    //int tmp = -1;
                    //zv_macroses.TryGetValue(item, out tmp);
                    //if (tmp != -1)
                    //{
                        items.Add(new MacroItem(item.name)
                        {
                            search = "--",
                            MenuText = item.universal_name,
                            ToolTipTitle = item.name,
                            ToolTipText = string.Format($"Value = {item.result}"),
                        });; 
                    //}
                    //else
                    //    items.Add(new AutocompleteItem(item) { });
                }
            }
            // TODO: User defined autocomplete templates here

            popupMenu.Items.SetAutocompleteItems(items);
        }

        /// <summary>
        /// Script checker ("Script is valid?"). Based on MobExplorer.
        /// </summary>
        private void checkSyntax(string content)
        {
            GuiHelper.setSelfDir();
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

                GuiHelper.restorePrevDir();
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
                    line = int.Parse(line_str);
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
            GuiHelper.restorePrevDir();
        }

        /// <summary>
        /// Send YesNo with Exit on Yes.
        /// </summary>
        public static void toErr(string msg)
        {
            var rez = MessageBox.Show(msg + "\nProgram have potential errors! Abort?", "Warning!", MessageBoxButtons.YesNo);
            if (rez == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// Show OK MessageBox.
        /// </summary>
        public static void toMes(string msg)
        {
            MessageBox.Show(msg, "Message!", MessageBoxButtons.OK);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            runBuildFormattingListAsync();

            foreach (var item in Directory.EnumerateFiles("themes"))
            {
                if (Path.GetExtension(item) == ".xml")
                    ReadTheme(item);
            }
            if (themeCombo.Items.Count <= 0)
            {
                themeCombo.Items.Add("None");
                themeCombo.SelectedIndex = 0;
            }
            else
            {
                themeCombo.SelectedIndex = Settings.Default.Theme;
                SetTheme(themeCombo.SelectedIndex);
            }

            isThemesloaded = true;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args.Length < 3)
            {
                string filePath = args[1];
                LoadFile(filePath);
            }
#if !CLEAR
            else if (args.Length > 2 && args.Length < 4)
            {
                StartMsg start = new StartMsg();
                var rez = start.ShowDialog();
                if (rez == DialogResult.OK)
                {
                    isZoneView = true;
                    ZoneViewPath = args[1];
                    string filePath = args[2];
                    LoadFile(filePath);
                    openToolStripMenuItem.Enabled = false;
                    autoExportToolStripMenuItem.Enabled = true;
                    exportToolStripMenuItem.Enabled = true;
                    exportSettingsToolStripMenuItem1.Enabled = true;
                    BuildAutocompleteMenu();
                }
                else if (rez == DialogResult.Cancel)
                {
                    isZoneView = false;
                    ZoneViewPath = "";
                    string filePath = args[1];
                    LoadFile(filePath);
                    openToolStripMenuItem.Enabled = true;
                    autoExportToolStripMenuItem.Enabled = false;
                    exportToolStripMenuItem.Enabled = false;
                    exportSettingsToolStripMenuItem1.Enabled = false;
                }
            }
#endif
            var size = new Size(400, 400);
            if (
                (Settings.Default.Size.Width >= size.Width) &&
                (Settings.Default.Size.Height >= size.Height)
                )
            {
                this.Size = Settings.Default.Size;
            }
            if (
                (Settings.Default.ScreenPos.X >= 0) &&
                (Settings.Default.ScreenPos.Y >= 0)
                )
            {
                this.Location = Settings.Default.ScreenPos;
            }
            else
            {
                var poin = new Point(0, 0);
                this.Location = poin;

            }

            //
            
        }

        /// <summary>
        /// Read input file to FunTextBox, and parse FunList.
        /// </summary>
        void LoadFile(string path)
        {
            if (File.Exists(path))
            {
                FunText = File.ReadAllText(path, Encoding.GetEncoding("windows-1251"));
                isNowLoaded = true;
                FunBox.Text = FunText;
                FunBox.ClearUndo();
                openedFile = path;
#if !CLEAR
                // TODO:OK "Src is empty, clone compiled to src?" here
                if (string.IsNullOrWhiteSpace(FunBox.Text) && isZoneView)
                {
                    var rez = MessageBox.Show("The Source script text is empty. Copy text from Result script?", "Message!", MessageBoxButtons.OKCancel);
                    if (rez == DialogResult.OK)
                    {
                        FunText = File.ReadAllText(ZoneViewPath, Encoding.GetEncoding("windows-1251"));
                        FunBox.Text = FunText;
                        FunBox.ClearUndo();
                    }
                }
                else if (!FunBox.Text.Contains("WorldScript") && isZoneView)
                {
                    var rez = MessageBox.Show("The Source script text don`t have WorldScript block. Copy text from Result script?", "Message!", MessageBoxButtons.OKCancel);
                    if (rez == DialogResult.OK)
                    {
                        FunText = File.ReadAllText(ZoneViewPath, Encoding.GetEncoding("windows-1251"));
                        FunBox.Text = FunText;
                        FunBox.ClearUndo();
                    }
                }
#endif
                ParseList(FunBox);
                isChanged = false;
            }
            else
            {
                toErr(string.Format("File \"{0}\" not found!", path));
            }
        }

        /// <summary>
        /// Saving question, Open dialog, Canceling saving in zoneview mode.
        /// </summary>
        private void openPrj()
        {
#if !CLEAR
            if (isZoneView)
            {
                toMes("Zone View mode: the function is not available.");
                return;
            }
#endif
            if (isChanged)
            {
                var rez = MessageBox.Show("You have unsaved changes! Save?", "Warning!", MessageBoxButtons.YesNoCancel);
                if (rez == DialogResult.Yes)
                {
                    // TODO:OK Save here
                    savePrj(openedFile);
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

        /// <summary>
        /// Owerwrite question, Export in zoneview mode.
        /// </summary>
        private void savePrj(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;
            /*if (isZoneView)
            {
                //TODO: add export window.
                //toMes("Zone View mode: the function is not available.");
                return;
            }*/
            ////////////////////////////////////////////////
            if (File.Exists(path))
            {
                var rez = MessageBox.Show("Do you really want to overwrite file?", "Warning!", MessageBoxButtons.YesNo);
                if (rez == DialogResult.No) { return; }
            }
            File.WriteAllText(path, FunBox.Text);
            //FunText = FunBox.Text;
            isChanged = false;
        }

        /// <summary>
        /// Parse text from target textbox to FunList.
        /// </summary>
        void ParseList(FastColoredTextBox box)
        {
            string line, low;
            var lines = box.Lines;
            int nextlineIndex = 0;
            linenames.Clear();
            lineindexes.Clear();
            while (nextlineIndex < box.LinesCount)
            {
                line = lines[nextlineIndex];
                low = line.ToLower();
                if (low.Contains("script "))
                {
                    lineindexes.Add(nextlineIndex);
                    linenames.Add(line.Replace("Script ", " "));
                }
                else if (low.Contains("//# "))
                {
                    lineindexes.Add(nextlineIndex);
                    linenames.Add(line.Replace("//# ", "// "));
                }
                else if (low.Contains("worldscript"))
                {
                    lineindexes.Add(nextlineIndex);
                    linenames.Add(line);
                }
                else if (low.Contains("globalars"))
                {
                    lineindexes.Add(nextlineIndex);
                    linenames.Add(line);
                }
                nextlineIndex++;
            }
            updateList();
        }

        /// <summary>
        /// Update content in FunList.
        /// </summary>
        private void updateList()
        {
            var sel = FunList.SelectedIndex;
            FunList.Items.Clear();
            for (int i = 0; i < linenames.Count; i++)
            {
                FunList.Items.Add(linenames[i].ToString());
            }
            if (sel < FunList.Items.Count)
                FunList.SelectedIndex = sel;
            else
                FunList.SelectedIndex = FunList.Items.Count - 1;
        }

        public class Theme
        {
            public Color FunBoxFore { get; set; }
            public Color FunBoxBack { get; set; }
            public Color FunBoxDisabled { get; set; }
            public Color FunBoxIndent { get; set; }
            public Color FunBoxLineNum { get; set; }
            public Color FunBoxSel { get; set; }
            public Color FunBoxService { get; set; }
            public Color FunListFore { get; set; }
            public Color FunListBack { get; set; }
            public Color MenuBack { get; set; }
            public Color MenuFore { get; set; }
            public Color MainBack { get; set; }
            public Color DocMapBack { get; set; }
            //public Color FunName { get; set; }
            //public Color VarName { get; set; }
            //public Color IndicatorLine { get; set; }
            //public Color IndicatorErr { get; set; }
            public string DescFile { get; set; }
            public string Name { get; set; }
        }
        private Color PrsThemeLineName(string name, string colorn)
        {
                return Color.FromName(colorn);
        }
        private Color PrsThemeLineRGB(string name, int r, int g, int b)
        {
                return Color.FromArgb(r,g,b);
        }
        public void ReadTheme(string name)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(name);
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    Theme theme = new Theme();
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    theme.Name = attr.Value;

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        Color color = Color.FromArgb(0, 0, 0);
                        //if (childnode.Name == "FunBoxFore")
                        //var prs = PrsThemeLine(childnode.Attributes.GetNamedItem("name").Value, childnode.Attributes.GetNamedItem("color").Value, Int32.Parse( childnode.Attributes.GetNamedItem("isrgb").Value));
                        if (childnode.Attributes.GetNamedItem("r") != null && childnode.Attributes.GetNamedItem("g") != null && childnode.Attributes.GetNamedItem("b") != null)
                        {
                            if(childnode.Attributes.GetNamedItem("a") != null)
                            color = Color.FromArgb(int.Parse(childnode.Attributes.GetNamedItem("a").Value),int.Parse(childnode.Attributes.GetNamedItem("r").Value), int.Parse(childnode.Attributes.GetNamedItem("g").Value), int.Parse(childnode.Attributes.GetNamedItem("b").Value));
                            else
                            color = Color.FromArgb(int.Parse(childnode.Attributes.GetNamedItem("r").Value), int.Parse(childnode.Attributes.GetNamedItem("g").Value), int.Parse(childnode.Attributes.GetNamedItem("b").Value));
                        }
                        else if (childnode.Attributes.GetNamedItem("color") != null)
                        {
                            color = Color.FromName(childnode.Attributes.GetNamedItem("color").Value);
                        }
                        switch (childnode.Attributes.GetNamedItem("name").Value)
                        {
                            case "TextBoxForeTextColor":
                                theme.FunBoxFore = color;
                                break;
                            case "TextBoxBackColor":
                                theme.FunBoxBack = color;
                                break;
                            case "TextBoxDisabledColor":
                                theme.FunBoxDisabled = color;
                                break;
                            case "TextBoxMapBackColor":
                                theme.DocMapBack = color;
                                break;
                            case "TextBoxIndentBgColor":
                                theme.FunBoxIndent = color;
                                break;
                            case "TextBoxLineNumColor":
                                theme.FunBoxLineNum = color;
                                break;
                            case "TextBoxLineSelColor":
                                theme.FunBoxSel = color;
                                break;
                            case "ListBackColor":
                                theme.FunListBack = color;
                                break;
                            case "ListForeTextColor":
                                theme.FunListFore = color;
                                break;
                            case "MenuBackColor":
                                theme.MenuBack = color;
                                break;
                            case "MenuItemForeColor":
                                theme.MenuFore = color;
                                break;
                            case "GeneralBackColor":
                                theme.MainBack = color;
                                break;
                            case "TextBoxServiceLinesColor":
                                theme.FunBoxService = color;
                                break;
                           /* case "TextBoxMapBackColor":
                                theme.VarName = color;
                                break;
                            case "TextBoxMapBackColor":
                                theme.DocMapBack = color;
                                break;
                            case "TextBoxMapBackColor":
                                theme.DocMapBack = color;
                                break;*/
                            case "DescriptionFile":
                                theme.DescFile = childnode.Attributes.GetNamedItem("filename").Value;
                                break;
                        }
                    }
                    themes.Add(theme);
                    themeCombo.Items.Add(theme.Name);
                }
            }
        }
        /// <summary>
        /// Switch theme.
        /// </summary>
        private void SetTheme(int numTheme)
        {
            // TODO: In process! create CustomThemesManager with .xml themes for all windows (shared class). 
            
            FunBox.ForeColor = themes[numTheme].FunBoxFore;
            FunBox.BackColor = themes[numTheme].FunBoxBack;
            FunBox.DisabledColor = themes[numTheme].FunBoxDisabled;
            FunBox.IndentBackColor = themes[numTheme].FunBoxIndent;
            FunBox.LineNumberColor = themes[numTheme].FunBoxLineNum;
            FunBox.SelectionColor = themes[numTheme].FunBoxSel;
            FunBox.ServiceLinesColor = themes[numTheme].FunBoxService;
            FunList.BackColor = themes[numTheme].FunListBack;
            FunList.ForeColor = themes[numTheme].FunListFore;
            menuStrip1.BackColor = themes[numTheme].MenuBack;
            fileToolStripMenuItem.ForeColor = editToolStripMenuItem.ForeColor =
                scriptToolStripMenuItem.ForeColor = settingsToolStripMenuItem.ForeColor =
                funcListToolStripMenuItem.ForeColor = aboutToolStripMenuItem.ForeColor = themes[numTheme].MenuFore;

            splitContainer1.BackColor = themes[numTheme].MainBack;
            documentMap1.BackColor = themes[numTheme].DocMapBack;
            FunctionNameStyle = new TextStyle(Brushes.SandyBrown, null, FontStyle.Bold);
            VarNameStyle = new TextStyle(Brushes.Turquoise, null, FontStyle.Bold);
            setDescriptionFile(themes[numTheme].DescFile);
            /*switch (numTheme)
            {
                case 0:
                    FunBox.ForeColor = themes[numTheme].FunBoxFore;//SystemColors.ActiveCaption;
                    FunBox.BackColor =  Color.FromArgb((int)(byte)31, (int)(byte)31, (int)(byte)31);
                    FunBox.DisabledColor = Color.FromArgb((int)(byte)100, (int)(byte)180, (int)(byte)180, (int)(byte)180);
                    FunBox.IndentBackColor = Color.FromArgb((int)(byte)56, (int)(byte)56, (int)(byte)56);
                    FunBox.LineNumberColor = Color.Chartreuse;
                    FunBox.SelectionColor = Color.FromArgb((int)(byte)60, (int)(byte)0, (int)(byte)0, (int)(byte)255);
                    //FunBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("FunBox.ServiceColors")));
                    FunBox.ServiceLinesColor = Color.Black;
                    FunList.BackColor = Color.FromArgb(56, 56, 56);
                    FunList.ForeColor = Color.Chartreuse;
                    menuStrip1.BackColor = Color.FromArgb((int)(byte)56, (int)(byte)56, (int)(byte)56);
                    fileToolStripMenuItem.ForeColor = editToolStripMenuItem.ForeColor = 
                        scriptToolStripMenuItem.ForeColor = settingsToolStripMenuItem.ForeColor = 
                        funcListToolStripMenuItem.ForeColor = aboutToolStripMenuItem.ForeColor = Color.Chartreuse;

                    splitContainer1.BackColor = Color.FromArgb(64, 64, 64);
                    documentMap1.BackColor = Color.FromArgb(64, 64, 64);
                    FunctionNameStyle = new TextStyle(Brushes.SandyBrown, null, FontStyle.Bold);
                    VarNameStyle = new TextStyle(Brushes.Turquoise, null, FontStyle.Bold);
                    setDescriptionFile("ei_syntax_dark.xml");
                    break;
            };*/
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
            Settings.Default.Theme = themeCombo.SelectedIndex;
            Settings.Default.TopMost = topMostToolStripMenuItem.Checked;
            Settings.Default.AutoUpdateList = autoUpdateListToolStripMenuItem.Checked;
            Settings.Default.DynamicHighlighting = dynamicHighlighingToolStripMenuItem.Checked;

            Settings.Default.SplitShift = splitContainer1.SplitterDistance;
            Settings.Default.SplitShift2 = splitContainer2.SplitterDistance;
            Settings.Default.Save();
        }

        private void validCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkSyntax(FunBox.Text);
        }

        private void createGroupFromIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: CRAP: remove this and GroupGen, when ZoneView 1.2 is outdated.
            GroupGen dialog = new GroupGen();
            dialog.ShowDialog();
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
            if(isThemesloaded)
                SetTheme(themeCombo.SelectedIndex);
        }

        private void topMostToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = topMostToolStripMenuItem.Checked;
        }

        private void FunBox_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            if (isNowLoaded)
            {
                isNowLoaded = false;
                return; 
            }
            //MessageBox.Show(e.ChangedRange.Length.ToString());

            //if (FunText != FunBox.Text) // for which purproses this?!!!!
            //{
            if (e.ChangedRange.Length != 0) { 
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
                    FunBox.Range.SetStyle(VarNameStyle, $@"\b{found.Text}\b", RegexOptions.IgnoreCase);
                }

                foreach (Range found in FunBox.GetRanges(@"\b(DeclareScript|declarescript)\s+(?<range>\w+)\b"))
                {
                    FunBox.Range.SetStyle(FunctionNameStyle, $@"\b{found.Text}\b", RegexOptions.IgnoreCase);
                }

                foreach (Range found in FunBox.GetRanges(@"\b(DeclareScript|declarescript)\b[ ]+(?<range>[\#|a-z|\w]+)[ ]*\("))
                {
                    if (found.Text[0] == '#')
                    {
                        FunBox.Range.SetStyle(FunctionNameStyle, $@"{found.Text}", RegexOptions.IgnoreCase);
                    }
                    else
                    {
                        FunBox.Range.SetStyle(FunctionNameStyle, $@"\b{found.Text}\b", RegexOptions.IgnoreCase);
                    }

                    //FunBox.Range.SetStyle(FunctionNameStyle, @"#", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }
                /*foreach (Range found in FunBox.GetRanges(@"\b(DeclareScript|declarescript)\s+\W(?<range>\w+)\b"))
                {
                    FunBox.Range.SetStyle(FunctionNameStyle, @"\#\b" + found.Text + @"\b", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }*/
            }
#if !CLEAR
            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();
            //set markers for folding
            e.ChangedRange.SetFoldingMarkers(@"\(", @"\)");
#endif
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                var rez = MessageBox.Show("You have unsaved changes! Save?", "Warning!", MessageBoxButtons.YesNoCancel);
                if (rez == DialogResult.Yes)
                {
                    // TODO:OK Save here
                    savePrj(openedFile);
                }
                if (rez == DialogResult.Cancel) { e.Cancel = true; return; }
            }
            e.Cancel = false;
        }

        private void findToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FunBox.ShowFindDialog();
        }

        private void FunList_DoubleClick(object sender, EventArgs e)
        {
            FunBox.Navigate(lineindexes[FunList.SelectedIndex]);
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
            else if (e.LineIndex == errlineind && errlineind != -1)
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

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFormatListLoaded)
            {
                toMes("Creating Function Formatting List, retry later!");
                return;
            }
            formatter.FormattingScript(FunBox);
        }

        private void fixEmptyLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formatter.FormattingScriptSpaces(FunBox);
        }

        private void deleteCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if !CLEAR
            formatter.FormattingScriptComments(FunBox);
#endif
        }

        private void exportSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExportSettings exportSettings = new ExportSettings();
            exportSettings.ShowDialog();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            var size = new Size(400, 400);
            if ((Size.Width >= size.Width) && (Size.Height >= size.Height))
            {
                if (this.Size != Settings.Default.Size)
                {
                    Settings.Default.Size = this.Size;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            FunBox.Focus();
        }
    }
}
