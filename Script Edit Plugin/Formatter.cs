using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using GuiLib;
using System.Windows.Forms;

namespace Script_Edit_Plugin
{
    public class Formatter
    {
        // TODO: correct \r\n in For and ForIf EI loops


        public List<string> unformattedstrings = new List<string>();
        public List<string> formattedstrings = new List<string>();
        public List<string> blockunformattedstrings = new List<string>();
        public List<string> blockformattedstrings = new List<string>();

        /// <summary>
        /// Format all script text in target FastColoredTextBox.
        /// </summary>
        public void FormattingScript(FastColoredTextBox box)
        {
            var tmp = box.Text;
            //tmp = Regex.Replace(tmp, @"if.\s*\(.\s*\).\s*","if()");
            tmp = Regex.Replace(tmp, @"\b[Tt][Hh][Ee][Nn]\b\r\n\s*\(", "then(");    // then\n( -> then(
            tmp = Regex.Replace(tmp, @"\b[Ii][Ff]\b\s*\r\n\s*\(", "if(");              // if\n( -> if(
            tmp = Regex.Replace(tmp, @"\(\s*\)", "()");                             // (   ) -> ()
            tmp = Regex.Replace(tmp, @"\b[Dd][Ee][Cc][Ll][Aa][Rr][Ee][Ss][Cc][Rr][Ii][Pp][Tt]\b", "DeclareScript");
            tmp = Regex.Replace(tmp, @"\b[Ss][Cc][Rr][Ii][Pp][Tt]\b", "Script");
            tmp = Regex.Replace(tmp, @"\b[Gg][Ll][Oo][Bb][Aa][Ll][Vv][Aa][Rr][Ss]\b", "GlobalVars");
            tmp = Regex.Replace(tmp, @"\b[Ww][Oo][Rr][Ll][Dd][Ss][Cc][Rr][Ii][Pp][Tt]\b", "WorldScript");
            tmp = Regex.Replace(tmp, @" +\) *\r\n", ")\r\n");

            tmp = Regex.Replace(tmp, @"\r\n[ ]*\)[ ]*\r\n", "\r\n\t)\r\n");
            tmp = Regex.Replace(tmp, @"\r\n[ ]*\b[Ii][Ff]\b[ ]*\(", "\r\n\tif(");          // iF -> if
            tmp = Regex.Replace(tmp, @"\r\n[ ]*\b[Tt][Hh][Ee][Nn]\b[ ]*\(", "\r\n\tthen(");// ThEn -> then
            tmp = Regex.Replace(tmp, @"\r\n[ ]+", "\r\n\t\t");                      // "       Leavetozone(" -> "   Leavetozone("
            tmp = Regex.Replace(tmp, @"\r\n[ ]+\([ ]*\r\n", "\r\n\t(\r\n\t\t");
            tmp = Regex.Replace(tmp, @"\r\n[ ]*\)[ ]*\r\n[ ]*\)[ ]*\r\n[ ]*\)[ ]*\r\n", "\r\n\t\t)\r\n\t)\r\n)\r\n");
            tmp = Regex.Replace(tmp, @"[ ]*\)[ ]*\)[ ]*\r\n", "))\r\n");
            tmp = Regex.Replace(tmp, @"[ ]*\)[ ]*\)[ ]*\)[ ]*\r\n", ")))\r\n");

            //tmp = Regex.Replace(tmp, "^[ ]+\b", "  "); // "     " -> " "
            tmp = FormattingFormatStrings(tmp);
            box.Text = tmp;//Regex.Replace(tmp, @"if.\s*\(.\s*?<range>.\s*\).\s*", @"(<range>)");
        }

        /// <summary>
        /// Format all spaces in target FastColoredTextBox. 
        /// </summary>
        public void FormattingScriptSpaces(FastColoredTextBox box)
        {
            var tmp = box.Text;
            tmp = Regex.Replace(tmp, @"^\s*\r?\n|\r?\n(?!\s*\S)", "", RegexOptions.Multiline);
            tmp = Regex.Replace(tmp, @"\r\n\b[Ss][Cc][Rr][Ii][Pp][Tt]\b", "\n\nScript");
            tmp = Regex.Replace(tmp, @"\r\n\b[Ww][Oo][Rr][Ll][Dd][Ss][Cc][Rr][Ii][Pp][Tt]\b", "\n\nWorldScript");
            box.Text = tmp;
        }
#if !CLEAR
        /// <summary>
        /// Format all spaces in target FastColoredTextBox. 
        /// </summary>
        public void FormattingScriptComments(FastColoredTextBox box)
        {
            var tmp = box.Text;
            tmp = Regex.Replace(tmp, @"(?s)\s*\/\/.+?\n|\/\*.*?\*\/\s*", "\r\n");
            box.Text = tmp;
        }
#endif

