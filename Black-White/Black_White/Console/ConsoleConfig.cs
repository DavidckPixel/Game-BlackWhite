using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Black_White
{
    class ConsConfig
    {
        static public bool Enabled;
        static public bool SaveHistory;
        static public int Lines;
        static public string ConsoleInf;
        static public string HistoryFolder;
        static public string filename;

        public static int LineWidth = Game1.Fonts.Ariel20.LineSpacing;
        
        public ConsConfig(bool enabled, bool saveHistory, int lines, string consoleInf, string historyFolder)
        {
            Enabled = enabled;
            Lines = lines;
            ConsoleInf = consoleInf;
            HistoryFolder = historyFolder;

            if (saveHistory) { setSaveHistory(); }

            startup();
        } 

        public static bool getSaveHistory(){return SaveHistory;}

        public static void setSaveHistory(){SaveHistory = true; CreateFile(); }

        public static void CreateFile()
        {
            string _filename = DateTime.Now.ToString().Replace(" ", "_").Replace(":","-");
            filename = BaseInfo.BaseFiles["Base"] + HistoryFolder + _filename + ".txt";
            using (StreamWriter sw = new StreamWriter(filename)){
                sw.WriteLine("DATE: " + _filename);
                sw.WriteLine();
            }            
        }

        private static void startup()
        {
            ConsoleCommands.initConsoleCommands();
            ConsoleBox.initMessages();

            ConsoleBox.MessageWrite("Type ur Command: ");
            ConsoleBox.MessageWrite("press tab for suggestions");
            ConsoleBox.MessageWrite("Save History: " + SaveHistory.ToString());
            ConsoleBox.MessageWrite("Location SaveFile: " + filename);
            ConsoleBox.MessageWrite("---------------------------------------------------------------------------");
        }
    }
}
