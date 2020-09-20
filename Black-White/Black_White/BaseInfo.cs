using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Black_White
{
    static class BaseInfo
    {
        public static Dictionary<string, string> BaseFiles;

        public static void initBaseInfo()
        {
            string file = "D:/Game-BlackWhite/Black-White/Black_White/BaseFile.json";
            try
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string Json = r.ReadToEnd();
                    BaseFiles = JsonConvert.DeserializeObject<Dictionary<string, string>>(Json);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