        public string FormattingFormatStrings(string text /*, FastColoredTextBox box*/)
        {
            var tmp = text;
            for (int i = 0; i < formattedstrings.Count; i++)
            {
                tmp = Regex.Replace(tmp, @formattedstrings[i], unformattedstrings[i], RegexOptions.Multiline);

            }
            for (int i = 0; i < formattedstrings.Count; i++)
            {
                tmp = Regex.Replace(tmp, @"[ ]*" + @unformattedstrings[i] + @"[ ]*\([ ]*", unformattedstrings[i] + "(", RegexOptions.Multiline);
                tmp = Regex.Replace(tmp, @"[ ]*\=[ ]*" + @unformattedstrings[i], " = " + unformattedstrings[i], RegexOptions.Multiline);
                tmp = Regex.Replace(tmp, @unformattedstrings[i] + @"[ ]*\([ ]*\)[ ]*,[ ]*", unformattedstrings[i] + @"(), ", RegexOptions.Multiline);
                tmp = Regex.Replace(tmp, @"[ ]*,[ ]*" + @unformattedstrings[i], ", " + unformattedstrings[i], RegexOptions.Multiline);
            }

            // TODO: Check this shitcode!!! Correct cAsE oF ScrIPt BLOcK
            // Cutted temporary
            /*
            foreach (Range found in box.GetRanges(@"\b(DeclareScript|declarescript)\s+(?<range>\w+)\b"))
            {
                blockunformattedstrings.Add(box.Range.Text);
                blockformattedstrings.Add(FormattingBuildFormattedString2(box.Range.Text));
                //MessageBox.Show(found.Text);
            }
            for (int i = 0; i < blockformattedstrings.Count; i++)
            {
                tmp = Regex.Replace(tmp, @blockformattedstrings[i] + @"[ ]*\([ ]*", blockunformattedstrings[i] + "(", RegexOptions.Multiline);
            }
            */

            text = tmp;
            return text;
        }

