using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_White
{
    static class ConsoleSuggestion
    {

        public static void getSuggestion(string cmd)
        {
            List<string> splitcmd = ConsoleCommands.splitCMD(cmd);

            if (splitcmd[0] == "Info")
            {
                ConsoleBox.MessageWrite("Use Info infront of any command to get additional information about it");
            }
            else if (splitcmd.Count == 1)
            {
                ConsoleBox.MessageWrite(string.Join(",", ConsoleCommands.allCMD.Keys));
            }
            else if (splitcmd.Count == 2)
            {
                List<CCStruct> cmdparent;

                try
                {
                    cmdparent = ConsoleCommands.allCMD[splitcmd[0]];

                } catch (Exception)
                {
                    ConsoleError.UnknownParent(splitcmd);
                    return;
                }

                List<string> z = new List<string>();

                foreach (CCStruct q in cmdparent)
                {
                    z.Add(q.Command);
                }

                ConsoleBox.MessageWrite(string.Join(",", z));
            }
            else if (splitcmd.Count > 2)
            {
                try
                {
                    CCStruct _struct = ConsoleCommands.allCMD[splitcmd[0]].Find(x => x.Command == splitcmd[1]);
                    ConsoleBox.MessageWrite(string.Join(",", _struct.VariableInf));
                }
                catch (Exception)
                {
                    ConsoleError.UnknownCommand(splitcmd);
                    return;
                }
            }
        }
    }
}
