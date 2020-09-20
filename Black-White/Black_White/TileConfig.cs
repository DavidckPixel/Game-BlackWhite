using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_White
{
    class TileConfig
    {
        public int OrgWidth; 
        public int OrgHeight;
        public int TilePerScreen;

        public int Width;
        public int Height;
        public int Scale;


        public TileConfig(int Width, int Height, int TilePerScreen)
        {
            this.OrgWidth = Width;
            this.OrgHeight = Height;
            this.TilePerScreen = TilePerScreen;

            SetTileWidth();
        }

        public void SetTileWidth()
        {
            Scale = (int)((WindowConfig.windowWidth / this.TilePerScreen ) / this.OrgWidth);

            this.Width = this.OrgWidth * this.Scale;
            this.Height = this.OrgHeight * this.Scale;

            Console.WriteLine("{0} - {1}", Width, Width * TilePerScreen);        
        }

    }
}