        /// <summary>
        /// Create Regex strings for fix cASe oF StanDArT WoRDs.
        /// </summary>
        public void FormattingFormatStringsPreBuild()
        {
            unformattedstrings.Clear();
            formattedstrings.Clear();
            try
            {
                GuiHelper.setSelfDir();
                string dir = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(GuiHelper.getSelfPath());
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
                GuiHelper.restorePrevDir();
            }
            catch
            {
                string[] standardProcedures = { "ActivateTrap", "Add", "AddLoot", "AddMob", "AddObject", "AddRectToArea", "AddRoundToArea", "AddUnitToParty", "AddUnitToServer", "AddUnitUnderControl", "AlarmPosX", "AlarmPosY", "AlarmTime", "Any", "AttachParticles", "AttachParticleSource", "Attack", "BlockUnit", "Cast", "CastSpellPoint", "CastSpellUnit", "ConsoleFloat", "ConsoleString", "CopyItems", "CopyLoot", "CopyStats", "Crawl", "CreateFX", "CreateFXSource", "CreateLightning", "CreateParticleSource", "CreateParty", "CreatePointLight", "CreateRandomizeFXSource", "DeleteArea", "DeleteFXSource", "DeleteLightning", "DeleteParticleSource", "DeletePointLight", "DistanceUnitPoint", "DistanceUnitUnit", "Div", "EnableLever", "EraseQuestItem", "Every", "FixItems", "FixWorldTime", "Follow", "For", "ForIf", "GetAIClass", "GetBSZValue", "GetDiplomacy", "GetFutureX", "GetFutureY", "GetLeader", "GetLeverState", "GetLootItemsCount", "GetMercsNumber", "GetMoney", "GetObject", "GetObjectByID", "GetObjectByName", "GetObjectID", "GetPlayer", "GetPlayerUnits", "GetUnitOfPlayer", "GetWorldTime", "GetX", "GetY", "GetZ", "GetZValue", "GiveDexterity", "GiveIntelligence", "GiveItem", "GiveMoney", "GiveQuestItem", "GiveSkill", "GiveStrength", "GiveUnitQuestItem", "GiveUnitSpell", "GodMode", "GroupAdd", "GroupCross", "GroupHas", "GroupSee", "GroupSize", "GroupSub", "GSDelVar", "GSGetVar", "GSSetVar", "GSSetVarMax", "Guard", "HaveItem", "HideObject", "HP", "Idle", "InflictDamage", "InvokeAlarm", "IsAlarm", "IsAlive", "IsCameraPlaying", "IsDead", "IsEnemy", "IsEqual", "IsEqualString", "IsGreater", "IsInArea", "IsInSquare", "IsLess", "IsNight", "IsPlayerInDanger", "IsPlayerInSafety", "IsUnitBlocked", "IsUnitInWater", "IsUnitVisible", "KillScript", "KillUnit", "LeaveToZone", "Lie", "Mana", "MaxHP", "MaxMana", "MoveParticleSource", "MovePointLight", "MoveToObject", "MoveToPoint", "Mul", "Not", "PlayAnimation", "PlayCamera", "PlayerSee", "PlayFX", "PlayMovie", "QFinish", "QObjArea", "QObjGetItem", "QObjKillGroup", "QObjKillUnit", "QObjSeeObject", "QObjSeeUnit", "QObjUse", "QStart", "QuestComplete", "Random", "RecalcMercBriefings", "RedeployParty", "RemoveObject", "RemoveObjectFromServer", "RemoveParty", "RemoveQuestItem", "RemoveUnitFromControl", "RemoveUnitFromParty", "RemoveUnitFromServer", "ResetTarget", "Rest", "RotateTo", "Run", "RunWorldTime", "SendEvent", "SendStringEvent", "Sentry", "SetCameraOrientation", "SetCameraPosition", "SetCP", "SetCPFast", "SetCurrentParty", "SetDiplomacy", "SetDirectionToObject", "SetEnemy", "SetParticleSourceSize", "SetPlayer", "SetPlayerAggression", "SetScience", "SetSpellAggression", "SetSunLight", "SetWaterLevel", "SetWind", "ShowBitmap", "ShowCredits", "Sleep", "SleepUntil", "SleepUntilIdle", "Stand", "StartAnimation", "Sub", "SwitchLeverState", "SwitchLeverStateEx", "UMAg", "UMAggression", "UMClear", "UMCorpseWatcher", "UMFear", "UMFollow", "UMGuard", "UMGuardEx", "UMPatrol", "UMPatrolAddPoint", "UMPatrolAddPointLook", "UMPatrolClear", "UMPlayer", "UMRevenge", "UMSentry", "Walk", "CreateRandomizedFXSource", "PlayMusic", "SetBackGroundColor", "UMStandard", "UMSuspection", "UnitInSquare", "UnitSee", "WaitEndAnimation", "WaitSegment", "WasLooted" };
                for (int i = 0; i < standardProcedures.Length; i++)
                {
                    var Name = standardProcedures[i];
                    unformattedstrings.Add(Name);
                    formattedstrings.Add(FormattingBuildFormattedString(Name));
                }
            }
        }

        private string getMethodName(string refs)
        {
            int pos = refs.IndexOf('(');
            if (pos >= 0)
                return refs.Substring(0, pos);
            return refs;
        }

        /// <summary>
        /// Create one Regex string for fix VTriger#0#1( NULL) -> VTriger#0#1(NULL).
        /// </summary>
        public string FormattingBuildFormattedString2(string funName)
        {
            if (string.IsNullOrEmpty(funName))
                return "";
            var tmp = @"";

            tmp += @"\b";
            tmp += @funName;
            tmp += @"\b";

            return tmp;
        }

        /// <summary>
        /// Create one Regex string for fix cASe oF StanDArT WoRDs.
        /// </summary>
        public string FormattingBuildFormattedString(string funName)
        {
            if (string.IsNullOrEmpty(funName))
                return "";
            var tmp = @"";
            tmp += @"\b";
            for (int i = 0; i < funName.Length; i++)
            {
                tmp += @"[";
                tmp += @funName[i].ToString().ToUpper();
                tmp += @funName[i].ToString().ToLower();
                tmp += @"]";
            }
            tmp += @"\b";
            return tmp;
        }

    }
}
