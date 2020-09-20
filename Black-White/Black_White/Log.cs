using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Black_White
{
    static class Log
    {
        static string file;

        public static void initLog()
        {
            initLogfile();
        }

        static void initLogfile()
        {
            string _filename = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "-");
            file = BaseInfo.BaseFiles["Base"] + BaseInfo.BaseFiles["Logfolder"] + _filename + ".txt";
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine("DATE: " + _filename);
                sw.WriteLine();
            }
        }

        public static void Write(params string[] text)
        {
            using (StreamWriter sw = File.AppendText(file))
            {
                foreach(string x in text)
                {
                    sw.WriteLine(x);
                }
            }
        }
    }
}
