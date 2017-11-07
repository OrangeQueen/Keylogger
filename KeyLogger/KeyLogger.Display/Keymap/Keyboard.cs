using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KeyLogger.Display.Keymap
{
    [Serializable]
    public class Keyboard
    {
        public List<KeyRectangle> KeyList;

        public Keyboard()
        {
            KeyList = new List<KeyRectangle>();
        }
    }

    [Serializable]
    public class KeyRectangle
    {
        public Keys Key;
        public Rectangle Mapping;
    }
}