using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KeyLogger.Display.Keymap
{
    [Serializable]
    public class Mouse
    {
        public List<ButtonPolygon> ButtonList;

        public Mouse()
        {
            ButtonList = new List<ButtonPolygon>();
        }
    }

    [Serializable]
    public class ButtonPolygon
    {
        public MouseButtons Button;
        public Point[] ListPoint;
    }
}