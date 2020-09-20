using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Black_White
{
    class ConsoleBox 
    {
        public static List<string> Messages = new List<string>();
        public static int AmountLines = ConsConfig.Lines;
        public static int Offset = 0;

        Vector2 location;
        string Text;
        KeyboardState oldkey;

        public ConsoleBox() //CONSOLE CONSTRUCTOR
        {
            this.location = new Vector2(0, ConsConfig.LineWidth * ConsConfig.Lines);
            this.Text = "";
        }

        public static void initMessages() // INITIATES THE MESSAGES IN MESSAGE LIST
        {
            for (int x = 0; x < ConsConfig.Lines; x++)
            {
                Messages.Add("");
            }
        }

        public static void Clear() // CLEARS THE CONSOLE
        {
            Messages.Clear();
            initMessages();
        }


        public void ConsoleUpdate()
        {
            KeyboardState key = Keyboard.GetState();

            if (ConsConfig.Enabled == true)
            {
                Text = TextBack.TextBox(Text);

                if (key.IsKeyDown(Keys.Delete) && !oldkey.IsKeyDown(Keys.Delete)) // DISABLED CONSOLE
                {
                    ConsConfig.Enabled = false;
                }
                else if (key.IsKeyUp(Keys.Enter) && oldkey.IsKeyDown(Keys.Enter)) 
                {
                    //RESETS THE TYPELINE / EXECUTE THE CODE AND ADDS IT TO THE OLD MESSAGES.
                    ConsoleBox.Messages.Add("CMD:  " + this.Text);
                    ConsoleCommands.ParseCMD(Text);
                    this.Text = "";
                }
                else if (key.IsKeyUp(Keys.Up) && oldkey.IsKeyDown(Keys.Up)) //SCROLL THROUGH CONSOLE HISTORY
                {
                    Offset = Offset > Messages.Count - ConsConfig.Lines - 1 ? Offset : Offset += 1;
                }
                else if (key.IsKeyUp(Keys.Down) && oldkey.IsKeyDown(Keys.Down)) //SCROLL THROUGH CONSOLE HISTORY
                {
                    Offset = Offset <= 0 ? Offset : Offset -= 1;
                }
                else if (key.IsKeyUp(Keys.Tab) && oldkey.IsKeyDown(Keys.Tab))
                {
                    ConsoleSuggestion.getSuggestion(Text);
                }
            }

            if (key.IsKeyDown(Keys.Insert) && !oldkey.IsKeyDown(Keys.Insert)) // ENABLES CONSOLE
            {
                ConsConfig.Enabled = true;
            }

            oldkey = key;
        }

        public void ConsoleDraw(SpriteBatch spriteBatch) 
        {
            if (ConsConfig.Enabled == true)
            {

                //HANDLES THE DRAWING FOR THE CONSOLE: 2 RECTANGLES OF DIFFERENT SHADE, ALL THE PREVIOUS LINES + OFFSET, WRITE LINE INCLUDING "> "

                int dis = ConsConfig.LineWidth * ConsConfig.Lines;

                spriteBatch.Draw(Game1.Fonts.ConsoleBackground, new Rectangle(0,0,WindowConfig.windowWidth, dis), Color.LightGray);
                spriteBatch.Draw(Game1.Fonts.ConsoleBackground_export2, new Rectangle(0, dis, WindowConfig.windowWidth, ConsConfig.LineWidth), Color.LightGray);

                for (int x = 0; x < ConsConfig.Lines; x++)
                {
                    spriteBatch.DrawString(Game1.Fonts.Ariel20, Messages[Messages.Count - ConsConfig.Lines - Offset + x], new Vector2(0, ConsConfig.LineWidth * x), Color.White);
                }

                spriteBatch.DrawString(Game1.Fonts.Ariel20, "> ", location, Color.White);
                spriteBatch.DrawString(Game1.Fonts.Ariel20, Text, new Vector2 (location.X + Game1.Fonts.Ariel20.MeasureString("> ").X, location.Y), Color.White);
            }
        }

        public static void MessageWrite(string message)
        {
            Messages.Add(message);

            if (!ConsConfig.SaveHistory) { return; } //EVERYTHING BEYOND THIS POINT IF SAVEHISTORY == TRUE

            using(StreamWriter sw = File.AppendText(ConsConfig.filename))
            {
                sw.WriteLine(message);
            }
        }
    }
}
