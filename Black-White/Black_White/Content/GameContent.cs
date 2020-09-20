using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Black_White
{
    public class GameContent
    {
        public SpriteFont Ariel20 { get; set; }

        public Texture2D ConsoleBackground { get; set; }
        public Texture2D ConsoleBackground_export2 { get; set; }

        public GameContent(ContentManager content)
        {
            Ariel20 = content.Load<SpriteFont>("Ariel");
            ConsoleBackground = content.Load<Texture2D>("ConsoleBackground");
            ConsoleBackground_export2 = content.Load<Texture2D>("ConsoleBackground-export2");
        }
    }


}
