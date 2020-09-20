using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Black_White
{
    static class TextBack
    {
        public static KeyboardState oldkeyboardState;

        public static string TextBox(string Text)
        {
            var currentKeyboardState = Keyboard.GetState();
            var keys = currentKeyboardState.GetPressedKeys();

            foreach (var key in keys)
            {
                if (oldkeyboardState.IsKeyUp(key))
                {
                    if (key == Keys.Back && Text.Length > 0)
                    {
                        Text = Text.Remove(Text.Length - 1, 1);
                    }
                    else if (key == Keys.Space)
                    {
                        Text = Text.Insert(Text.Length, " ");
                    }
                    else
                    {
                        string keyString = key.ToString();
                        bool isUpperCase = false;

                        if (currentKeyboardState.IsKeyDown(Keys.LeftShift))
                        {
                            isUpperCase = true;
                        }

                        if (keyString.Length == 1)
                        {
                            Text += isUpperCase ? keyString.ToUpper() : keyString.ToLower();
                        }
                        if (keyString == "D0" || keyString == "D1" || keyString == "D2" || keyString == "D3" || keyString == "D4" || keyString == "D5" || keyString == "D6" || keyString == "D7" || keyString == "D8" || keyString == "D9")
                        {
                            Text += keyString.Last();
                        }
                    }
                }
            }
            oldkeyboardState = currentKeyboardState;
            return Text;
        }
    }
}
