using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_White
{
    static class ConsoleError
    {

        public static void UnknownParent(List<string> splitcmd)
        {
            if (splitcmd.Count() != 0)
            {
                ConsoleBox.MessageWrite("Unknown Parent: " + splitcmd[0]);
            }
        }

        public static void UnknownCommand(List<string> splitcmd)
        {
            ConsoleBox.MessageWrite("Parent: " + splitcmd[0] + " does not include the command: " + splitcmd[1]);
        }

        public static void UnknownVariable(List<string> splitcmd)
        {
            try
            {
                ConsoleBox.MessageWrite(splitcmd[0] + " " + splitcmd[1] + "Does not include the variables: " + string.Join(",", splitcmd.GetRange(2, splitcmd.Count() - 2)));
            }
            catch (Exception) { }
        }
    }
}
