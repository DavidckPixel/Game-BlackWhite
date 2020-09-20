using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Black_White
{
    class Config //Class to store the active config
    {
        public static Config con;
        static WindowConfig screen;
        static ConsConfig cons;

        public Config(WindowConfig Screen, ConsConfig Cons)
        {
            screen = Screen;
            cons = Cons;
        }

        public static void initConfigFile()
        {
            string file = BaseInfo.BaseFiles["Base"] + BaseInfo.BaseFiles["StandardConfig"];


            try
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string Json = r.ReadToEnd();
                    con = JsonConvert.DeserializeObject<Config>(Json);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
