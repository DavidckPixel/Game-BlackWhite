using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Black_White
{
    class ConsoleCommands
    {
        static string file = BaseInfo.BaseFiles["Base"] + BaseInfo.BaseFiles["ConsoleCMD"];

        public static Dictionary<string, List<CCStruct>> allCMD;

        public static ConsoleCommands cc;

        public ConsoleCommands(List<CCStruct>Windows, List<CCStruct>console)
        {
            allCMD = new Dictionary<string, List<CCStruct>>()
            {
            { "Windows", Windows },
            { "Console", console },
            { "Info", new List<CCStruct>() }
            };
        }
         
        public static void initConsoleCommands()
        {
            try
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string Json = r.ReadToEnd();
                    cc = JsonConvert.DeserializeObject<ConsoleCommands>(Json);                            
                }
            }
            catch (Exception)
            {
            }
        }


        public static List<string> splitCMD(string cmd)
        {
            string[] split = cmd.Split(' ');
            return split.ToList();
        }


        public static void ParseCMD(string cmd)
        {
            List<string> splitcmd = splitCMD(cmd);

            try
            {
                if (splitcmd[0] == "Windows")
                {
                    switch (splitcmd[1])
                    {
                        case "SetSize":
                            WindowConfig.changeWindowSize(Int32.Parse(splitcmd[2]), Int32.Parse(splitcmd[3]), splitcmd[4]);
                            break;
                        case "GetWidth": 
                            ConsoleBox.MessageWrite("Windows Width: " + WindowConfig.windowWidth.ToString());
                            break;
                        case "GetHeight": 
                            ConsoleBox.MessageWrite("Windows Height: " + WindowConfig.windowHeight.ToString());
                            break;
                        default:
                            ConsoleError.UnknownCommand(splitcmd);
                            break;
                    }
                }
                else if (splitcmd[0] == "Console")
                {
                    switch (splitcmd[1])
                    {
                        case "Clear":
                            ConsoleBox.Clear();
                            break;
                        case "setSaveHistory":
                            ConsoleBox.MessageWrite("-- Now saving all console messages and commands!");
                            ConsConfig.setSaveHistory();
                            break;
                        case "getSaveHistory":
                            ConsoleBox.MessageWrite(ConsConfig.getSaveHistory().ToString());
                            break;
                    }
                }
                else if (splitcmd[0] == "Info")
                {
                    CCStruct _struct = allCMD[splitcmd[1]].Find(x => x.Command == splitcmd[2]);
                    ConsoleBox.MessageWrite(_struct.Info);
                }
                else
                {
                    ConsoleError.UnknownParent(splitcmd);
                }
            }

            catch (Exception)
            {
                ConsoleError.UnknownVariable(splitcmd);
            }
        }
    }
}
