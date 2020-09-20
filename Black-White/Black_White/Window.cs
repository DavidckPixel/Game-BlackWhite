using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Black_White
{

    class WindowConfig
    {
        static public int windowWidth; //Width of the screen
        static public int windowHeight; //Height of the screen
        static public string windowRes; //Full resolution <width,Height>

        public WindowConfig(int x, int y, string res)
        {
            windowWidth = x;
            windowHeight = y;
            windowRes = res;
        } 

        private static void initializeScreenSize() 
        {
            Game1.graphics.PreferredBackBufferWidth = windowWidth;
            Game1.graphics.PreferredBackBufferHeight = windowHeight;
        }

        public static void initializeScreen() //Only runs during startup
        {
            initializeScreenSize();
        }

        public static void changeWindowSize(int x, int y, string res)
        {
            windowWidth = x;
            windowHeight = y;
            windowRes = res;

            initializeScreenSize();

            Game1.graphics.ApplyChanges();
        }
    }
}
