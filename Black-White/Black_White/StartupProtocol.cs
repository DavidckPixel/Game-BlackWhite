using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Black_White
{
    static class StartupProtocol
    {

        public static void Startup() // first run protocol when game startup.
        {
            BaseInfo.initBaseInfo();

            Log.initLog();

            Config.initConfigFile();
            WindowConfig.initializeScreen();

            Game1.graphics.ApplyChanges();
        }
    }
}
